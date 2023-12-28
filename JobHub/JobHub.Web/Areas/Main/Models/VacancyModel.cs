using JobHub.DAL.Data.Enums;

namespace JobHub.Web.Areas.Main.Models
{
    public class VacancyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public byte[] CompanyLogo { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public Currency CurrencyID { get; set; }
        public string CompanyLocation { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public EmploymentType EmploymentTypeID { get; set; }
        public Category CategoryID { get; set; }
        public SubCategory SubCategoryID { get; set; }
        public bool IsPublished { get; set; }
    }
}
