using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Omega.Entities
{
    public class Role
    {
        [Key]
        public long RoleId { get; set; }

        public string Name { get; set; }

    }
}