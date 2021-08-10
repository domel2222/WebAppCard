using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAppCard.Data.Models
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LstName { get; set; }
    }
}
