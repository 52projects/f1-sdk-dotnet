using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.Activities.Model {
    public class RosterFolder {
        public int ID { get; set; }
        public string URI { get; set; }
        public string Name { get; set; }
        public ParentObject Activity { get; set; }
    }
}
