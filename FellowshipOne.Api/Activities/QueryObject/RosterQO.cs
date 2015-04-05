using FellowshipOne.Api.QueryObject;
using Restify.Attributes;

namespace FellowshipOne.Api.Activities.QueryObject {
    public class RosterQO : BaseQO {
        [QO("name")]
        public string Name { get; set; }
    }
}