using FellowshipOne.Api.QueryObject;
using Restify.Attributes;
using System;

namespace FellowshipOne.Api.Activities.QueryObject {
    public class InstanceQO : BaseQO {
        [QO("date")]
        public DateTime Date { get; set; }
    }
}
