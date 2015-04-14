using System.Runtime.Serialization;
using System;
using FellowshipOne.Api.Model;
using Newtonsoft.Json;

namespace FellowshipOne.Api.Activities.Model {
    public class Assignment {
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("uri")]
        public string URI { get; set; }

        [JsonProperty("type")]
        public ParentNamedObject Type { get; set; }

        [JsonProperty("person")]
        public ParentObject Person { get; set; }

        [JsonProperty("activity")]
        public ParentObject Activity { get; set; }

        [JsonProperty("schedule")]
        public ParentObject Schedule { get; set; }

        [JsonProperty("roster")]
        public ParentObject Roster { get; set; }

        [JsonProperty("rosterFolder")]
        public ParentObject RosterFolder { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("createdByPerson")]
        public ParentObject CreatedByPerson { get; set; }

        [JsonProperty("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }

        [JsonProperty("lastUpdatedByPerson")]
        public ParentObject LastUpdatedByPerson { get; set; }
    }
}
