using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWeb.Models
{
    public class Client
    {
        public int pkclientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }

    }
}