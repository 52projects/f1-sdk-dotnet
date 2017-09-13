using System;

using FellowshipOne.Api.Attributes;

namespace FellowshipOne.Api.People.QueryObject {
    public class HouseholdQO : BaseQO {
        [QO("searchFor")]
        public string HouseholdName { get; set; }

        [QO("lastActivityDate")]
        public Nullable<DateTime> LastActivityDate { get; set; }

        [QO("lastUpdatedDate")]
        public Nullable<DateTime> LastUpdatedDate { get; set; }

        [QO("createdDate")]
        public Nullable<DateTime> CreatedDate { get; set; }
    }
}
