using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entities
{
    public class ContactData
    {

        
        public int UserId { get; set; }
        
        public virtual User UserData { get; set; }



        public int ContactId { get; set; }
     
        public virtual User UsersDatas { get; set; }











    }
}
