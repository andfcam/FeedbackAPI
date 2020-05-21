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
        // GET: Requests
        public ActionResult Index()
        {
            var model = _database.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _database.Get(id);
            return View(model);
        }
    }
}