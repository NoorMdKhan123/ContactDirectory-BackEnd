using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class UserRegistration
    {

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Department")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
       ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Password must contains atleast 6 charatcter")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

    }
}
