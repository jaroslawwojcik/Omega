using Omega.Models.Role;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Omega.Models
{
    public class EditUserViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Pole imie musi być wypełnione")]
        [MinLength(3, ErrorMessage = "Imie musi mieć co najmniej 3 znaki")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole nazwisko musi być wypełnione")]
        [MinLength(3, ErrorMessage = "Nazwisko musi mieć co najmniej 3 znaki")]
        public string LastName { get; set; }
        public IList<RoleViewModel> RoleModelsList { get; set; }
        public Omega.Entities.Role Role { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}