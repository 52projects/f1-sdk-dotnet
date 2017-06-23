using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Groups.Sets {
    public class GroupTypes : ApiSet<Model.GroupType> {
        private const string LIST_URL = "/groups/v1/grouptypes";
        private const string SEARCH_URL = "/groups/v1/grouptypes/search";

        public GroupTypes(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string ListUrl { get { return LIST_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
    }
}
