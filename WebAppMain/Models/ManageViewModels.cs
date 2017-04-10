using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebAppMain.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "Must_be_at_least_6_char")]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType =typeof(Resources.Resource))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType =typeof(Resources.Resource))]
        [Compare("NewPassword", ErrorMessageResourceName = "Password_must_match", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType =typeof(Resources.Resource))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType =typeof(Resources.Resource), ErrorMessageResourceName ="Must_be_at_least_6_char")]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType =typeof(Resources.Resource))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType =typeof(Resources.Resource))]
        [Compare("NewPassword", ErrorMessageResourceName = "Password_must_match", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType =typeof(Resources.Resource))]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType =typeof(Resources.Resource))]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}