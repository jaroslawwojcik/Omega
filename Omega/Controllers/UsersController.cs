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
            
            return View(_unitOfWork.Repository<User>().GetAll().ToList());
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
