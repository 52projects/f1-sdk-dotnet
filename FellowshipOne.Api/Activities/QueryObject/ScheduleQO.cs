
using FellowshipOne.Api.Attributes;

namespace FellowshipOne.Api.Activities.QueryObject {
    public class ScheduleQO : BaseQO {
        [QO("name")]
        public string Name { get; set; }
    }
}
