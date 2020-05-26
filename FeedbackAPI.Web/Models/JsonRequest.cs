using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Web.Models
{
    public class JsonRequest
    {
        public int RequesterId { get; set; }

        public ActionType Action { get; set; }

        public DomainType Domain { get; set; }

        public int SiteId { get; set; }
    }
}