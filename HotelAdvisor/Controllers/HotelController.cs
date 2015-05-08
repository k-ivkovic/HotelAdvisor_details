using HotelAdvisor.Managers;
using HotelAdvisor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelAdvisor.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel

        public ActionResult Index()
        {
            HotelAdvisorContext context = new HotelAdvisorContext();
            var model = context.Hotels.ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(Hotel model)
        {
            if(ModelState.IsValid)
            {
                HotelManager manager = new HotelManager();
                manager.Create(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            HotelManager manager = new HotelManager();
            var model = manager.GetHotelDetails(id);

            return View(model);
        }
    }
}