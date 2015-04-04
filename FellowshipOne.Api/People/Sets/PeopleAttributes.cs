using Restify;

namespace FellowshipOne.Api.People.Sets {
    public class PeopleAttributes : ApiSet<Model.PersonAttribute> {
        private const string CHILD_LIST_URL = "/v1/people/{0}/attributes";
        private const string CREATE_PERSON_ATTRIBUTE_URL = "/v1/people/{0}/attributes";
        private string _createUrl = string.Empty;

        public PeopleAttributes(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string GetChildListUrl { get { return CHILD_LIST_URL; } }
        protected override string CreateUrl {
            get {
                return _createUrl;
            }
        }

        public Model.PersonAttribute CreateForPerson(int personID, Model.PersonAttribute entity, out string requestXml) {
            this._createUrl = string.Format(CREATE_PERSON_ATTRIBUTE_URL, personID);
            return Create(entity, out requestXml);
        }
    }
}
