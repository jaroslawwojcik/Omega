using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Omega.Entities
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }

        public string Number { get; set; }

        public Client Client { get; set; }
        public long ClientId { get; set; }
        public Status Status { get; set; }
        public long StatusId { get; set; }
        public User User { get; set; }
        public long UserAddedId { get; set; }
        
    }
}