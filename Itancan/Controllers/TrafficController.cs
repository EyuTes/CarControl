using Itancan.Core;
using Itancan.Core.Models;
using Itancan.Core.ViewModels;
using Itancan.Persistance;
using System.Web.Mvc;

namespace Itancan.Controllers
{
    public class TrafficController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // GET: Account
        public TrafficController()
        {
            _unitOfWork = new UnitOfWork(new ItancanDbContext());
        }

        public ActionResult Index()
        {
            var carViewModel = new CarViewModel
            {
                Cars = _unitOfWork.Cars.GetAll()
            };
            return View(carViewModel);
        }
        public ActionResult DisplayTraffic()
        {


            if (Session["UserName"] != null)
            {
                return Redirect("Index");
                //return Json(carViewModel.Cars, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Login", "Account");
            // return Json(carViewModel.Cars, JsonRequestBehavior.DenyGet);
        }

        public JsonResult List()
        {
            var carViewModel = new CarViewModel
            {
                Cars = _unitOfWork.Cars.GetAll()
            };

            return Json(carViewModel.Cars, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Save(Car car)
        {
            if (car.Id == 0)
            {//New car
                _unitOfWork.Cars.Add(car);
            }
            else
            {//update
                var CarInDb = _unitOfWork.Cars.SingleOrDefault(c => c.Id == car.Id);
                CarInDb.CarModel = car.CarModel;
                CarInDb.CarStatus = car.CarStatus;
                CarInDb.RegistrationNumber = car.RegistrationNumber;
            }
            _unitOfWork.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Car car)
        {
            var CarInDb = _unitOfWork.Cars.SingleOrDefault(c => c.Id == car.Id);
            CarInDb.CarModel = car.CarModel;
            CarInDb.CarStatus = car.CarStatus;
            CarInDb.RegistrationNumber = car.RegistrationNumber;
            return Json(CarInDb, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int ID)
        {
            Car car = _unitOfWork.Cars.SingleOrDefault(c => c.Id == ID);
            _unitOfWork.Cars.Remove(car);
            _unitOfWork.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Car = _unitOfWork.Cars.Find(x => x.Id.Equals(ID));
            return Json(Car, JsonRequestBehavior.AllowGet);
        }
    }

}