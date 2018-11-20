using Omega.DAL;
using Omega.Entities;
using Omega.Models;
using Omega.Models.User;
using Omega.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Omega.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IList<Role> _roles;

        public long Add(AddUserViewModel userModel)
        {
            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Role = _roles.SingleOrDefault(r => r.RoleId == userModel.RoleId),
                IsActive = true
            };
            using (var context = new OmegaContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user.UserId;
            }
        }

        public void Delete(long id)
        {
           using (var context = new OmegaContext())
            {
                var userToDelete = context.Users.Single(u => u.UserId == id);
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }
        }

        public IList<UserViewModel> GetAllUsers()
        {
            using (var context = new OmegaContext())
            {
                return context.Users.Select(u => new UserViewModel
                {
                    Id = u.UserId,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Role = u.Role,
                    IsActiveAsString = u.IsActive ? "TAK" : "NIE"

                })
                .ToList();
            }
        }

        public EditUserViewModel GetUser(long id)
        {
            using (var context = new OmegaContext())
            {
                return context.Users.Select(u => new EditUserViewModel
                {
                    Id = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Role = u.Role,
                    IsActive = u.IsActive
                })
                .SingleOrDefault(u => u.Id == id);
            }
        }

        public void Update(EditUserViewModel model)
        {
            using (var context = new OmegaContext())
            {
                var originalUser = context.Users.Single(x => x.UserId == model.Id);
                context.Entry(originalUser).CurrentValues.SetValues(model);
                context.SaveChanges();
            }
        }
    }
}