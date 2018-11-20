using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Omega.Entities
{
    public class Status
    {
        [Key]
        public long StatusId { get; set; }

        public string Name { get; set; }

    }
}