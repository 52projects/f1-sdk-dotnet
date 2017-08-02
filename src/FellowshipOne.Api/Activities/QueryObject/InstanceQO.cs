
using FellowshipOne.Api.Attributes;
using System;

namespace FellowshipOne.Api.Activities.QueryObject {
    public class InstanceQO : BaseQO {
        [QO("date")]
        public DateTime Date { get; set; }

        [QOIgnore]
        public int ScheduleID { get; set; }
    }
}
