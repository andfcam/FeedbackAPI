using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackAPI.Data.Models;
using Newtonsoft.Json;

namespace FeedbackAPI.Web.Services
{
    public class JsonRequestData 
    {
        public dynamic JsonObject;

        private const int DefaultSiteId = 1000000;

        public JsonRequestData(string text)
        {
            JsonObject = ConvertToJson(text);
        }

        public int RequesterId => int.Parse(JsonObject.request.requesterid.ToString());

        public ActionType Action => (ActionType) Enum.Parse(typeof(ActionType), JsonObject.request.action.ToString(), true);

        public int SiteId => JsonObject.site.id != null ? int.Parse(JsonObject.site.id.ToString()) : DefaultSiteId;

        private static dynamic ConvertToJson(string text) => JsonConvert.DeserializeObject<dynamic>(text);
    }
}