using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Giving.Sets {
    public class ContributionTypes : ApiSet<Model.ContributionType> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/giving/v1/contributiontypes";

        public ContributionTypes(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        protected override string ListUrl { get { return LIST_URL; } }
    }
}
