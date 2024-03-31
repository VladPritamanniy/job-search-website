using AutoMapper;
using JobSearch.BLL.Interfaces;
using JobSearch.WEB.Models;
using JobSearch.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly IVacancyService _vacancyService;
		private readonly IMapper _mapper;

        public HomeController(IVacancyService vacancyService, IMapper mapper)
		{
            _vacancyService = vacancyService;
			_mapper = mapper;
        }

		public async Task<IActionResult> Index()
        {
            var vacancies = await _vacancyService.GetAll();
            var vacanciesList = new VacancyListViewModel() { Items = _mapper.Map<IEnumerable<VacancyModel>>(vacancies) };
            return View(vacanciesList);
		}
	}
}
