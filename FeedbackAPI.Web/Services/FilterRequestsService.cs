using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackAPI.Data.Models;
using FeedbackAPI.Data.Services;
using FeedbackAPI.Web.Models;

namespace FeedbackAPI.Web.Services
{
    public static class FilterRequestsService
    {

        public static IEnumerable<Request> FilterBySiteId(IEnumerable<Request> requests, string query)
        {
            return !string.IsNullOrEmpty(query) ? requests.Where(request => request.SiteId.ToString().Contains(query)) : requests;
        }
    }
}