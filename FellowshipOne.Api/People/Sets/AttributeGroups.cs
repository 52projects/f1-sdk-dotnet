using Restify;
using FellowshipOne.Api.People.Model;

namespace FellowshipOne.Api.People.Sets {
    public class AttributeGroups : ApiSet<AttributeGroup> {
        private const string GET_URL = "/v1/people/attributegroups/{0}";
        private const string LIST_URL = "/v1/people/attributegroups";

        public AttributeGroups(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string ListUrl { get { return LIST_URL; } }
    }
}