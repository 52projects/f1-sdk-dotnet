
namespace FellowshipOne.Api.People.Sets {
    public class Schools : ApiSet<Model.School> {
        private const string GET_URL = "/v1/people/schools/{0}";
        private const string LIST_URL = "/v1/people/schools";

        public Schools(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string ListUrl { get { return LIST_URL; } }
    }
}
