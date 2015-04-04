using System.Collections.Generic;
using Restify;

namespace FellowshipOne.Api.Giving.Sets {
    public class PledgeDrives : ApiSet<Model.PledgeDrive> {
        private readonly string _baseUrl = string.Empty;
        private const string GET_CHILD_LIST_URL = "/giving/v1/funds/{0}/pledgedrives";

        public PledgeDrives(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        protected override string GetChildListUrl { get { return GET_CHILD_LIST_URL; } }
    }
}
