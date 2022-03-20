using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class LoginResponseModel
    {
        public int UserId {  get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }

        public ContactDataModel contactData { get; set; }


    }
}
