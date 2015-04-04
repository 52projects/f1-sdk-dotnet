using Restify;

namespace FellowshipOne.Api.Giving.Sets {
    public class ContributionReceipts : ApiSet<Model.ContributionReceipt> {
        private readonly string _baseUrl = string.Empty;
        private const string GET_URL = "/giving/v1/contributionreceipts/{0}";
        private const string SEARCH_URL = "/giving/v1/contributionreceipts/search";
        private const string CREATE_URL = "/giving/v1/contributionreceipts";

        public ContributionReceipts(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
        protected override string CreateUrl { get { return CREATE_URL; } }
    }
}
