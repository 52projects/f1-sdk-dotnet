using System;
using System.Collections.Generic;
using System.Linq;
using Restify;

namespace FellowshipOne.Api.People.Sets {
    public class AccessRights : ApiSet<Model.AccessRight> {
        private const string GET_URL = "/v1/accessrights/{0}";
        private const string GET_CHILD_URL = "/v1/people/{0}/accessrights/{1}";
        private const string CHILD_LIST_URL = "/v1/people/{0}/accessrights";
        private const string CREATE_URL = "/v1/accessrights";
        private const string EDIT_URL = "/v1/accessrights/{0}";

        public AccessRights(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string GetChildUrl { get { return GET_CHILD_URL; } }
        protected override string GetChildListUrl { get { return CHILD_LIST_URL; } }
        protected override string CreateUrl { get { return CREATE_URL; } }
        protected override string EditUrl { get { return EDIT_URL; } }
    }
}
