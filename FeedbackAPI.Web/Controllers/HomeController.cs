using System.Web.Mvc;
using FeedbackAPI.Data.Models;
using FeedbackAPI.Data.Services;
using FeedbackAPI.Web.Models;

namespace FeedbackAPI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestData _database;

        public HomeController(IRequestData database)
        {
            _database = database;
        }

        public ActionResult Index()
        {
            var model = new StatusRequests
            {
                Requested = _database.GetByStatus(StatusType.Requested),
                Accepted = _database.GetByStatus(StatusType.Accepted),
                Rejected = _database.GetByStatus(StatusType.Rejected)
            };
            return View(model);
        }
    }
}