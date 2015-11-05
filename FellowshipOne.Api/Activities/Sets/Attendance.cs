
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.Activities.Sets {
    public class Attendance : ApiSet<Model.Attendance> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/activities/{0}/instances/{1}/attendances";
        private const string GET_URL = "/activities/v1/activities/{0}/assignments/{1}";
        private string _createUrl = string.Empty;
        private string _editUrl = string.Empty;


        public Attendance(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string GetChildListUrl { get { return LIST_URL; } }
        protected override string GetChildUrl { get { return GET_URL; } }
        protected override string CreateUrl { get { return _createUrl; } }
        protected override string EditUrl { get { return GET_URL; } }

        private string _listUrl = string.Empty;
        protected override string ListUrl {
            get {
                return _listUrl;
            }
        }

        public F1Collection<Model.Attendance> FindAll(int activityID, int instanceID, int? page = null) {
            _listUrl = string.Format(LIST_URL, activityID, instanceID);
            return base.FindAll(page);
        }

        public Model.Attendance Create(int activityID, int instanceID, Model.Attendance entity) {
            _createUrl = string.Format(LIST_URL, activityID, instanceID);
            return Create(entity);
        }

    }
}
