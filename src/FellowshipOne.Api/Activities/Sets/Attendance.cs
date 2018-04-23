
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.Activities.Sets {
    public class Attendance : ApiSet<Model.Attendance> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/activities/{0}/instances/{1}/attendances";
        private const string GET_URL = "/activities/v1/activities/{0}/assignments/{1}";
        private const string CREATE_URL = "/activities/v1/activities/{0}/instances/{1}/attendances";
        private const string EDIT_URL = "/activities/v1/activities/{0}/instances/{1}/attendances/{2}";

        public Attendance(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string GetChildListUrl { get { return LIST_URL; } }
        protected override string GetChildUrl { get { return GET_URL; } }

        private string _listUrl = string.Empty;
        protected override string ListUrl { get { return _listUrl; } }

        private string _createUrl = string.Empty;
        protected override string CreateUrl { get { return _createUrl; } }

        private string _editUrl = string.Empty;
        protected override string EditUrl { get { return _editUrl; } }

        public F1Collection<Model.Attendance> FindAll(int activityID, int instanceID, int? page = null) {
            _listUrl = string.Format(CREATE_URL, activityID, instanceID);
            return base.FindAll(page);
        }

        public IFellowshipOneResponse<Model.Attendance> Create(int activityID, int instanceID, Model.Attendance entity) {
            _createUrl = string.Format(LIST_URL, activityID, instanceID);
            return Create(entity);
        }

        public IFellowshipOneResponse<Model.Attendance> Update(Model.Attendance entity) {
            _editUrl = string.Format(EDIT_URL, entity.Activity.ID, entity.Instance.ID, entity.ID);
            return Update(entity, entity.ID.ToString());
        }

        public IFellowshipOneResponse Delete(int activityID, int instanceID, int attendanceID) {
            _editUrl = string.Format(EDIT_URL, activityID, instanceID, attendanceID);
            return base.Delete(attendanceID.ToString());
        }
    }
}
