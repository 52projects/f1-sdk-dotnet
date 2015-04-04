using System;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.People.Model {

    [Serializable]
    [XmlRoot("address")]
    public partial class Address : APIModel {
        private ParentObject _household = new ParentObject();
        [XmlElement("household")]
        public ParentObject Household {
            get { return _household; }
            set {
                if (value != null) {
                    _household = value;
                }
            }
        }

        private ParentObject _person = new ParentObject();
        [XmlElement("person")]
        public ParentObject Person {
            get { return _person; }
            set {
                if (value != null) {
                    _person = value;
                }
            }
        }

        private ParentNamedObject _addressType = new ParentNamedObject();
        [XmlElement("addressType")]
        public ParentNamedObject AddressType {
            get { return _addressType; }
            set {
                if (value != null) {
                    _addressType = value;
                }
            }
        }

        private string _address1 = string.Empty;
        [XmlElement("address1")]
        public string Address1 {
            get { return _address1; }
            set {
                if (value != null) {
                    _address1 = value;
                }
            }
        }

        private string _address2 = string.Empty;
        [XmlElement("address2")]
        public string Address2 {
            get { return _address2; }
            set {
                if (value != null) {
                    _address2 = value;
                }
            }
        }

        private string _address3 = string.Empty;
        [XmlElement("address3")]
        public string Address3 {
            get { return _address3; }
            set {
                if (value != null) { 
                    _address3 = value; 
                }
            }
        }

        private string _city = string.Empty;
        [XmlElement("city")]
        public string City {
            get { return _city; }
            set {
                if (value != null) {
                    _city = value;
                }
            }
        }

        private string _postalCode = string.Empty;
        [XmlElement("postalCode")]
        public string PostalCode {
            get { return _postalCode; }
            set {
                if (value != null) {
                    _postalCode = value;
                }
            }
        }

        private string _county = string.Empty;
        [XmlElement("county")]
        public string County {
            get { return _county; }
            set {
                if (value != null) {
                    _county = value;
                }
            }
        }

        private string _country = string.Empty;
        [XmlElement("country")]
        public string Country {
            get { return _country; }
            set {
                if (value != null) {
                    _country = value;
                }
            }
        }

        private string _stProvince = string.Empty;
        [XmlElement("stProvince")]
        public string StProvince {
            get { return _stProvince; }
            set {
                if (value != null) {
                    _stProvince = value;
                }
            }
        }

        private string _carrierRoute = string.Empty;
        [XmlElement("carrierRoute")]
        public string CarrierRoute {
            get { return _carrierRoute; }
            set {
                if (value != null) {
                    _carrierRoute = value;
                }
            }
        }

        private string _deliveryPoint = string.Empty;
        [XmlElement("deliveryPoint")]
        public string DeliveryPoint {
            get { return _deliveryPoint; }
            set {
                if (value != null) {
                    _deliveryPoint = value;
                }
            }
        }

        [XmlElement("addressDate")]
        public DateTime? AddressDate { get; set; }

        private string _addressComment = string.Empty;
        [XmlElement("addressComment")]
        public string AddressComment {
            get { return _addressComment; }
            set {
                if (value != null) {
                    _addressComment = value;
                }
            }
        }

        [XmlElement("uspsVerified")]
        public bool UspsVerified { get; set; }

        [XmlElement("addressVerifiedDate")]
        public DateTime? AddressVerifiedDate { get; set; }

        [XmlElement("lastVerificationAttemptDate")]
        public DateTime? LastVerificationAttemptDate { get; set; }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }
    }
}