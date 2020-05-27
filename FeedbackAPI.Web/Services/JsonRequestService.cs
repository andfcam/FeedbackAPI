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
        public static Request FetchRequest()
        {
            var rawData = SimulateRequest();
            var requestInfo = ConvertToObject(rawData, typeof(RequestInfo));
            ParseJson(rawData, requestInfo); // var obj = 

            return NewRequest(requestInfo, rawData);
        }

        private static string SimulateRequest()
        {
            var variant = new Random().Next(1, 4);
            return ReadFromFile($"~/App_Data/request-{variant}.json");
        }

        private static string ReadFromFile(string path)
        {
            using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(path)))
            {
                return streamReader.ReadToEnd();
            }
        }

        private static void ParseJson(string rawData, RequestInfo requestInfo)
        {
            var name = $"{requestInfo.Request.Action}{requestInfo.Request.Domain}Request";
            var type = Type.GetType($"FeedbackAPI.Web.Models.{name}");

            var obj = ConvertToObject(rawData, type);
            //var x = "Break here.";

            //return the obj and change void
        }

        private static Request NewRequest(RequestInfo jsonRequest, string rawData)
        {
            return new Request
            {
                RequesterId = jsonRequest.Request.RequesterId,
                Action = jsonRequest.Request.Action,
                Domain = jsonRequest.Request.Domain,
                SiteId = RandomiseSiteId(),
                Date = DateTime.Now,
                Status = StatusType.Requested,
                Data = rawData
            };
        }

        private static dynamic ConvertToObject(string text, Type type) => JsonConvert.DeserializeObject(text, type);

        private static int RandomiseSiteId() => new Random().Next(1000000, 1100000);
    }
}