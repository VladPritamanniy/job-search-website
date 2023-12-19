using AutoMapper;
using JobHub.DAL.DBObjects;
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
                cfg.CreateMap<DBProduct, ProductModel>().ReverseMap();
                cfg.CreateMap<AuthModel, DBUsers> ().ReverseMap();
            }).CreateMapper();
        }

        public static IEnumerable<ProductModel> Map(IEnumerable<DBProduct> source)
        {
            return _mapper.Map<IEnumerable<ProductModel>>(source);
        }

        public static DBUsers Map(AuthModel source)
        {
            return _mapper.Map<DBUsers>(source);
        }
    }
}
