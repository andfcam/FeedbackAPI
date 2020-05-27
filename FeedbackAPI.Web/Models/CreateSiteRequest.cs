using System.ComponentModel.DataAnnotations;

namespace FeedbackAPI.Web.Models
{
    public class CreateSiteRequest
    {
        public SiteInfo Site;

        public class SiteInfo
        {
            public int Id;
            [Required] public string Name;
            [Required] public AddressInfo Address;
            [Required] public ContactsInfo Contacts;
            [Required] public ManagementInfo Management;
            [Required] public AmenitiesInfo Amenities;
            [Required] public EquipmentInfo Equipment;
            [Required] public DisabilityInfo Disability;
            [Required] public Activity[] Activities;
            [Required] public string[] Aliases;
            [Required] public CreateFacilityRequest[] Facilities;
        }

        public class AddressInfo
        {
            public string SubBuildingName;
            public string BuildingName;
            public string BuildingNumber;
            public string DependentThoroughfare;
            public string ThoroughfareName;
            public string DoubleDependentLocality;
            public string DependentLocality;
            [Required] public string PostTown;
            [Required] public string Postcode;
        }

        public class ContactsInfo
        {
            public string Title;
            public string Forename;
            public string Surname;
            public string Designation;
            public string Email;
            public string Telephone;
            public string Website;
        }

        public class ManagementInfo
        {
            [Required] public int ManagementType;
            [Required] public int OwnerType;
            public int EducationPhase;
            public string StartDate;
            public string ClosureDate;
            public string ClosureCode;
            public string ClosureNotes;
        }

        public class AmenitiesInfo
        {
            [Required] public bool HasCarPark;
            public int CarParkCapacity;
            [Required] public bool DedicatedFootballFacility;
            [Required] public bool CyclePark;
            [Required] public bool CycleHire;
            [Required] public bool CycleRepairWorkshop;
            [Required] public bool Nursery;
            [Required] public bool FirstAidRoom;
        }

        public class EquipmentInfo
        {
            public int TableTennisTables;
            public int PoolHoist;
            public int BowlingMachine;
            public int Trampolines;
            public int ParallelBars;
            public int HighBars;
            public int StillRings;
            public int UnevenBars;
            public int BalanceBeam;
            public int Vault;
            public int PommelHorse;
        }

        public class Activity
        {
            public int Id;
        }
    }
}