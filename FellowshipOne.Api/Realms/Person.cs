using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.People.Sets;

namespace FellowshipOne.Api.Realms {
    public class Person {
        #region Properties
        F1OAuthTicket _ticket { get; set; }
        string _baseUrl { get; set; }

        private FellowshipOne.Api.People.Sets.People _people;
        public FellowshipOne.Api.People.Sets.People People {
            get {
                if (_people == null) {
                    _people = new People.Sets.People(_ticket, _baseUrl);
                }
                return _people;
            }
        }

        private FellowshipOne.Api.People.Sets.Addresses _addresses;
        public FellowshipOne.Api.People.Sets.Addresses Addresses {
            get {
                if (_addresses == null) {
                    _addresses = new People.Sets.Addresses(_ticket, _baseUrl);
                }
                return _addresses;
            }
        }

        private FellowshipOne.Api.People.Sets.Communications _communications;
        public FellowshipOne.Api.People.Sets.Communications Communications {
            get {
                if (_communications == null) {
                    _communications = new People.Sets.Communications(_ticket, _baseUrl);
                }
                return _communications;
            }
        }

        private FellowshipOne.Api.People.Sets.Households _households;
        public FellowshipOne.Api.People.Sets.Households Households {
            get {
                if (_households == null) {
                    _households = new People.Sets.Households(_ticket, _baseUrl);
                }
                return _households;
            }
        }

        private FellowshipOne.Api.People.Sets.AccessRights _accessRights;
        public FellowshipOne.Api.People.Sets.AccessRights AccessRights
        {
            get
            {
                if (_accessRights == null)
                {
                    _accessRights = new People.Sets.AccessRights(_ticket, _baseUrl);
                }
                return _accessRights;
            }
        }

        private FellowshipOne.Api.People.Sets.Accounts _accounts;
        public FellowshipOne.Api.People.Sets.Accounts Accounts {
            get {
                if (_accounts == null) {
                    _accounts = new People.Sets.Accounts(_ticket, _baseUrl);
                }
                return _accounts;
            }
        }

        private FellowshipOne.Api.People.Sets.AttributeGroups _attributeGroups;
        public FellowshipOne.Api.People.Sets.AttributeGroups AttributeGroups {
            get {
                if (_attributeGroups == null) {
                    _attributeGroups = new People.Sets.AttributeGroups(_ticket, _baseUrl);
                }
                return _attributeGroups;
            }
        }

        private FellowshipOne.Api.People.Sets.Attributes _attributes;
        public FellowshipOne.Api.People.Sets.Attributes Attributes {
            get {
                if (_attributes == null) {
                    _attributes = new People.Sets.Attributes(_ticket, _baseUrl);
                }
                return _attributes;
            }
        }

        private FellowshipOne.Api.People.Sets.Statuses _statuses;
        public FellowshipOne.Api.People.Sets.Statuses Statuses {
            get {
                if (_statuses == null) {
                    _statuses = new People.Sets.Statuses(_ticket, _baseUrl);
                }
                return _statuses;
            }
        }

        private FellowshipOne.Api.People.Sets.Schools _schools;
        public FellowshipOne.Api.People.Sets.Schools Schools {
            get {
                if (_schools == null) {
                    _schools = new People.Sets.Schools(_ticket, _baseUrl);
                }
                return _schools;
            }
        }

        private FellowshipOne.Api.People.Sets.ChurchConfigs _churchConfigs;
        public FellowshipOne.Api.People.Sets.ChurchConfigs ChurchConfigs {
            get {
                if (_churchConfigs == null) {
                    _churchConfigs = new People.Sets.ChurchConfigs(_ticket, _baseUrl);
                }
                return _churchConfigs;
            }
        }

        private FellowshipOne.Api.People.Sets.PeopleAttributes _peopleAttributes;
        public FellowshipOne.Api.People.Sets.PeopleAttributes PeopleAttributes {
            get {
                if (_peopleAttributes == null) {
                    _peopleAttributes = new People.Sets.PeopleAttributes(_ticket, _baseUrl);
                }
                return _peopleAttributes;
            }
        }

        #endregion Properties

        #region Constructor
        public Person(F1OAuthTicket ticket, string baseUrl) {
            _ticket = ticket;
            _baseUrl = baseUrl;
        }
        #endregion Constructor
    }
}