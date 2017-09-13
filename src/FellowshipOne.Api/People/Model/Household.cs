using System;
using System.Xml;
using System.Xml.Serialization;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.People.Model {
    [Serializable]
    [XmlRoot("household")]
    public partial class Household : APIModel {

        private string _oldID = string.Empty;
        [XmlAttribute("oldID")]
        public string OldID {
            get { return _oldID; }
            set { _oldID = value; }
        }

        private string _hcode = string.Empty;
        [XmlAttribute("hCode")]
        public string HCode {
            get { return _hcode; }
            set { _hcode = value; }
        }

        private string _householdName = string.Empty;
        [XmlElement("householdName")]
        public string HouseholdName {
            get { return _householdName; }
            set { _householdName = value; }
        }

        private string _householdSortName = string.Empty;
        [XmlElement("householdSortName")]
        public string HouseholdSortName {
            get { return _householdSortName; }
            set { _householdSortName = value; }
        }

        private string _householdFirstName = string.Empty;
        [XmlElement("householdFirstName")]
        public string HouseholdFirstName {
            get { return _householdFirstName; }
            set { _householdFirstName = value; }
        }

        [XmlElement("lastSecurityAuthorization")]
        public DateTime? LastSecurityAuthorization { get; set; }

        [XmlElement("lastActivityDate")]
        public DateTime? LastActivitydate { get; set; }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }
    }
}