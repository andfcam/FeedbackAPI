using System;
using System.IO;
using System.Web;
using FeedbackAPI.Data.Models;
using FeedbackAPI.Web.Models;
using Newtonsoft.Json;

namespace FeedbackAPI.Web.Services
{
    public static class JsonRequestService 
    {
        private const int DefaultSiteId = 1000000;
        private static dynamic _json;

        public static Request FetchRequest()
        {
            var rawData = ReadFromFile("~/App_Data/sample.json");
            _json = ConvertToJson(rawData);
            var jsonRequest = ParseJson();

            return NewRequest(jsonRequest, rawData);
        }

        private static Request NewRequest(JsonRequest jsonRequest, string rawData)
        {
            return new Request
            {
                RequesterId = jsonRequest.RequesterId,
                Action = jsonRequest.Action,
                SiteId = jsonRequest.SiteId,
                Date = DateTime.Now,
                Status = StatusType.Requested,
                Data = rawData
            };
        }

        private static JsonRequest ParseJson()
        {
            return new JsonRequest()
            {
                RequesterId = ParseRequesterId(),
                Action = ParseAction(),
                SiteId = ParseSiteId()
            };
        }

        private static int ParseDynamicInt(dynamic property) => int.Parse(property.ToString());

        private static int ParseRequesterId() => ParseDynamicInt(_json.request.requesterid);

        private static int ParseSiteId() => _json.site.id != null ? ParseDynamicInt(_json.site.id) : DefaultSiteId;

        private static ActionType ParseAction() => (ActionType) Enum.Parse(typeof(ActionType), _json.request.action.ToString(), true);

        private static dynamic ConvertToJson(string text) => JsonConvert.DeserializeObject<dynamic>(text);

        private static string ReadFromFile(string path)
        {
            using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(path)))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}