using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using FeedbackAPI.Data.Models;
using FeedbackAPI.Web.Models;
using Newtonsoft.Json;

namespace FeedbackAPI.Web.Services
{
    public static class ParseJsonService 
    {
        public static Request Simulate()
        {
            var data = Fetch();
            var model = Deserialise(data);
            var status = Validate(model);
            return Parse(model, data, status);
        }

        public static string ReadFromFile(string path)
        {
            using (var streamReader = new StreamReader(HttpContext.Current.Server.MapPath(path)))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static dynamic Deserialise(string data)
        {
            var requestInfo = JsonConvert.DeserializeObject<RequestInfo>(data);

            dynamic model;
            switch (requestInfo.Request.Domain)
            {
                case DomainType.Site:
                    model = ParseSiteRequest(data, requestInfo);
                    break;
                case DomainType.Facility:
                    model = ParseFacilityRequest(data, requestInfo);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
            return model;
        }

        public static StatusType Validate(dynamic model)
        {
            FacilityRequest.Facility[] facilities = (model.GetType() == typeof(SiteRequest)) ? model.Site.Facilities : model.Facilities;
            if (model.Site.Id == 0)
            {
                return StatusType.Rejected;
            }
            else if (facilities != null)
            {
                if (facilities.Any(facility => facility.Id == 0))
                {
                    return StatusType.Rejected;
                }
            }
            return StatusType.Requested;
        }

        public static Request Parse(dynamic model, string data, StatusType status)
        {
            return new Request
            {
                RequesterId = model.Request.RequesterId,
                Action = model.Request.Action,
                Domain = model.Request.Domain,
                SiteId = model.Site.Id,
                Date = DateTime.Now,
                Status = status,
                Data = data
            };
        }

        private static string Fetch()
        {
            var variant = new Random().Next(1, 4);
            return ReadFromFile($"~/App_Data/request-{variant}.json");
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