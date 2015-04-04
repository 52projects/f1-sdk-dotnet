using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.QueryObject;
using Restify.Attributes;

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
