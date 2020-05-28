using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;
using FeedbackAPI.Data.Models;
using FeedbackAPI.Web.Models;
using Newtonsoft.Json;

namespace FeedbackAPI.Web.Services
{
    public static class ParseJsonService 
    {
        public static Request Fetch()
        {
            var data = ReceiveData();
            var model = Deserialise(data);

            // perform validation here

            return new Request
            {
                RequesterId = model.Request.RequesterId,
                Action = model.Request.Action,
                Domain = model.Request.Domain,
                SiteId = model.Site.Id,
                Date = DateTime.Now,
                Status = StatusType.Requested,
                Data = data
            };
        }

        private static string ReceiveData()
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

        private static dynamic Deserialise(string data)
        {
            var requestInfo = JsonConvert.DeserializeObject<RequestInfo>(data);

            dynamic request;
            switch (requestInfo.Request.Domain)
            {
                case DomainType.Site:
                    request = ParseSiteRequest(data, requestInfo);
                    break;
                case DomainType.Facility:
                    request = ParseFacilityRequest(data, requestInfo);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            return request;
        }

        private static SiteRequest ParseSiteRequest(string data, RequestInfo requestInfo)
        {
            var siteRequest = JsonConvert.DeserializeObject<SiteRequest>(data);
            if (requestInfo.Request.Action == ActionType.Create)
            {
                siteRequest.Site.Id = GetRandomSiteId();
                GetRandomFacilityIdsFor(siteRequest.Site.Facilities);
            }
            return siteRequest;
        }

        private static FacilityRequest ParseFacilityRequest(string data, RequestInfo requestInfo)
        {
            var facilityRequest = JsonConvert.DeserializeObject<FacilityRequest>(data);
            if (requestInfo.Request.Action == ActionType.Create)
            {
                GetRandomFacilityIdsFor(facilityRequest.Facilities);
            }
            return facilityRequest;
        }

        private static int GetRandomSiteId() => new Random().Next(1000000, 1200000);

        private static void GetRandomFacilityIdsFor(IEnumerable<FacilityRequest.Facility> facilities)
        {
            foreach (var facility in facilities)
            {
                facility.Id = GetRandomFacilityId();
            }
        }

        private static int GetRandomFacilityId() => new Random().Next(2000000, 2200000);
    }
}