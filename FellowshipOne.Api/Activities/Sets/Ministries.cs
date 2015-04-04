using Restify;

namespace FellowshipOne.Api.Activities.Sets {
    public class Ministries : ApiSet<Model.Ministry> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/ministries";
        private const string GET_URL = "/activities/v1/ministries/{0}";


        public Ministries(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string ListUrl { get { return LIST_URL; } }
        protected override string GetUrl { get { return GET_URL; } }
    }
}
