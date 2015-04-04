using System;
using System.Collections.Generic;
using FellowshipOne.Api.Giving.Model;
using Restify;
using RestSharp;

namespace FellowshipOne.Api.Giving.Sets {
    public class RDCBatchItems : ApiSet<Model.RDCBatchItem> {
        private readonly string _baseUrl = string.Empty;
        private const string GET_URL = "/giving/v1/rdcbatchitems/{0}";
        private const string SEARCH_URL = "/v1/rdcbatchitems/search";
        private const string CREATE_URL = "/giving/v1/rdcbatchitems";
        private const string EDIT_URL = "/giving/v1/rdcbatchitems/{0}";
        private const string GET_CHILD_LIST_URL = "/giving/v1/batches/{0}/rdcbatchitems";
        private const string CREATE_REFERENCE_IMAGE_URL = "/giving/v1/rdcbatchitems/{0}/referenceimages";

        public RDCBatchItems(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
        protected override string CreateUrl { get { return CREATE_URL; } }
        protected override string EditUrl { get { return EDIT_URL; } }
        protected override string GetChildListUrl { get { return GET_CHILD_LIST_URL; } }

        public bool CreateReferenceImage(byte[] stream, int? rdcBatchItemID) {
            var url = string.Format(_baseUrl + CREATE_REFERENCE_IMAGE_URL, rdcBatchItemID);
            var result = base.Create(stream, url);
            return result;
        }

        public List<RDCBatchItem> GetListByBatchId(int batchID) {
            return base.List(batchID.ToString());
        }
    }
}
