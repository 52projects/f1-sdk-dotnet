using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.People.Model {
    [Serializable]
    [XmlRoot("communication")]
    public partial class Communication : APIModel {

        private ParentObject _household = new ParentObject();
        [XmlElement("household")]
        public ParentObject Household {
            get { return _household; }
            set { _household = value; }
        }

        private ParentObject _person = new ParentObject();
        [XmlElement("person")]
        public ParentObject Person {
            get { return _person; }
            set { _person = value; }
        }

        private ParentNamedObject _communicationType = new ParentNamedObject();
        [XmlElement("communicationType")]
        public ParentNamedObject CommunicationType {
            get { return this._communicationType; }
            set { this._communicationType = value; }
        }

        private string _communicationGeneralType = string.Empty;
        [XmlElement("communicationGeneralType")]
        public string CommunicationGeneralType {
            get { return this._communicationGeneralType; }
            set { this._communicationGeneralType = value; }
        }

        [XmlElement("communicationValue")]
        public string CommunicationValue { get; set; }

        private string _searchCommunicationValue = string.Empty;
        [XmlElement("searchCommunicationValue")]
        public string SearchCommunicationValue {
            get { return this._searchCommunicationValue; }
            set { this._searchCommunicationValue = value; }
        }

        [XmlElement("preferred")]
        public bool Preferred { get; set; }

        private string _communicationComment = string.Empty;
        [XmlElement("communicationComment")]
        public string CommunicationComment {
            get { return this._communicationComment; }
            set { this._communicationComment = value; }
        }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }
    }
}