using System.Runtime.Serialization;
using System;
using FellowshipOne.Api.Model;
using Newtonsoft.Json;

namespace FellowshipOne.Api.Activities.Model {
    public class AssignmentType {
        [JsonProperty("id")]
        public int? ID { get; set; }
        [JsonProperty("uri")]
        public string URI { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
