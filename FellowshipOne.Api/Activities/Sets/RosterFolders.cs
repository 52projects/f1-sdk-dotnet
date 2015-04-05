using Restify;

namespace FellowshipOne.Api.Activities.Sets {
    public class RosterFolders : ApiSet<Model.RosterFolder> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/activities/{0}/rosterfolders";
        private const string GET_URL = "/activities/v1/activities/{0}/rosterfolders/{1}";
        private const string SEARCH_URL = "/activities/v1/activities/{0}/rosterfolders/search";


        public RosterFolders(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string GetChildListUrl { get { return LIST_URL; } }
        protected override string GetChildUrl { get { return GET_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
    }
}
