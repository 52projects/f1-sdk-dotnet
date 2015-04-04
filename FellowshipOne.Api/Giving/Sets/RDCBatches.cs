using System.Collections.Generic;
using Restify;

namespace FellowshipOne.Api.Giving.Sets {
    public class RDCBatches : ApiSet<Model.RDCBatch> {
        private const string GET_URL = "/giving/v1/batches/{0}/rdcbatches";
        private const string GET_CHILD_LIST_URL = "/giving/v1/batches/{0}/rdcbatches";
        private const string SEARCH_URL = "/v1/batches/search";
        private const string CREATE_URL = "/giving/v1/rdcbatches";
        private const string EDIT_URL = "/giving/v1/rdcbatches/{0}";

        public RDCBatches(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }
        
        protected override string GetUrl { get { return GET_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
        protected override string CreateUrl { get { return CREATE_URL; } }
        protected override string EditUrl { get { return EDIT_URL; } }
        protected override string GetChildListUrl { get { return GET_CHILD_LIST_URL; } }

        public Model.RDCBatch GetByBatchID(int batchID) {
            return base.Get(batchID.ToString());
        }
    }
}
