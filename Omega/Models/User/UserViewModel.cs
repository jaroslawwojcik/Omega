using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omega.Models.User
{
    public class UserViewModel
    {
        public long Id { get; set; }

        public string FullName { get; set; }
        public Omega.Entities.Role Role { get; set; }
        public string IsActiveAsString { get; set; }
    }
}