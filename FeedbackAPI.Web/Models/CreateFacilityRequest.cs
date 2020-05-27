using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace FeedbackAPI.Web.Models
{
    public class CreateFacilityRequest
    {
        public string Id { get; set; }
        [Required]
        public TypeInfo Type { get; set; }
        [Required]
        public ManagementInfo Management { get; set; }
        [Required]
        public BuildHistoryInfo BuildHistory { get; set; }
        [Required]
        public DisabilityInfo Disability { get; set; }
        [Required]
        public OpeningTimesInfo OpeningTimes { get; set; }

        public class TypeInfo
        {
            [Required]
            public int FacilityType { get; set; }
            [Required]
            public int FacilitySubType { get; set; }
        }

        public class ManagementInfo
        {
            [Required]
            public int ManagementType { get; set; }
            [Required]
            public int Status { get; set; }
            public string StatusNotes { get; set; }
            public string ClosureDate { get; set; }
            public string ClosureCode { get; set; }
            public string ClosureReason { get; set; }
            public string ClosureNotes { get; set; }
            public string[] Comments { get; set; }
        }

        public class BuildHistoryInfo
        {
            public string OpeningDate { get; set; }
            public string YearBuilt { get; set; }
            public bool YearBuiltEstimated { get; set; }
            [Required]
            public bool IsRefurbished { get; set; }
            public int YearRefurbished { get; set; }
            [Required]
            public bool HasChangingRooms { get; set; }
            [Required]
            public bool AreChangingRoomsRefurbished { get; set; }
            public string YearChangingRoomsRefurbished { get; set; }
        }

        public class OpeningTimesInfo
        {
            [Required]
            public int SeasonalityType { get; set; }
            public string SeasonalityStart { get; set; }
            public string SeasonalityEnd { get; set; }
            [Required]
            public int TimingsType { get; set; }
            [Required]
            public int Accessibility { get; set; }
            public TimesInfo[] Times { get; set; }
        }

        public class TimesInfo
        {
            public int AccessDescription { get; set; }
            public string OpeningTime { get; set; }
            public string ClosingTime { get; set; }
            public int PeriodOpenFor { get; set; }
        }
    }
}