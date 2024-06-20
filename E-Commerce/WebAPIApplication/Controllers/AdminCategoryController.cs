using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPIApplication.Controllers
{
    public class AdminCategoryController : Controller
    {
        //
        // GET: /AdminCategory/
       
        //[Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexAngularjs()
        {
            return View();
        }

        public ActionResult CategoryDetails()
        {
            return View();
        }

        public ActionResult ModifyCategory()
        {
            return View();
        }
        public ActionResult ImageProcess()
        {
            return View();
        }

        public ActionResult JqueryCustomeAnimation()
        {

            return View();
        }
        public ActionResult AngularRoute()
        {

            return View();
        }

	}
}