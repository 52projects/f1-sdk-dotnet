using Restify;

namespace FellowshipOne.Api.Activities.Sets {
    public class Activities : ApiSet<Model.Activity> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/activities";
        private const string GET_URL = "/activities/v1/activities/{0}";
        private const string SEARCH_URL = "/activities/v1/activities/search";


        public Activities(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string ListUrl { get { return LIST_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
        protected override string GetUrl { get { return GET_URL; } }
    }
}
