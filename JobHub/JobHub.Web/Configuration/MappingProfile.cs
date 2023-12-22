using AutoMapper;
using JobHub.DAL.Data.DBObjects;
using JobHub.Web.Areas.Main.Models;
using JobHub.Web.Areas.Personal.Models;

namespace JobHub.Web.Configuration
{
    public class Mapper
    {
        private static readonly IMapper _mapper;

        static Mapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VacancyModel, DBVacancy>().ReverseMap();
                cfg.CreateMap<AuthModel, DBUsers> ().ReverseMap();
            }).CreateMapper();
        }

        public static IEnumerable<VacancyModel> Map(IEnumerable<DBVacancy> source)
        {
            return _mapper.Map<IEnumerable<VacancyModel>>(source);
        }

        public static DBUsers Map(AuthModel source)
        {
            return _mapper.Map<DBUsers>(source);
        }

        public static AuthModel Map(DBUsers source)
        {
            return _mapper.Map<AuthModel>(source);
        }
    }
}
