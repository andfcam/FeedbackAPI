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
        public ActionResult Index(string query)
        {
            var model = new StatusRequests
            {
                Requested = _database.GetByStatus(StatusType.Requested),
                Accepted = _database.GetByStatus(StatusType.Accepted),
                Rejected = _database.GetByStatus(StatusType.Rejected)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRequest()
        {
            var request = ParseJsonService.Simulate();
            _database.Add(request);
            TempData["Message"] = "A new request has been created.";
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
            if (model == null) return View("NotFound");
            return model.Status != StatusType.Requested ? View("NotValid") : View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept(int id, FormCollection form)
        {
            _database.Accept(id);
            TempData["Message"] = $"Request #{id} has been accepted.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Reject(int id)
        {
            var model = _database.Get(id);
            if (model == null) return View("NotFound");
            return model.Status != StatusType.Requested ? View("NotValid") : View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(int id, FormCollection form)
        {
            _database.Reject(id);
            TempData["Message"] = $"Request #{id} has been rejected.";
            return RedirectToAction("Index");
        }
    }
}