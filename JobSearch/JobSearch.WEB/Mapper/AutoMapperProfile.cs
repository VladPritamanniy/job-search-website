using AutoMapper;
using JobSearch.BLL.DTO;
using JobSearch.DAL.EfClasses;
using JobSearch.WEB.Areas.Admin.Models;
using JobSearch.WEB.Models;
using JobSearch.WEB.ViewModels;

namespace JobSearch.WEB.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Vacancy, VacancyDto>().ReverseMap();
            CreateMap<VacancyModel, VacancyDto>().ReverseMap();

            CreateMap<VacancyModel, VacancyDto>().ReverseMap();
            CreateMap<VacancyModel, VacancyViewModel>().ReverseMap();
            CreateMap<VacancyDetailsViewModel, VacancyModel>().ReverseMap();

            CreateMap<VacancyResponseModel, VacancyResponseDto>().ReverseMap();

            CreateMap<VacancyResponseDto, VacancyResponse>().ReverseMap();

            CreateMap<VacancyResponseDto, VacancyResponseAdminViewModel>().ReverseMap();
        }
    }
}
