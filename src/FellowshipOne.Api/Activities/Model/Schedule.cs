using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.Activities.Model {
    public class Schedule {
        public int ID { get; set; }
        public string URI { get; set; }
        public ParentObject Activity { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
