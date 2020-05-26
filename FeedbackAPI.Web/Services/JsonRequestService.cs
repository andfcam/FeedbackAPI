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
        private static dynamic _json;

        public static Request FetchRequest()
        {
            var rawData = SimulateRequest();
            _json = ConvertToJson(rawData);
            var jsonRequest = ParseJson();

            return NewRequest(jsonRequest, rawData);
        }

        private static string SimulateRequest()
        {
            var variant = new Random().Next(1, 4);
            return ReadFromFile($"~/App_Data/request-{variant}.json");
        }

        private static Request NewRequest(JsonRequest jsonRequest, string rawData)
        {
            return new Request
            {
                RequesterId = jsonRequest.RequesterId,
                Action = jsonRequest.Action,
                Domain = jsonRequest.Domain,
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
                Domain = ParseDomain(),
                SiteId = ParseSiteId()
            };
        }

        private static int RandomiseSiteId() => new Random().Next(1000000, 1100000);

        private static int ParseDynamicInt(dynamic property) => int.Parse(property.ToString());

        private static int ParseRequesterId() => ParseDynamicInt(_json.request.requesterid);

        private static int ParseSiteId() => _json.site.id != null ? ParseDynamicInt(_json.site.id) : RandomiseSiteId();

        private static ActionType ParseAction() => (ActionType) Enum.Parse(typeof(ActionType), _json.request.action.ToString(), true);

        private static DomainType ParseDomain() => (DomainType) Enum.Parse(typeof(DomainType), _json.request.domain.ToString(), true);

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