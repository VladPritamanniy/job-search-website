namespace JobHub.DAL.Data.DBObjects
{
    public class DBVacancy
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual byte[] CompanyImage { get; set; }
        public virtual int SalaryFrom { get; set; }
        public virtual int SalaryTo { get; set; }
        public virtual int CurrencyID { get; set; }
        public virtual string CompanyLocation { get; set; }
        public virtual DateTime PublicationDate { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual int EmploymentTypeID { get; set; }
        public virtual int CategoryID { get; set; }
        public virtual int SubCategoryID { get; set; }
        public virtual bool IsPublished { get; set; }
    }
}
