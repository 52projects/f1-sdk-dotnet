using Restify;

namespace FellowshipOne.Api.Giving.Sets {
    public class SubFunds : ApiSet<Model.SubFund> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/giving/v1/funds/{0}/subfunds";

        public SubFunds(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        protected override string GetChildListUrl {
            get {
                return LIST_URL;
            }
        }
    }
}