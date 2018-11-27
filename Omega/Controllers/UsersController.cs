using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Omega.DAL;
using Omega.Entities;
using Omega.Models;
using Omega.Models.User;
using Omega.Repositories.IRepositories;

namespace Omega.Controllers
{
    public class UsersController : Controller
    {
        private GenericUnitOfWork _unitOfWork = null;
        public UsersController()
        {
            _unitOfWork = new GenericUnitOfWork();
        }
        public UsersController(GenericUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var usersList = _unitOfWork.Repository<User>().GetAll().ToList();
            var userViewModelList = Mapper.Map<List<UserViewModel>>(usersList);
            
            return View(userViewModelList);
        }

        public ActionResult Edit(long id)
        {
            
            return View(_unitOfWork.Repository<User>().GetSingle(id));
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel userModel)
        {
            return View();
        }
    }
}
