using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class RegisterResponseModel
    {
        public int UserId { get; set; }

        public int ContactId { get; set; }

        public string UserName { get; set; }

     
        public int Age { get; set; }

 
        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }



    
        public string Department { get; set; }

        
        public string Location { get; set; }




        public string Email { get; set; }

      
   

        
        public string Phone { get; set; }

    }
}
