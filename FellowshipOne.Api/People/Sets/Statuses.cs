using Restify;

namespace FellowshipOne.Api.People.Sets {
    public class Statuses : ApiSet<Model.Status> {
        private const string GET_URL = "/v1/people/statuses/{0}";
        private const string LIST_URL = "/v1/people/statuses";

        public Statuses(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string ListUrl { get { return LIST_URL; } }
    }
}
