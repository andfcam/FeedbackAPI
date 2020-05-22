using System;
using FeedbackAPI.Data.Models;
using Newtonsoft.Json;

namespace FeedbackAPI.Web.Services
{
    public class JsonRequestData 
    {
        private readonly dynamic _jsonObject;

        private const int DefaultSiteId = 1000000;

        public JsonRequestData(string text)
        {
            _jsonObject = ConvertToJson(text);
        }

        public int RequesterId => int.Parse(_jsonObject.request.requesterid.ToString());

        public ActionType Action => (ActionType) Enum.Parse(typeof(ActionType), _jsonObject.request.action.ToString(), true);

        public int SiteId => _jsonObject.site.id != null ? int.Parse(_jsonObject.site.id.ToString()) : DefaultSiteId;

        private static dynamic ConvertToJson(string text) => JsonConvert.DeserializeObject<dynamic>(text);
    }
}