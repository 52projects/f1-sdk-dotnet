using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Groups.Sets {
    public class Groups : ApiSet<Model.Group> {
        private const string LIST_URL = "/groups/v1/grouptypes/{0}/groups";
        private const string SEARCH_URL = "/groups/v1/groups/search";
        private const string SHOW_URL = "/groups/v1/groups/{0}";
        private const string CREATE_URL = "/groups/v1/groups";

        public Groups(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string ListUrl { get { return LIST_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }

        protected override string CreateUrl {
            get {
                return CREATE_URL;
            }
        }

        protected override string GetUrl {
            get {
                return SHOW_URL;
            }
        }

        protected override string EditUrl {
            get {
                return SHOW_URL;
            }
        }

        protected override string GetChildListUrl {
            get {
                return LIST_URL;
            }
        }
    }
}
