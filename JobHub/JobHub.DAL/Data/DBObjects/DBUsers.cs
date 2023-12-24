namespace JobHub.DAL.Data.DBObjects
{
    public class DBUsers
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        public virtual string Email { get; set; }
    }
}
