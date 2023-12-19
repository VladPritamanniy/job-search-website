namespace JobHub.DAL.DBObjects
{
    public class DBUsers
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
    }
}
