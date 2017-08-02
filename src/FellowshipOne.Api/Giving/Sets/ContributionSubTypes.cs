using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Giving.Sets {
    public class ContributionSubTypes : ApiSet<Model.ContributionSubType> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/giving/v1/contributiontypes/{0}/contributionsubtypes";

        public ContributionSubTypes(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        protected override string ListUrl { get { return LIST_URL; } }
        protected override string GetChildListUrl { get { return LIST_URL; } }
    }
}
