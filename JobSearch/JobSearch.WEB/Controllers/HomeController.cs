using AutoMapper;
using JobSearch.BLL.Interfaces;
using JobSearch.WEB.Models;
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

        [HttpGet]
		public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5, string searchString = null)
        {
            var vacanciesDto = await _vacancyService.GetAll(pageNumber, pageSize, searchString);
            var vacanciesCount = _vacancyService.GetCount();
            var vacanciesModel = _mapper.Map<IEnumerable<VacancyModel>>(vacanciesDto);
            var vacancies = new PagedListModel<VacancyModel>(vacanciesModel, pageNumber, pageSize, vacanciesCount);
            return View(vacancies);
		}
	}
}
