using System;
using System.IO;
using System.Web;
using System.Web.Configuration;
using FeedbackAPI.Data.Models;
using FeedbackAPI.Web.Models;
using Newtonsoft.Json;

namespace FeedbackAPI.Web.Services
{
    public static class JsonRequestService 
    {
        public static Request FetchRequest()
        {
            var rawData = SimulateRequest();
            var jsonRequest = ParseJson(rawData);

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

        private static JsonRequest ParseJson(string rawData)
        {
            var json = ConvertToObject(Type.GetType("dynamic"), rawData);
            var action = ParseAction(json);
            var domain = ParseDomain(json);

            var type = Type.GetType($"FeedbackAPI.Web.Models.{action}{domain}Request"); // should be working

            // can build type with $"{action}{domain}Request" and pass to JsonConvert.DeserializeObject<typeVariable>(rawData)

            // becomes redundant - return createRequest or updateRequest in switch statement
            return new JsonRequest()
            {
                Action = ParseAction(json),
                Domain = ParseDomain(json),
                RequesterId = ParseRequesterId(json),
                SiteId = ParseSiteId(json)
            };
        }

        private static int RandomiseSiteId() => new Random().Next(1000000, 1100000);

        private static int ParseDynamicInt(dynamic property) => int.Parse(property.ToString());

        private static int ParseRequesterId(dynamic json) => ParseDynamicInt(json.request.requesterid);

        private static int ParseSiteId(dynamic json) => json.site.id != null ? ParseDynamicInt(json.site.id) : RandomiseSiteId();

        private static ActionType ParseAction(dynamic json) => (ActionType) Enum.Parse(typeof(ActionType), json.request.action.ToString(), true);

        private static DomainType ParseDomain(dynamic json) => (DomainType) Enum.Parse(typeof(DomainType), json.request.domain.ToString(), true);

        private static dynamic ConvertToObject(Type type, string text) => JsonConvert.DeserializeObject<dynamic>(text);

        private static string ReadFromFile(string path)
        {
            using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(path)))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}