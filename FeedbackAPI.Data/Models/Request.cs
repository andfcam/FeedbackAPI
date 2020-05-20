using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackAPI.Data.Models
{
    public class Request
    {
        public int Id { get; set; }

        public int RequesterId { get; set; }

        public ActionType Action { get; set; }

        public int SiteId { get; set; }

        public DateTime Date { get; set; }

        public StatusType Status { get; set; }

        public string Data { get; set; }
    }
}
