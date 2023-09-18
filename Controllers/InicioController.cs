using DignitaTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DignitaTask.Filters;
using System.Data.Common;
using DignitaTask.Services;

namespace DignitaTask.Controllers
{

    [ValidateSession]
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        


    }
}