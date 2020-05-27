using static FeedbackAPI.Web.Models.FacilityGroups;

namespace FeedbackAPI.Web.Models
{
    public class FacilityRequest
    {
        public RequestDetails Request;
        public SiteInfo Site;
        public Facility[] Facilities;

        public class SiteInfo
        {
            public int Id { get; set; }
        }

        public class Facility
        {
            public int Id { get; set; }
            public TypeInfo Type;
            public ManagementInfo Management;
            public BuildHistoryInfo BuildHistory;
            public DisabilityInfo Disability;
            public FacilitySpecificsInfo FacilitySpecifics;
            public OpeningTimesInfo OpeningTimes;
        }
    }
}