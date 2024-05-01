namespace JobSearch.WEB.Models
{
    public class VacancyResponseModel
    {
        public int VacancyResponseId { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public byte[] Resume { get; set; }

        public string CoverLetter { get; set; }

        public int VacancyId { get; set; }
    }
}
