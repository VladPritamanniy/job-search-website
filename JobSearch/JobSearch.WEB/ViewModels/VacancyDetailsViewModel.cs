namespace JobSearch.WEB.ViewModels
{
    public class VacancyDetailsViewModel
    {
        public int VacancyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public VacancyResponseViewModel Response { get; set; }
    }
}
