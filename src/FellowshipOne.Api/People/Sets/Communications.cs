using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.People.Sets {
    public class Communications : ApiSet<Model.Communication> {
        private const string GET_URL = "/v1/communications/{0}";
        private const string GET_CHILD_URL = "/v1/people/{0}/communications/{1}";
        private const string CHILD_LIST_URL = "/v1/people/{0}/communications";
        private const string CREATE_URL = "/v1/communications";
        private const string EDIT_URL = "/v1/communications/{0}";
        private const string CREATE_INDIVIDUAL_COMMUNICATION_URL = "/v1/people/{0}/communications";
        private const string CREATE_HOUSEHOLD_COMMUNICATION_URL = "/v1/households/{0}/communications";
        private const string DELETE_INDIVIDUAL_COMMUNICATION_URL = "/v1/people/{0}/communications/{1}";
        private const string DELETE_HOUSEHOLD_COMMUNICATION_URL = "/v1/households/{0}/communications/{1}";

        public Communications(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }
        private string editUrl = EDIT_URL;

        protected override string GetUrl { get { return GET_URL; } }
        protected override string GetChildUrl { get { return GET_CHILD_URL; } }
        protected override string GetChildListUrl { get { return CHILD_LIST_URL; } }
        protected override string CreateUrl { get { return CREATE_URL; } }
        protected override string EditUrl { get { return editUrl; } }

        public IFellowshipOneResponse<Model.Communication> CreateForPerson(int personID, Model.Communication entity) {
            var url = string.Format(CREATE_INDIVIDUAL_COMMUNICATION_URL, personID);
            return Create(entity, url);
        }

        public IFellowshipOneResponse<Model.Communication> CreateForPerson(int personID, Model.Communication entity, out string requestXml) {
            var url = string.Format(CREATE_INDIVIDUAL_COMMUNICATION_URL, personID);
            return Create(entity, out requestXml, url);
        }

        public IFellowshipOneResponse<Model.Communication> CreateForHousehold(int householdID, Model.Communication entity) {
            var url = string.Format(CREATE_HOUSEHOLD_COMMUNICATION_URL, householdID);
            return Create(entity, url);
        }

        public IFellowshipOneResponse<Model.Communication> CreateForHousehold(int householdID, Model.Communication entity, out string requestXml) {
            var url = string.Format(CREATE_HOUSEHOLD_COMMUNICATION_URL, householdID);
            return Create(entity, out requestXml, url);
        }

        public void DeleteForHousehold(int id, int householdID) {
            editUrl = string.Format(DELETE_HOUSEHOLD_COMMUNICATION_URL, householdID, id);
            Delete(id.ToString());
            editUrl = EDIT_URL;
        }
    }
}