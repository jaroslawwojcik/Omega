using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Omega.DAL;
using Omega.Entities;
using Omega.Models;
using Omega.Repositories.IRepositories;

namespace Omega.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _personsRepository;
        private readonly IRoleRepository _roleRepository;

        public UsersController(IUserRepository personsRepository, IRoleRepository roleRepository)
        {
            _personsRepository = personsRepository;
            _roleRepository = roleRepository;
        }

        public ActionResult Index()
        {
            var userList = _personsRepository.GetAllUsers();
            return View(userList);
        }

        public ActionResult Edit(long id)
        {
            var userToEdit = _personsRepository.GetUser(id);
            return View(userToEdit);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel userModel)
        {
            return View();
        }
    }
}
