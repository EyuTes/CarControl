using Itancan.Core;
using Itancan.Core.Models;
using Itancan.Persistance;
using System.Web.Mvc;

namespace Itancan.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // GET: Account
        public AccountController()
        {
            _unitOfWork = new UnitOfWork(new ItancanDbContext());
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {

            if (ModelState.IsValid)
            {
                var userInDb = _unitOfWork.UserAccounts.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                if (userInDb != null)
                {
                    Session["UserName"] = userInDb;
                    return RedirectToAction("DisplayTraffic", "Traffic");

                }
                else
                {
                    ModelState.AddModelError("Login", "Username or password are wrong");
                }
                return RedirectToAction("Login", "Account");

            }
            return RedirectToAction("Login", "Account");
        }

    }

}