using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperTest_Fruit_SA.Database;

namespace DeveloperTest_Fruit_SA.Controllers
{
    public class UpDownloadController : Controller
    {
        private readonly Db _db;
        public UpDownloadController(Db db)
        {
            _db = db;
        }
        // GET: UpDownload
        public ActionResult Index()
        {
            return View();
        }
    }
}