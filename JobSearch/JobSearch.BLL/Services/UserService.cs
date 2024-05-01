using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using JobSearch.BLL.DTO;
using JobSearch.BLL.Interfaces;
using JobSearch.DLL.EfClasses;
using JobSearch.DLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JobSearch.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;
        private readonly IConfiguration _configuration;

        public UserService(IPasswordHasher passwordHasher, IUserRepository userRepository, IMapper mapper, IJwtProvider jwtProvider, IConfiguration configuration)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
            _configuration = configuration;
        }

        public async Task Register(string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var userDto = new UserDto
            {
                Email = email,
                PasswordHash = hashedPassword
            };
            await _userRepository.Add(_mapper.Map<User>(userDto));
        }

        public async Task<RefreshTokenOptions> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user is null || !_passwordHasher.Verify(password, user.PasswordHash))
            {
                return new RefreshTokenOptions();
            }

            var accessToken = _jwtProvider.GenerateToken(_mapper.Map<UserDto>(user));
            var refreshToken = _jwtProvider.GenerateRefreshToken();

            var userDto = new UserDto
            {
                Email = email,
                RefreshToken = refreshToken,
                RefreshTokenExpiry = DateTime.UtcNow.AddDays(30)
            };
            await _userRepository.Update(_mapper.Map<User>(userDto));

            return new RefreshTokenOptions{ AccessToken = accessToken, RefreshToken = refreshToken };
        }

        public async Task<RefreshTokenOptions> RefreshAccessToken(string accessToken, string refreshToken)
        {
            var newAccessToken = string.Empty;
            var newRefreshTokenn = string.Empty;
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var userId = principal?.Claims.FirstOrDefault(x => x.Type == "userId")?.Value;

            if (!string.IsNullOrEmpty(userId))
            {
                var user = await _userRepository.GetById(int.Parse(userId));
                var mapUser = _mapper.Map<UserDto>(user);

                if (mapUser.RefreshToken == refreshToken && mapUser.RefreshTokenExpiry > DateTime.UtcNow)
                {
                    newAccessToken = _jwtProvider.GenerateToken(mapUser);
                    newRefreshTokenn = _jwtProvider.GenerateRefreshToken();
                    var userDto = new UserDto
                    {
                        Email = mapUser.Email,
                        RefreshToken = newRefreshTokenn,
                        RefreshTokenExpiry = DateTime.UtcNow.AddDays(30)
                    };

                    await _userRepository.Update(_mapper.Map<User>(userDto));
                }
            }
            return new RefreshTokenOptions { AccessToken = newAccessToken, RefreshToken = newRefreshTokenn };
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var secret = _configuration["JwtOptions:SecretKey"];

            var validation = new TokenValidationParameters
            {
                ValidIssuer = _configuration["JwtOptions:ValidIssuer"],
                ValidAudience = _configuration["JwtOptions:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateLifetime = false
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }
    }
}
