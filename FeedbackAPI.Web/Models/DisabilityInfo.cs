using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedbackAPI.Web.Models
{
    public class DisabilityInfo
    {
        [Required]
        public bool Access { get; set; }
        public EquippedInfo Equipped { get; set; }
        public string Notes { get; set; }
        public bool ChangingPlacesToiletsExist { get; set; }
    }

    public class EquippedInfo
    {
        public bool Parking { get; set; }
        public bool FindingReachingEntrance { get; set; }
        public bool ReceptionArea { get; set; }
        public bool Doorways { get; set; }
        public bool ChangingFacilities { get; set; }
        public bool ActivityAreas { get; set; }
        public bool Toilets { get; set; }
        public bool SocialAreas { get; set; }
        public bool SpectatorAreas { get; set; }
        public bool EmergencyExits { get; set; }
    }
}