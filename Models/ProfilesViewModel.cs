using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCash.Models
{
    public class ProfilesViewModel
    {
        public int ProfileID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string NIK { get; set; }
        public string NIK_Photo { get; set; }
        public string No_Rekening { get; set; }
        public string Nama_Rekening { get; set; }
        public string Bank { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Boolean Verified { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime LoginTime { get; set; }
    }
}