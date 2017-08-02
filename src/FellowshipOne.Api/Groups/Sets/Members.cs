using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Groups.Sets {
    public class Members : ApiSet<Model.Member> {
        private const string SEARCH_URL = "/groups/v1/members/search";
        private const string LIST_URL = "/groups/v1/groups/{0}/members";

        public Members(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string SearchUrl { get { return SEARCH_URL; } }
        private string _createUrl = LIST_URL;
        protected override string CreateUrl {
            get {
                return _createUrl;
            }
        }
        protected override string GetChildListUrl {
            get {
                return LIST_URL;
            }
        }

        public Model.Member Create(int groupID, Model.Member member) {
            _createUrl = string.Format(LIST_URL, groupID);
            return base.Create(member);
        }
    }
}
