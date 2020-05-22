using System.Collections.Generic;
using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Web.Models
{
    public class FilteredStatusRequests
    {
        public IEnumerable<Request> Requested { get; set; }

        public IEnumerable<Request> Accepted { get; set; }

        public IEnumerable<Request> Rejected { get; set; }
    }
}