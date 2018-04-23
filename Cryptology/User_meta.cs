using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cryptology
{
    [MetadataTypeAttribute(typeof(User_meta))]
    public partial class User
    {

    }
    public class User_meta
    {
        [Required(ErrorMessage ="Email Is Required")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "First Name Is Required")]
        [Display(Name = "First Name")]
        public string fname { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]
        [Display(Name = "Last Name")]
        public string lname { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        [Display(Name = "Password")]
        public string pword { get; set; }

    }

}