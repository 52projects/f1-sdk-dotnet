using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.People.Model {
    [Serializable]
    [XmlRoot("status")]
    public class Status : ParentNamedObject {
        private string _comment = string.Empty;

        [XmlElement("comment")]
        public string Comment {
            get { return _comment; }
            set { _comment = value; }
        }

        private string _dateString = string.Empty;
        [XmlElement("date")]
        public string DateString {
            get {
                if (!string.IsNullOrEmpty(_dateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_dateString, out dt)) {
                        _dateString = dt.ToString("s");
                    }
                }

                return _dateString;
            }
            set {
                if (value != null) {
                    _dateString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? Date {
            get {
                DateTime date = DateTime.MinValue;

                if (DateTime.TryParse(_dateString, out date)) {
                    return date;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _dateString = value.Value.ToString();
                }
                else {
                    _dateString = string.Empty;
                }
            }
        }
        

        private SubStatus _subStatus = new SubStatus();
        [XmlElement("subStatus")]
        public SubStatus SubStatus {
            get {
                return _subStatus;
            }
            set {
                _subStatus = value;
            }
        }

        private List<SubStatus> _subStatuses = new List<SubStatus>();
        [XmlArrayItem(ElementName="subStatus", Type=typeof(SubStatus))]
        public List<SubStatus> SubStatuses {
            get { return _subStatuses; }
            set { _subStatuses = value; }
        }
    }

    [Serializable]
    [XmlRoot("subStatus")]
    public class SubStatus : ParentNamedObject {
    }
}
