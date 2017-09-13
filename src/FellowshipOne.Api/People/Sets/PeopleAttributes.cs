using System.IO;
using System.Text;
using System.Xml.Serialization;
using FellowshipOne.Api.People.Model;
using FellowshipOne.Api.Enum;
using System.Threading.Tasks;

namespace FellowshipOne.Api.People.Sets {
    public class PeopleAttributes : ApiSet<PersonAttribute> {
        private const string CHILD_LIST_URL = "/v1/people/{0}/attributes";
        private const string CREATE_PERSON_ATTRIBUTE_URL = "/v1/people/{0}/attributes";
        private const string EDIT_URL = "/v1/people/{0}/attributes/{1}";
        private string _createUrl = string.Empty;
        private string _editUrl = string.Empty;

        public PeopleAttributes(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string EditUrl { get { return this._editUrl; } }
        protected override string GetChildListUrl { get { return CHILD_LIST_URL; } }
        protected override string CreateUrl {
            get {
                return _createUrl;
            }
        }

        public async Task<PersonAttributeCollection> Get(int personID) {
            var items = await ExecuteCustomRequestAsync<PersonAttributeCollection>(string.Format(CHILD_LIST_URL, personID));
            return items;

            //using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(items))) {
            //    XmlSerializer serializer = new XmlSerializer(typeof(PersonAttributeCollection), new XmlRootAttribute("attributes"));

            //    var result = serializer.Deserialize(stream) as PersonAttributeCollection;
            //    return result;
            //}
        }

        //public PersonAttribute CreateForPerson(int personID, Model.PersonAttribute entity, out string requestXml) {
        //    this._createUrl = string.Format(CREATE_PERSON_ATTRIBUTE_URL, personID);
        //    return Create(entity, out requestXml);
        //}

        //public PersonAttribute UpdateForPerson(int personID, Model.PersonAttribute entity) {
        //    this._editUrl = string.Format(EDIT_URL, personID, entity.APIModelID);
        //    return Update(entity, entity.APIModelID);
        //}

        //public bool DeleteForPerson(int personID, Model.PersonAttribute entity) {
        //    this._editUrl = string.Format(EDIT_URL, personID, entity.APIModelID);
        //    return Delete(entity.APIModelID);
        //}
    }
}
