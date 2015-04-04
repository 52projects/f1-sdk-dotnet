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
    [XmlRoot("person")]
    public partial class Person : APIModel {

        #region Constructor
        public Person() {
            Addresses = new List<Address>();
            Communications = new List<Communication>();
            Status = new Status();
            HouseholdMemberType = new ParentNamedObject();

            Title = string.Empty;
            Salutation = string.Empty;
            Prefix = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Suffix = string.Empty;
            MiddleName = string.Empty;
            GoesByName = string.Empty;
            FormerName = string.Empty;
            Gender = string.Empty;
            MaritalStatus = string.Empty;
            FormerChurch = string.Empty;
            BarCode = string.Empty;
            MemberEnvelopeCode = string.Empty;
            DefaultTagComment = string.Empty;
            Employer = string.Empty;
        }
        #endregion Constructor

        #region Public Properties
        [XmlAttribute("imageURI")]
        public string ImageURI {
            get;
            set;
        }

        [XmlAttribute("oldID")]
        public string OldID {
            get;
            set;
        }

        [XmlAttribute("iCode")]
        public string ICode {
            get;
            set;
        }

        [XmlIgnore]
        public int? HouseholdID {
            get {
                int id = int.MinValue;

                if (int.TryParse(this.HouseholdIDString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.HouseholdIDString = value.Value.ToString();
                }
            }
        }

        private string _householID = string.Empty;
        [XmlAttribute("householdID")]
        public string HouseholdIDString {
            get { return _householID; }
            set { _householID = value; }
        }

        [XmlAttribute("oldHouseholdID")]
        public string OldHouseholdID {
            get;
            set;
        }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("salutation")]
        public string Salutation { get; set; }

        [XmlElement("prefix")]
        public string Prefix { get; set; }

        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("suffix")]
        public string Suffix { get; set; }

        [XmlElement("middleName")]
        public string MiddleName { get; set; }

        [XmlElement("goesByName")]
        public string GoesByName { get; set; }

        [XmlElement("formerName")]
        public string FormerName { get; set; }

        [XmlElement("gender")]
        public string Gender { get; set; }

        private string _dateOfBirthString = string.Empty;
        [XmlElement("dateOfBirth")]
        public string DateOfBirthString {
            get {
                if (!string.IsNullOrEmpty(_dateOfBirthString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_dateOfBirthString, out dt)) {
                        _dateOfBirthString = dt.ToString("s");
                    }
                }

                return _dateOfBirthString; 
            }
            set {
                if (value != null) {
                    _dateOfBirthString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? DateOfBirth {
            get {
                DateTime dateOfBirth = DateTime.MinValue;

                if (DateTime.TryParse(_dateOfBirthString, out dateOfBirth)) {
                    return dateOfBirth;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _dateOfBirthString = value.Value.ToString();
                }
                else {
                    _dateOfBirthString = string.Empty;
                }
            }
        }

        [XmlElement("maritalStatus")]
        public string MaritalStatus { get; set; }

        private ParentNamedObject _householdMemberType = new ParentNamedObject();
        [XmlElement("householdMemberType")]
        public ParentNamedObject HouseholdMemberType {
            get { return _householdMemberType; }
            set { _householdMemberType = value; }
        }

        private bool _isAuthorized = true;
        [XmlElement("isAuthorized")]
        public bool IsAuthorized {
            get {
                return _isAuthorized;
            }
            set {
                _isAuthorized = value;
            }
        }

        private Status _status = new Status();
        [XmlElement("status")]
        public Status Status {
            get { return _status; }
            set { _status = value; }
        }

        private Occupation _occupation = new Occupation();
        [XmlElement("occupation")]
        public Occupation Occupation {
            get { return _occupation; }
            set { _occupation = value; }
        }

        [XmlElement("employer")]
        public string Employer { get; set; }

        private ParentNamedObject _school = new ParentNamedObject();
        [XmlElement("school")]
        public ParentNamedObject School {
            get { return _school; }
            set { _school = value; }
        }

        private ParentNamedObject _denomination = new ParentNamedObject();
        [XmlElement("denomination")]
        public ParentNamedObject Denomination {
            get { return _denomination; }
            set { _denomination = value; }
        }

        [XmlElement("formerChurch")]
        public string FormerChurch { get; set; }

        [XmlElement("barCode")]
        public string BarCode { get; set; }

        [XmlElement("memberEnvelopeCode")]
        public string MemberEnvelopeCode { get; set; }

        [XmlElement("defaultTagComment")]
        public string DefaultTagComment { get; set; }

        private WeblinkUser _weblink = new WeblinkUser();
        [XmlElement("weblink")]
        public WeblinkUser Weblink {
            get { return _weblink; }
            set { _weblink = value; }
        }

        [XmlIgnore]
        public bool? Solicit {
            get {
                bool solicit = false;

                if (bool.TryParse(_solicitString, out solicit)) {
                    return solicit;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.SolicitString = value.Value.ToString();
                }
                else {
                    this.SolicitString = string.Empty;
                }
            }
        }

        private string _solicitString = string.Empty;
        [XmlElement("solicit")]
        public string SolicitString {
            get { return _solicitString.ToLower(); }
            set {
                if (value != null) {
                    _solicitString = value;
                }
            }
        }

        [XmlIgnore]
        public bool? Thank {
            get {
                bool thank = false;

                if (bool.TryParse(_thankString, out thank)) {
                    return thank;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _thankString = value.Value.ToString();
                }
                else {
                    _thankString = string.Empty;
                }
            }
        }

        private string _thankString = string.Empty;
        [XmlElement("thank")]
        public string ThankString {
            get { return _thankString.ToLower(); }
            set {
                if (value != null) {
                    _thankString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? FirstRecord {
            get {
                DateTime firstRecord = DateTime.MinValue;

                if (DateTime.TryParse(_firstRecordString, out firstRecord)) {
                    return firstRecord;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _firstRecordString = value.Value.ToString();
                }
                else {
                    _firstRecordString = string.Empty;
                }
            }
        }

        private string _firstRecordString = string.Empty;
        [XmlElement("firstRecord")]
        public string FirstRecordString {
            get {
                if (!string.IsNullOrEmpty(_firstRecordString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_firstRecordString, out dt)) {
                        _firstRecordString = dt.ToString("s");
                    }
                }

                return _firstRecordString; 
            }
            set {
                if (value != null) {
                    _firstRecordString = value;
                }
            }
        }

        [XmlIgnore]
        public DateTime? LastMatchDate {
            get {
                DateTime lastMatchDate = DateTime.MinValue;

                if (DateTime.TryParse(_lastMatchDateString, out lastMatchDate)) {
                    return lastMatchDate;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    _lastMatchDateString = value.Value.ToString();
                }
                else {
                    _lastMatchDateString = string.Empty;
                }
            }
        }

        private string _lastMatchDateString = string.Empty;
        [XmlElement("lastMatchDate")]
        public string LastMatchDateString {
            get {
                if (!string.IsNullOrEmpty(_lastMatchDateString)) {
                    DateTime dt = DateTime.Now;

                    if (DateTime.TryParse(_lastMatchDateString, out dt)) {
                        _lastMatchDateString = dt.ToString("s");
                    }
                }

                return _lastMatchDateString; 
            }
            set {
                if (value != null) {
                    _lastMatchDateString = value;
                }
            }
        }

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

        [XmlElement("addresses")]
        public List<Address> Addresses { get; set; }

        [XmlElement("communications")]
        public List<Communication> Communications { get; set; }

        #endregion Public Properties
    }

    [Serializable]
    [XmlRoot("results")]
    public class PersonCollection : Collection<Person> {
        public  PersonCollection() { }
        public PersonCollection(List<Person> people) {
            if (people != null) {
                this.AddRange(people);
            }
        }
    }
}