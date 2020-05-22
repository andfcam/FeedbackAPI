using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeedbackAPI.Data.Models;
using FeedbackAPI.Data.Services;
using FeedbackAPI.Web.Models;
using FeedbackAPI.Web.Services;

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
            var model = new FilteredStatusRequests
            {
                Requested = _database.GetByStatus(StatusType.Requested),
                Accepted = _database.GetByStatus(StatusType.Accepted),
                Rejected = _database.GetByStatus(StatusType.Rejected)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection form)
        {
            var request = CreateRequest();
            _database.Add(request);
            return RedirectToAction("Index");
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

        private string ReadFromFile(string path)
        {
            using (var streamReader = new StreamReader(Server.MapPath(path)))
            {
                return streamReader.ReadToEnd();
            }
        }

        private Request CreateRequest()
        {
            var plainText = ReadFromFile("~/App_Data/sample.json");
            var jsonObject = new JsonRequestData(plainText);

            return new Request
            {
                RequesterId = jsonObject.RequesterId,
                Action = jsonObject.Action,
                SiteId = jsonObject.SiteId,
                Date = DateTime.Now,
                Status = StatusType.Requested,
                Data = plainText
            };
        }
    }
}