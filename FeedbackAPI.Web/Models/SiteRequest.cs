using static FeedbackAPI.Web.Models.SiteGroups;

namespace FeedbackAPI.Web.Models
{
    public class SiteRequest
    {
        public RequestDetails Request;
        public SiteInfo Site;

        public class SiteInfo
        {
            public int Id { get; set; }
            public string Name;
            public AddressInfo Address;
            public ContactsInfo Contacts;
            public ManagementInfo Management;
            public AmenitiesInfo Amenities;
            public EquipmentInfo Equipment;
            public DisabilityInfo Disability;
            public Activity[] Activities;
            public string[] Aliases;
            public FacilityRequest.Facility[] Facilities;
        }
    }
}