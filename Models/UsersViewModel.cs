using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCash.Models
{
    public class UsersViewModel
    {
        public int UserID { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public string DeleteBy { get; set; }
        public Boolean Dlt { get; set; }

    }
}