using System;
using FellowshipOne.Api.Model;
using Newtonsoft.Json;


namespace FellowshipOne.Api.Activities.Model {
    public class Instance {
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("uri")]
        public string URI { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("schedule")]
        public ParentObject Schedule { get; set; }
        [JsonProperty("activity")]
        public ParentObject Activity { get; set; }
        [JsonProperty("startDateTime")]
        public DateTime? StartDateTime { get; set; }
        [JsonProperty("startCheckin")]
        public DateTime? StartCheckin { get; set; }
        [JsonProperty("endCheckin")]
        public DateTime? EndCheckin { get; set; }
    }
}
