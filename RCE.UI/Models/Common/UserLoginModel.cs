using System.ComponentModel.DataAnnotations;
using Resource = RCE.UI.Resources;

namespace RCE.UI.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessageResourceType =typeof(Resource.Validation),ErrorMessageResourceName =nameof(Resources.Validation.CannotBeEmpty))]
        [MaxLength(50,ErrorMessageResourceType =typeof(Resource.Validation),ErrorMessageResourceName =nameof(Resources.Validation.MustBeProperLength))]
        [Display(ResourceType =typeof(Resource.UI),Name=nameof(Resources.UI.Email))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource.Validation), ErrorMessageResourceName = nameof(Resources.Validation.CannotBeEmpty))]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resource.Validation), ErrorMessageResourceName = nameof(Resources.Validation.MustBeProperLength))]
        [Display(ResourceType = typeof(Resource.UI), Name = nameof(Resources.UI.Password))]
        public string Password { get; set; }
    }
}