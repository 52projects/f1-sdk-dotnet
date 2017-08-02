using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FellowshipOne.Api.Activities.Model {
    public class Activity {
        public int ID { get; set; }
        public string URI { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? HasCheckin { get; set; }
        public int? CheckinMinutesBefore { get; set; }
        public bool? HasNameTag { get; set; }
        public bool? HasReceipt { get; set; }
        public int? StartAge { get; set; }
        public int? EndAge { get; set; }
        public bool? Confidential { get; set; }
        public int? RequiresRegistration { get; set; }
        public bool? RosterBySchedule { get; set; }
        public bool? AssignmentsOverrideClosedRoom { get; set; }
        public int? AutoAssignmentOption { get; set; }
        public bool? PagerEnabled { get; set;}
        public bool? WebEnabled {get; set; }
    }
}
