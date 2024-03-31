using AutoMapper;
using JobSearch.BLL.DTO;
using JobSearch.BLL.Interfaces;
using JobSearch.WEB.Areas.Admin.Models;
using JobSearch.WEB.Models;
using JobSearch.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class VacancyController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public VacancyController(IVacancyService vacancyService, IMapper mapper)
        {
            _vacancyService = vacancyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var vacancies = await _vacancyService.GetAll();
            if (vacancies.Any())
            {
                var vacanciesList = new VacancyListViewModel()
                {
                    Items = _mapper.Map<IEnumerable<VacancyModel>>(vacancies)
                };
                return View(vacanciesList);
            }
            return View(new VacancyListViewModel());
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id.HasValue && id.Value != 0)
            {
                var vacancy = await _vacancyService.Get(Convert.ToInt32(id));
                var vacancyModel = _mapper.Map<VacancyModel>(vacancy);
                var vacancyViewModel = _mapper.Map<VacancyViewModel>(vacancyModel);

                return View(vacancyViewModel);
            }
            return View(new VacancyViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Save(VacancyViewModel vacancy)
        {
            if (ModelState.IsValid)
            {
                if(vacancy.IsPublished){ vacancy.PublicationDate = DateTime.Now;}

                var vacancyModel = _mapper.Map<VacancyModel>(vacancy);
                var vacancyDto = _mapper.Map<Vacancy>(vacancyModel);

                await _vacancyService.Create(vacancyDto);

                return Redirect("Index");
            }
            return RedirectToAction("Edit", vacancy);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _vacancyService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> GetResponsesById(int id)
        {
            var responses = await _vacancyService.GetResponsesByVacancyId(id);
            var vacancyMap = _mapper.Map<IEnumerable<VacancyResponseAdminViewModel>>(responses);
            return View("VacancyResponses", vacancyMap);
        }

        [HttpGet]
        public async Task<ActionResult> DownloadResume(int id, string fName, string lName)
        {
            var resume =  await _vacancyService.GetResumeById(id);
            return File(resume, "application/octet-stream", $"{fName}{lName}.pdf");
        }
    }
}
