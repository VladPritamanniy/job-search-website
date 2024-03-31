namespace JobSearch.BLL.DTO
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int JwtExpires { get; set; }
        public int RefreshExpires { get; set; }
    }
}
