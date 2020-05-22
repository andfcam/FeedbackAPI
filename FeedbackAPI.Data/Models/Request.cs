using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FeedbackAPI.Data.Models
{
    public class Request
    {
        public int Id { get; set; }

        [DisplayName("Requested by")]
        public int RequesterId { get; set; }

        public ActionType Action { get; set; }

        [DisplayName("Site ID")]
        public int SiteId { get; set; }

        [DisplayName("Received on")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Date { get; set; }

        public StatusType Status { get; set; }

        public string Data { get; set; }
    }
}
