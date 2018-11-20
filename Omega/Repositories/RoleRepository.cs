using Omega.DAL;
using Omega.Entities;
using Omega.Models.Role;
using Omega.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omega.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public void Add(AddRoleViewModel roleModel)
        {
            var role = new Role
            {
                Name = roleModel.Name
            };
            using(var context = new OmegaContext())
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            using(var context = new OmegaContext())
            {
                var roleToDelete = context.Roles.Single(r => r.RoleId == id);
                context.Roles.Remove(roleToDelete);
                context.SaveChanges();
            }
        }

        public IList<RoleViewModel> GetAllRoles()
        {
            using (var context = new OmegaContext())
            {
                return context.Roles.Select(r => new RoleViewModel
                {
                   RoleId = r.RoleId,
                   Name = r.Name
                })
                .ToList();
            }
        }

        public EditRoleViewModel GetRole(long id)
        {
            using (var context = new OmegaContext())
            {
                return context.Roles.Select(r => new EditRoleViewModel
                {
                    RoleId = r.RoleId,
                    Name = r.Name
                })
                .SingleOrDefault(r => r.RoleId == id);
            }
        }

        public void Update(EditRoleViewModel roleModel)
        {
            using (var context = new OmegaContext())
            {
                var originalRole = context.Roles.Single(x => x.RoleId == roleModel.RoleId);
                context.Entry(originalRole).CurrentValues.SetValues(roleModel);
                context.SaveChanges();
            }
        }
    }
}