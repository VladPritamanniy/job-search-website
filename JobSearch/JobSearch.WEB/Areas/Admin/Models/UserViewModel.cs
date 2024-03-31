using System.ComponentModel.DataAnnotations;

namespace JobSearch.WEB.Areas.Admin.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_RequiredField")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_RequiredField")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Error_PasswordMustContain")]
        public string Password { get; set; }
    }
}
