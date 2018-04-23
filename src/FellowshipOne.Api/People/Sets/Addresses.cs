using System.Collections.Generic;
using FellowshipOne.Api.People.Model;
using FellowshipOne.Api.Model;


namespace FellowshipOne.Api.People.Sets {
    public class Addresses : ApiSet<Model.Address> {
        private const string GET_URL = "/v1/addresses/{0}";
        private const string GET_CHILD_URL = "/v1/people/{0}/addresses{1}";
        private const string CHILD_LIST_URL = "/v1/people/{0}/addresses";
        private const string CREATE_URL = "/v1/addresses";
        private const string EDIT_URL = "/v1/addresses/{0}";
        private const string CREATE_INDIVIDUAL_ADDRESS_URL = "/v1/people/{0}/addresses";
        private const string CREATE_HOUSEHOLD_ADDRESS_URL = "/v1/households/{0}/addresses";

        public Addresses(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string GetChildUrl { get { return GET_CHILD_URL; } }
        protected override string GetChildListUrl { get { return CHILD_LIST_URL; } }
        protected override string CreateUrl { get { return CREATE_URL; } }
        protected override string EditUrl { get { return EDIT_URL; } }

        private string _listUrl = CREATE_HOUSEHOLD_ADDRESS_URL;
        protected override string ListUrl {
            get {
                return _listUrl;
            }
        }


        public IFellowshipOneResponse<Model.Address> CreateForPerson(int personID, Model.Address entity) {
            var url = string.Format(CREATE_INDIVIDUAL_ADDRESS_URL, personID);
            return Create(entity, url);
        }

        public IFellowshipOneResponse<Model.Address> CreateForPerson(int personID, Model.Address entity, out string requestXml) {
            var url = string.Format(CREATE_INDIVIDUAL_ADDRESS_URL, personID);
            return Create(entity, out requestXml, url);
        }

        public IFellowshipOneResponse<Model.Address> CreateForHousehold(int householdID, Model.Address entity) {
            var url = string.Format(CREATE_HOUSEHOLD_ADDRESS_URL, householdID);
            return Create(entity, url);
        }

        public IFellowshipOneResponse<Model.Address> CreateForHousehold(int householdID, Model.Address entity, out string requestXml) {
            var url = string.Format(CREATE_HOUSEHOLD_ADDRESS_URL, householdID);
            return Create(entity, out requestXml, url);
        }

        public IFellowshipOneResponse<List<Address>> GetHouseholdAddresses(string householdID) {
            _listUrl = string.Format(CREATE_HOUSEHOLD_ADDRESS_URL, householdID);
            return List();
        }
    }
}
