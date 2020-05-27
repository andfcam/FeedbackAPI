using System.ComponentModel.DataAnnotations;
using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Web.Models
{
    public class RequestInfo
    {
        public RequestDetails Request;
    }

    public class RequestDetails
    {
        [Required] public int RequesterId;
        [Required] public ActionType Action;
        [Required] public DomainType Domain;
    }
}