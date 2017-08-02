using System.Runtime.Serialization;
using System;
using FellowshipOne.Api.Model;
using Newtonsoft.Json;

namespace FellowshipOne.Api.Activities.Model {
    public class Room {
        public int? ID { get; set; }
        public string URI { get; set; } 
        public string Name {get; set;}
        public string Code { get; set; }
        public string description { get; set; }
    }
}
