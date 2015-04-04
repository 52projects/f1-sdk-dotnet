using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Giving.Model {
    [XmlRoot("contributionReceipt")]
    public class ContributionReceipt : APIModel {

        #region Constructor
        public ContributionReceipt() {
            this.Fund = new ParentNamedObject();
            this.SubFund = new ParentNamedObject();
            this.PledgeDrive = new ParentNamedObject();
            this.Household = new ParentObject();
            this.Person = new ParentObject();
            this.Account = new ParentObject();
            this.ReferenceImage = new ParentObject();
            this.Batch = new ParentNamedObject();
            this.ActivityInstance = new ParentObject();
            this.ContributionType = new ParentNamedObject();
            this.ContributionSubType = new ParentNamedObject();
            this.CreatedByPerson = new ParentObject();
            this.LastUpdatedByPerson = new ParentObject();
        }
        #endregion Constructor

        #region Properties
        private string _accountReference = string.Empty;
        [XmlElement("accountReference")]
        public string AccountReference { get { return _accountReference; } set { _accountReference = value; } }

        [XmlElement("amount")]
        public decimal Amount { get; set; }

        [XmlElement("fund")]
        public ParentNamedObject Fund { get; set; }

        [XmlElement("subFund")]
        public ParentNamedObject SubFund { get; set; }

        [XmlElement("pledgeDrive")]
        public ParentNamedObject PledgeDrive { get; set; }

        [XmlElement("household")]
        public ParentObject Household { get; set; }

        [XmlElement("person")]
        public ParentObject Person { get; set; }

        [XmlElement("account")]
        public ParentObject Account { get; set; }

        [XmlElement("referenceImage")]
        public ParentObject ReferenceImage { get; set; }

        [XmlElement("batch")]
        public ParentNamedObject Batch { get; set; }

        [XmlElement("activityInstance")]
        public ParentObject ActivityInstance { get; set; }

        [XmlElement("contributionType")]
        public ParentNamedObject ContributionType { get; set; }

        [XmlElement("contributionSubType")]
        public ParentNamedObject ContributionSubType { get; set; }

        [XmlIgnore]
        public DateTime? ReceivedDate {
            get {
                DateTime receivedDate = DateTime.MinValue;

                if (DateTime.TryParse(_receivedDateString, out receivedDate)) {
                    return receivedDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _receivedDateString = value.Value.ToString();
                }
                else {
                    _receivedDateString = string.Empty;
                }
            }
        }

        private string _receivedDateString = string.Empty;
        [XmlElement("receivedDate")]
        public string ReceivedDateString {
            get {
                if (!string.IsNullOrEmpty(_receivedDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_receivedDateString, out dt)) {
                        _receivedDateString = dt.ToString("s");
                    }
                }

                return _receivedDateString;
            }
            set {
                if (value != null) {
                    _receivedDateString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? TransmitDate {
            get {
                DateTime transmitDate = DateTime.MinValue;

                if (DateTime.TryParse(_transmitDateString, out transmitDate)) {
                    return transmitDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _transmitDateString = value.Value.ToString();
                }
                else {
                    _transmitDateString = string.Empty;
                }
            }
        }

        private string _transmitDateString = string.Empty;
        [XmlElement("transmitDate")]
        public string TransmitDateString {
            get {
                if (!string.IsNullOrEmpty(_transmitDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_transmitDateString, out dt)) {
                        _transmitDateString = dt.ToString("s");
                    }
                }

                return _transmitDateString;
            }
            set {
                if (value != null) {
                    _transmitDateString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? ReturnDate {
            get {
                DateTime returnDate = DateTime.MinValue;

                if (DateTime.TryParse(_returnDateString, out returnDate)) {
                    return returnDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _returnDateString = value.Value.ToString();
                }
                else {
                    _returnDateString = string.Empty;
                }
            }
        }

        private string _returnDateString = string.Empty;
        [XmlElement("returnDate")]
        public string ReturnDateString {
            get {
                if (!string.IsNullOrEmpty(_returnDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_returnDateString, out dt)) {
                        _returnDateString = dt.ToString("s");
                    }
                }

                return _returnDateString;
            }
            set {
                if (value != null) {
                    _returnDateString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? RetransmitDate {
            get {
                DateTime retransmitDate = DateTime.MinValue;

                if (DateTime.TryParse(_retransmitDateString, out retransmitDate)) {
                    return retransmitDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _retransmitDateString = value.Value.ToString();
                }
                else {
                    _retransmitDateString = string.Empty;
                }
            }
        }

        private string _retransmitDateString = string.Empty;
        [XmlElement("retransmitDate")]
        public string RetransmitDateString {
            get {
                if (!string.IsNullOrEmpty(_retransmitDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_retransmitDateString, out dt)) {
                        _retransmitDateString = dt.ToString("s");
                    }
                }

                return _retransmitDateString;
            }
            set {
                if (value != null) {
                    _retransmitDateString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? GLPostDate {
            get {
                DateTime glPostDate = DateTime.MinValue;

                if (DateTime.TryParse(_glPostDateString, out glPostDate)) {
                    return glPostDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _glPostDateString = value.Value.ToString();
                }
                else {
                    _glPostDateString = string.Empty;
                }
            }
        }

        private string _glPostDateString = string.Empty;
        [XmlElement("glPostDate")]
        public string GLPostDateString {
            get {
                if (!string.IsNullOrEmpty(_glPostDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_glPostDateString, out dt)) {
                        _glPostDateString = dt.ToString("s");
                    }
                }

                return _glPostDateString;
            }
            set {
                if (value != null) {
                    _glPostDateString = value;
                }
            }
        }

        [XmlElement("isSplit")]
        public bool IsSplit { get; set; }

        [XmlElement("addressVerification")]
        public bool AddressVerification { get; set; }

        private string _memo = string.Empty;
        [XmlElement("memo")]
        public string Memo { get { return _memo; } set { _memo = value; } }

        [XmlIgnore]
        public decimal? StatedValue {
            get {
                decimal id = decimal.MinValue;

                if (decimal.TryParse(this.StatedValueString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.StatedValueString = value.Value.ToString();
                }
            }
        }

        private string _statedValue = string.Empty;
        [XmlElement("statedValue")]
        public string StatedValueString {
            get { return _statedValue; }
            set { _statedValue = value; }
        }

        [XmlIgnore]
        public decimal? TrueValue {
            get {
                decimal id = decimal.MinValue;

                if (decimal.TryParse(this.TrueValueString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.TrueValueString = value.Value.ToString();
                }
            }
        }

        private string _trueValue = string.Empty;
        [XmlElement("trueValue")]
        public string TrueValueString {
            get { return _trueValue; }
            set { _trueValue = value; }
        }

        [XmlElement("thank")]
        public bool Thank { get; set; }

        [XmlIgnore]
        public DateTime? ThankedDate {
            get {
                DateTime thankedDate = DateTime.MinValue;

                if (DateTime.TryParse(_thankedDateString, out thankedDate)) {
                    return thankedDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _thankedDateString = value.Value.ToString();
                }
                else {
                    _thankedDateString = string.Empty;
                }
            }
        }

        private string _thankedDateString = string.Empty;
        [XmlElement("thankedDate")]
        public string ThankedDateString {
            get {
                if (!string.IsNullOrEmpty(_thankedDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_thankedDateString, out dt)) {
                        _thankedDateString = dt.ToString("s");
                    }
                }

                return _thankedDateString;
            }
            set {
                if (value != null) {
                    _thankedDateString = value;
                }
            }
        }

        [XmlIgnore]
        public int? IsMatched {
            get {
                int id = int.MinValue;

                if (int.TryParse(this.IsMatchedString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.IsMatchedString = value.Value.ToString();
                }
            }
        }

        private string _isMatchedString = string.Empty;
        [XmlElement("isMatched")]
        public string IsMatchedString {
            get { return _isMatchedString; }
            set { _isMatchedString = value; }
        }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("createdByPerson")]
        public ParentObject CreatedByPerson { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }

        [XmlElement("lastUpdatedByPerson")]
        public ParentObject LastUpdatedByPerson { get; set; }

        #endregion Properties
    }
}
