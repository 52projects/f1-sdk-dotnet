using Restify;

namespace FellowshipOne.Api.Activities.Sets {
    public class Instances : ApiSet<Model.Instance> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/schedules/{0}/instances";
        private const string GET_URL = "/activities/v1/schedules/{0}/instances/{1}";
        private const string SEARCH_URL = "/activities/v1/schedules/{0}/instances/search";


        public Instances(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string GetChildListUrl { get { return LIST_URL; } }
        protected override string GetChildUrl { get { return GET_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
    }
}