using System.Web.Mvc;
using FeedbackAPI.Data.Services;

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
            var model = _database.GetAll();
            return View(model);
        }
    }
}