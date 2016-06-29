using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Groups.Sets {
    public class Members : ApiSet<Model.Member> {
        private const string SEARCH_URL = "/groups/v1/members/search";

        public Members(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string SearchUrl { get { return SEARCH_URL; } }
    }
}
