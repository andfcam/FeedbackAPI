using System.ComponentModel.DataAnnotations;

namespace FeedbackAPI.Web.Models
{
    public class CreateFacilityRequest
    {
        public int Id;
        [Required] public TypeInfo Type;
        [Required] public ManagementInfo Management;
        [Required] public BuildHistoryInfo BuildHistory;
        [Required] public DisabilityInfo Disability;
        [Required] public OpeningTimesInfo OpeningTimes;

        public class TypeInfo
        {
            [Required] public int FacilityType;
            [Required] public int FacilitySubType;
        }

        public class ManagementInfo
        {
            [Required] public int ManagementType;
            [Required] public int Status;
            public string StatusNotes;
            public string ClosureDate;
            public string ClosureCode;
            public string ClosureReason;
            public string ClosureNotes;
            public string[] Comments;
        }

        public class BuildHistoryInfo
        {
            public string OpeningDate;
            public string YearBuilt;
            public bool YearBuiltEstimated;
            [Required] public bool IsRefurbished;
            public int YearRefurbished;
            [Required] public bool HasChangingRooms;
            [Required] public bool AreChangingRoomsRefurbished;
            public string YearChangingRoomsRefurbished;
        }

        public class OpeningTimesInfo
        {
            [Required] public int SeasonalityType;
            public string SeasonalityStart;
            public string SeasonalityEnd;
            [Required] public int TimingsType;
            [Required] public int Accessibility;
            public TimesInfo[] Times;
        }

        public class TimesInfo
        {
            public int AccessDescription;
            public string OpeningTime;
            public string ClosingTime;
            public int PeriodOpenFor;
        }
    }
}