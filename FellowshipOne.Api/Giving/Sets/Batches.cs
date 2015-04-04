using Restify;

namespace FellowshipOne.Api.Giving.Sets {
    public class Batches : ApiSet<Model.Batch> {
        private readonly string _baseUrl = string.Empty;
        private const string GET_URL = "/giving/v1/batches/{0}";
        private const string SEARCH_URL = "/giving/v1/batches/search";
        private const string CREATE_URL = "/giving/v1/batches";
        private const string EDIT_URL = "/giving/v1/batches/{0}";
        private const string AUTO_MATCH_URL = "/giving/v1/batches/{0}/system_automatch";
        
        public Batches(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
        protected override string CreateUrl { get { return CREATE_URL; } }
        protected override string EditUrl { get { return EDIT_URL; } }

        public void GetSystemAutoMatch(int id) {
            var url = string.Format(_baseUrl + AUTO_MATCH_URL, id);
            base.GetByUrl(url);
        }
    }
}
