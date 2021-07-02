using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GHWebApp.Models
{

    public class UserViewModel
    {
        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("RoleName")]
        public string RoleName { get; set; }

        [DisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [DisplayName("AccessFailedCount")]
        public int AccessFailedCount { get; set; }



    }
}


