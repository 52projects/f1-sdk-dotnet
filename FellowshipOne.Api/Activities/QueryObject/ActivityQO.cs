
using FellowshipOne.Api.Attributes;

namespace FellowshipOne.Api.Activities.QueryObject {
    public class ActivityQO : BaseQO {
        [QO("ministryID")]
        public int MinistryID { get; set; }
    }
}
