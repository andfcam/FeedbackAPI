using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FeedbackAPI.Data.Models;

namespace FeedbackAPI.Web.Models
{
    public class CreateSiteRequest
    {
        public RequestInfo Request { get; set; }
        public SiteInfo Site { get; set; }

        public class RequestInfo
        {
            [Required]
            public string RequesterId { get; set; }
            [Required]
            public ActionType Action { get; set; }
            [Required]
            public DomainType Domain { get; set; }
        }

        public class SiteInfo
        {
            public string Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public AddressInfo Address { get; set; }
            [Required]
            public ContactsInfo Contacts { get; set; }
            [Required]
            public ManagementInfo Management { get; set; }
            [Required]
            public AmenitiesInfo Amenities { get; set; }
            [Required]
            public EquipmentInfo Equipment { get; set; }
            [Required]
            public DisabilityInfo Disability { get; set; }
            [Required]
            public Activity[] Activities { get; set; }
            [Required]
            public string[] Aliases { get; set; }
            [Required]
            public CreateFacilityRequest[] Facilities { get; set; }
        }

        public class AddressInfo
        {
            public string SubBuildingName { get; set; }
            public string BuildingName { get; set; }
            public string BuildingNumber { get; set; }
            public string DependentThoroughfare { get; set; }
            public string ThoroughfareName { get; set; }
            public string DoubleDependentLocality { get; set; }
            public string DependentLocality { get; set; }
            [Required]
            public string PostTown { get; set; }
            [Required]
            public string Postcode { get; set; }
        }

        public class ContactsInfo
        {
            public string Title { get; set; }
            public string Forename { get; set; }
            public string Surname { get; set; }
            public string Designation { get; set; }
            public string Email { get; set; }
            public string Telephone { get; set; }
            public string Website { get; set; }
        }

        public class ManagementInfo
        {
            [Required]
            public int ManagementType { get; set; }
            [Required]
            public int OwnerType { get; set; }
            public int EducationPhase { get; set; }
            public string StartDate { get; set; }
            public string ClosureDate { get; set; }
            public string ClosureCode { get; set; }
            public string ClosureNotes { get; set; }
        }

        public class AmenitiesInfo
        {
            [Required]
            public bool HasCarPark { get; set; }
            public int CarParkCapacity { get; set; }
            [Required]
            public bool DedicatedFootballFacility { get; set; }
            [Required]
            public bool CyclePark { get; set; }
            [Required]
            public bool CycleHire { get; set; }
            [Required]
            public bool CycleRepairWorkshop { get; set; }
            [Required]
            public bool Nursery { get; set; }
            [Required]
            public bool FirstAidRoom { get; set; }
        }

        public class EquipmentInfo
        {
            public int TableTennisTables { get; set; }
            public int PoolHoist { get; set; }
            public int BowlingMachine { get; set; }
            public int Trampolines { get; set; }
            public int ParallelBars { get; set; }
            public int HighBars { get; set; }
            public int StillRings { get; set; }
            public int UnevenBars { get; set; }
            public int BalanceBeam { get; set; }
            public int Vault { get; set; }
            public int PommelHorse { get; set; }
        }

        public class Activity
        {
            public string Id { get; set; }
        }
    }
}