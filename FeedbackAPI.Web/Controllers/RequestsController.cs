using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeedbackAPI.Data.Services;

namespace FeedbackAPI.Web.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRequestData _database;

        public RequestsController(IRequestData database)
        {
            _database = database;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            var model = _database.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _database.Get(id);
            return model != null ? View(model) : View("NotFound");
        }

        [HttpGet]
        public ActionResult Accept(int id)
        {
            var model = _database.Get(id);
            return model != null ? View(model) : View("NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept(int id, FormCollection form)
        {
            _database.Accept(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Reject(int id)
        {
            var model = _database.Get(id);
            return model != null ? View(model) : View("NotFound");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(int id, FormCollection form)
        {
            _database.Reject(id);
            return RedirectToAction("Index");
        }
    }
}