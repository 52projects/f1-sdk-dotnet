using Restify;

namespace FellowshipOne.Api.Activities.Sets {
    public class Assignments : ApiSet<Model.Assignment> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/activities/{0}/assignments";
        private const string GET_URL = "/activities/v1/activities/{0}/assignments/{1}";


        public Assignments(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string GetChildListUrl { get { return LIST_URL; } }
        protected override string GetChildUrl { get { return GET_URL; } }
        protected override string CreateUrl { get { return LIST_URL; } }
        protected override string EditUrl { get { return GET_URL; } }
    }
}
