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
    [XmlRoot("attribute")]
    public partial class PersonAttribute : APIModel {

        #region Constructor
        public PersonAttribute() {
        }
        #endregion Constructor

        #region Public Properties
        [XmlElement("person")]
        public PersonAttributePerson Person { get; set; }

        [XmlElement("attributeGroup")]
        public PersonAttributeGroup AttributeGroup { get; set; }

        private string _startDateString = string.Empty;
        [XmlElement("startDate")]
        public string StartDateString {
            get {
                if (!string.IsNullOrEmpty(_startDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_startDateString, out dt)) {
                        _startDateString = dt.ToString("s");
                    }
                }

                return _startDateString; 
            }
            set {
                if (value != null) {
                    _startDateString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? StartDate {
            get {
                DateTime dateOfBirth = DateTime.MinValue;

                if (DateTime.TryParse(_startDateString, out dateOfBirth)) {
                    return dateOfBirth;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _startDateString = value.Value.ToString();
                }
                else {
                    _startDateString = string.Empty;
                }
            }
        }

        private string _endDateString = string.Empty;
        [XmlElement("endDate")]
        public string EndDateString {
            get {
                if (!string.IsNullOrEmpty(_endDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_endDateString, out dt)) {
                        _endDateString = dt.ToString("s");
                    }
                }

                return _endDateString;
            }
            set {
                if (value != null) {
                    _endDateString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? EndDate {
            get {
                DateTime date = DateTime.MinValue;

                if (DateTime.TryParse(_endDateString, out date)) {
                    return date;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _endDateString = value.Value.ToString();
                }
                else {
                    _endDateString = string.Empty;
                }
            }
        }

        private string _comment = string.Empty;
        [XmlElement("comment")]
        public string Comment {
            get {
                return _comment;
            }
            set {
                _comment = value;
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
        public DateTime? CreatedDate {
            get {
                DateTime date = DateTime.MinValue;

                if (DateTime.TryParse(_createdDateString, out date)) {
                    return date;
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

        private string _lastupdatedDateString = string.Empty;
        [XmlElement("lastUpdatedDate")]
        public string LastUpdatedDateString {
            get {
                if (!string.IsNullOrEmpty(_lastupdatedDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_lastupdatedDateString, out dt)) {
                        _lastupdatedDateString = dt.ToString("s");
                    }
                }

                return _lastupdatedDateString;
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
                DateTime date = DateTime.MinValue;

                if (DateTime.TryParse(_lastupdatedDateString, out date)) {
                    return date;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _lastupdatedDateString = value.Value.ToString();
                }
                else {
                    _lastupdatedDateString = string.Empty;
                }
            }
        }
        #endregion Public Properties
    }

    [XmlRoot("person")]
    public class PersonAttributePerson : APIModel {
    }

    [XmlRoot("attributeGroup")]
    public class PersonAttributeGroup : APIModel {
        private string _name = string.Empty;
        [XmlElement("name")]
        public string Comment {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }

        [XmlElement("attribute")]
        public ParentNamedObject Attribute { get; set; }
    }
}