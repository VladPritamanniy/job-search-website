using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JobHub.Web.Areas.Personal.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [AdditionalMetadata("autofocus", true)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
