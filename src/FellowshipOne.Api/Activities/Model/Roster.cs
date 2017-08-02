using System.Runtime.Serialization;
using System;
using FellowshipOne.Api.Model;
using Newtonsoft.Json;


namespace FellowshipOne.Api.Activities.Model {
    public class Roster {
        public int ID { get; set; }
        public string URI { get; set; }
        public string Name { get; set; }
        public ParentObject Activity { get; set; }
        public ParentObject RosterFolder { get; set; }
        public bool? CheckinAutoOpen { get; set; }
        public bool? CheckinEnabled { get; set; }
        public bool? HasNameTag { get; set; }
        public bool? HasReceipt { get; set; }
        public int? DefaultCapacity { get; set; }
        public DateTime? StartAgeDate { get; set; }
        public DateTime? EndAgeDate { get; set; }
        public int? StartAgeRange { get; set; }
        public int? EndAgeRange { get; set; }
        public int? DefaultAge { get; set; }
        public int? ScheduleID { get; set; }
        public bool? PagerEnabled { get; set; }
        public bool? IsClosed { get; set; }
        public string AgeRangeType { get; set; }

        [JsonProperty("room")]
        public ParentObject Room { get; set; }
    }
}
