using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;


namespace FellowshipOne.Api.Activities.Model {
    public class Instance {
        public int ID { get; set; }
        public string URI { get; set; }
        public string Name { get; set; }
        public ParentObject Schedule { get; set; }
        public ParentObject Activity { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? StartCheckin { get; set; }
        public DateTime? EndCheckin { get; set; }
    }
}
