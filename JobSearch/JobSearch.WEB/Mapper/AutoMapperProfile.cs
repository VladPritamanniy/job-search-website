using AutoMapper;
using JobSearch.BLL.DTO;
using JobSearch.DLL.Entities;
using JobSearch.WEB.Areas.Admin.Models;
using JobSearch.WEB.Models;
using JobSearch.WEB.ViewModels;

namespace JobSearch.WEB.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();

            CreateMap<VacancyEntity, Vacancy>().ReverseMap();
            CreateMap<VacancyModel, Vacancy>().ReverseMap();

            CreateMap<VacancyModel, Vacancy>().ReverseMap();
            CreateMap<VacancyModel, VacancyViewModel>().ReverseMap();
            CreateMap<VacancyDetailsViewModel, VacancyModel>().ReverseMap();

            CreateMap<VacancyResponseModel, VacancyResponse>().ReverseMap();

            CreateMap<VacancyResponse, VacancyResponseEntity>().ReverseMap();

            CreateMap<VacancyResponse, VacancyResponseAdminViewModel>().ReverseMap();
        }
    }
}
