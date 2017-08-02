using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Groups.Model {
    [Serializable]
    [XmlRoot("group")]
    public class Group : APIModel {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("startDate")]
        public DateTime? StartDate { get; set; }
        [XmlElement("expirationDate")]
        public DateTime? ExpirationDate { get; set; }
        [XmlElement("isOpen")]
        public bool IsOpen { get; set; }
        [XmlElement("isPublic")]
        public bool IsPublic { get; set; }
        [XmlElement("hasChildCare")]
        public bool HasChildCare { get; set; }
        [XmlElement("isSearchable")]
        public bool IsSearchable { get; set; }
        [XmlElement("churchCampus")]
        public ParentNamedObject ChurchCampus { get; set; }
        [XmlElement("groupType")]
        public ParentNamedObject GroupType { get; set; }
        [XmlElement("timeZone")]
        public ParentNamedObject TimeZone { get; set; }
        [XmlElement("gender")]
        public ParentNamedObject Gender { get; set; }
        [XmlElement("maritalStatus")]
        public ParentNamedObject MaritalStatus { get; set; }
        [XmlElement("dateRangeType")]
        public ParentNamedObject DateRangeType { get; set; }
        [XmlElement("leadersCount")]
        public int LeadersCount { get; set; }
        [XmlElement("membersCount")]
        public int MembersCount { get; set; }
        [XmlElement("openProspectsCount")]
        public int OpenProspectsCount { get; set; }

        [XmlElement("event")]
        public ParentNamedObject Event { get; set; }

        [XmlIgnore]
        public DateTime? CreatedDate {
            get {
                DateTime createdDate = DateTime.MinValue;

                if (DateTime.TryParse(_createdDateString, out createdDate)) {
                    return createdDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _createdDateString = value.Value.ToString();
                }
                else {
                    _createdDateString = string.Empty;
                }
            }
        }

        private string _createdDateString = string.Empty;
        [XmlElement("createdDate")]
        public string CreatedDateString {
            get {
                if (!string.IsNullOrEmpty(_createdDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_createdDateString, out dt)) {
                        _createdDateString = dt.ToString("s");
                    }
                }

                return _createdDateString;
            }
            set {
                if (value != null) {
                    _createdDateString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? LastUpdatedDate {
            get {
                DateTime lastUpdatedDate = DateTime.MinValue;

                if (DateTime.TryParse(_lastUpdatedDateString, out lastUpdatedDate)) {
                    return lastUpdatedDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _lastUpdatedDateString = value.Value.ToString();
                }
                else {
                    _lastUpdatedDateString = string.Empty;
                }
            }
        }

        private string _lastUpdatedDateString = string.Empty;
        [XmlElement("lastUpdatedDate")]
        public string LastUpdatedDateString {
            get {
                if (!string.IsNullOrEmpty(_lastUpdatedDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_lastUpdatedDateString, out dt)) {
                        _lastUpdatedDateString = dt.ToString("s");
                    }
                }

                return _lastUpdatedDateString;
            }
            set {
                if (value != null) {
                    _lastUpdatedDateString = value;
                }
            }
        }
    }

    [Serializable]
    [XmlRoot("groups")]
    public class GroupCollection : Collection<Group> {
        public GroupCollection() { }
        public GroupCollection(List<Group> groups) {
            if (groups != null) {
                this.AddRange(groups);
            }
        }
    }
}
