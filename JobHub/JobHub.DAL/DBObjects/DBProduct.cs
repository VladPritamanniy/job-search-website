namespace JobHub.DAL.DBObjects
{
    public class DBProduct
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual int Units { get; set; }
    }
}
