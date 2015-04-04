using Restify;

namespace FellowshipOne.Api.Giving.Sets {
    public class Funds : ApiSet<Model.Fund> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/giving/v1/funds";

        public Funds(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        protected override string ListUrl {get { return LIST_URL; } }
    }
}
