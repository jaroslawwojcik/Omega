using Omega.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Repositories.IRepositories
{
    interface IRoleRepository
    {
        IList<RoleViewModel> GetAll();
        void Add(AddRoleViewModel role);
        void Delete(long id);
        void Update(EditRoleViewModel user);
        EditRoleViewModel GetRole(long id);
    }
}
