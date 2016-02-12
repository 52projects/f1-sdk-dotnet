using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Activities.Sets {
    public class AssignmentTypes : ApiSet<Model.AssignmentType> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/types";
        private const string GET_URL = "/activities/v1/types/{0}";
        private string _createUrl = string.Empty;
        private string _editUrl = string.Empty;


        public AssignmentTypes(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string CreateUrl { get { return _createUrl; } }
        protected override string EditUrl { get { return _editUrl; } }
        protected override string ListUrl { get { return LIST_URL; } }
        protected override string GetChildListUrl { get { return LIST_URL; } }
        protected override string GetChildUrl { get { return GET_URL; } }
        protected override string GetUrl { get { return GET_URL; } }
    }
}
