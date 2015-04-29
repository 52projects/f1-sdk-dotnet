using Restify;

namespace FellowshipOne.Api.Activities.Sets {
    public class Assignments : ApiSet<Model.Assignment> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/activities/{0}/assignments";
        private const string GET_URL = "/activities/v1/activities/{0}/assignments/{1}";
        private string _createUrl = string.Empty;
        private string _editUrl = string.Empty;


        public Assignments(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string CreateUrl { get { return _createUrl; } }
        protected override string EditUrl { get { return _editUrl; } }
        protected override string ListUrl { get { return LIST_URL; } }
        protected override string GetChildListUrl { get { return LIST_URL; } }
        protected override string GetChildUrl { get { return GET_URL; } }
        protected override string GetUrl { get { return GET_URL; } }

        public Model.Assignment Create(int activityID, Model.Assignment entity) {
            _createUrl = string.Format(LIST_URL, activityID);
            return Create(entity);
        }

        public Model.Assignment Create(int activityID, Model.Assignment entity, out string requestXml) {
            _createUrl = string.Format(LIST_URL, activityID);
            return Create(entity, out requestXml);
        }

        public bool Delete(int activityID, int assignmentID) {
            _editUrl = string.Format(GET_URL, activityID, assignmentID);
            //bas

            return false;
        }
    }
}
