using Omega.Models;
using Omega.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Repositories.IRepositories
{
    interface IUserRepository
    {
        IList<UserViewModel> GetAllUsers();
        EditUserViewModel GetUser(long id);

        long Add(AddUserViewModel user);
        void Update(EditUserViewModel user);
        void Delete(long id);
    }
}
