using AutoMapper;
using JobSearch.BLL.DTO;
using JobSearch.BLL.Interfaces;
using JobSearch.WEB.Models;
using JobSearch.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.WEB.Controllers
{
    public class InfoController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public InfoController(IVacancyService vacancyService, IMapper mapper)
        {
            _vacancyService = vacancyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var vacancy = await _vacancyService.Get(id);
            var vacancyModel = new VacancyDetailsViewModel
            {
                Id = vacancy.Id,
                Title = vacancy.Title,
                Description = vacancy.Description
            };
            return View(vacancyModel);
        }

        [HttpPost]
        public async Task<ActionResult> SendResponse(VacancyDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                byte[] resumeByteArray;
                using (var memoryStream = new MemoryStream())
                {
                    await viewModel.Response.Resume.CopyToAsync(memoryStream);
                    resumeByteArray = memoryStream.ToArray();
                }
                var model = new VacancyResponseModel
                {
                    Fname = viewModel.Response.FName,
                    Lname = viewModel.Response.LName,
                    Resume = resumeByteArray,
                    CoverLetter = viewModel.Response.CoverLetter,
                    VacancyId = viewModel.Id
                };
                var modelMap = _mapper.Map<VacancyResponse>(model);

                await _vacancyService.AddResponse(modelMap);
                return Redirect("/");
            }
            ModelState.AddModelError(string.Empty, Resources.Resource.Error_FillRequiredFieldsAndAttachResume);

            return View("Details", viewModel);
        }
    }
}
