using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.Activities.Model {
    public class Attendance {
        public int ID { get; set; }
        public string URI { get; set; }
        public ParentObject Person { get; set; }
        public ParentObject Activity { get; set; }
        public ParentObject Instance { get; set; }
        public ParentObject Roster { get; set; }
        public ParentNamedObject Type { get; set; }
        public bool? Checkin { get; set; }
        public bool? Checkout { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ParentObject CreatedByPerson { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public ParentObject LastUpdatedByPerson { get; set; }
    }
}
