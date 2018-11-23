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
       
        public long Add(AddUserViewModel userModel)
        {
            using (var context = new OmegaContext())
            {
                var user = new User
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Role = context.Roles.SingleOrDefault(r => r.RoleId == userModel.RoleId),
                    IsActive = true
                };
            
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
                return context.Users.ToArray().Select(u => new UserViewModel
                {
                    Id = u.UserId,
                    FullName = String.Format("{0} {1}", u.FirstName, u.LastName),
                    IsActiveAsString = u.IsActive ? "TAK" : "NIE",
                    Role = context.Roles.SingleOrDefault(r => r.RoleId == u.RoleId)                    
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
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Role = context.Roles.FirstOrDefault(r => r.RoleId == u.RoleId),
                    IsActive = u.IsActive
                })
                .FirstOrDefault(u => u.UserId == id);
            }
        }

        public void Update(EditUserViewModel model)
        {
            using (var context = new OmegaContext())
            {
                var originalUser = context.Users.Single(x => x.UserId == model.UserId);
                context.Entry(originalUser).CurrentValues.SetValues(model);
                context.SaveChanges();
            }
        }
    }
}