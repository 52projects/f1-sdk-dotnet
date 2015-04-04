using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.Giving.Model
{
    [Serializable]
    [XmlRoot("rdcBatchItem")]
    [XmlType("rdcBatchItem")]
    public class RDCBatchItem : APIModel
    {
        public RDCBatchItem() {
            Batch = new ParentNamedObject();
            OriginalHousehold = new ParentObject();
            OriginalIndividual = new ParentObject();
            Household = new ParentObject();
            Individual = new ParentObject();
            ReferenceImage = new ParentObject();
            CreatedByPerson = new ParentObject();
            LastUpdatedByPerson = new ParentObject();
            RDCBatchItemDetails = new List<RDCBatchItemDetail>();
            ReturnDate = string.Empty;
            IsSharedAccount = false;
            Thank = false;
        }

        #region Properties

        [XmlElement("batch")]
        public ParentNamedObject Batch { get; set; }

        [XmlElement("originalHousehold")]
        public ParentObject OriginalHousehold { get; set; }

        [XmlElement("originalIndividual")]
        public ParentObject OriginalIndividual { get; set; }

        [XmlElement("household")]
        public ParentObject Household { get; set; }

        [XmlElement("individual")]
        public ParentObject Individual { get; set; }

        [XmlElement("itemCreatedDate")]
        public DateTime? ItemCreatedDate { get; set; }

        string _accountNumber = string.Empty;
        [XmlElement("accountNumber")]
        public string AccountNumber { get { return _accountNumber; } set { _accountNumber = value; } }

        string _routingNumber = string.Empty;
        [XmlElement("routingNumber")]
        public string RoutingNumber { get { return _routingNumber; } set { _routingNumber = value; } }

        [XmlElement("amount")]
        public decimal Amount { get; set; }

        string _nameOnAccount = string.Empty;
        [XmlElement("nameOnAccount")]
        public string NameOnAccount { get { return _nameOnAccount; } set { _nameOnAccount = value; } }
        
        string _itemDescription = string.Empty;
        [XmlElement("itemDescription")]
        public string ItemDescription { get { return _itemDescription; } set { _itemDescription = value; } }

        string _customField1 = string.Empty;
        [XmlElement("customField1")]
        public string CustomField1 { get { return _customField1; } set { _customField1 = value; } }

        string _customField2 = string.Empty;
        [XmlElement("customField2")]
        public string CustomField2 { get { return _customField2; } set { _customField2 = value; } }
       
        string _customField3 = string.Empty;
        [XmlElement("customField3")]
        public string CustomField3 { get { return _customField3; } set { _customField3 = value; } }

        string _referenceNumber = string.Empty;
        [XmlElement("referenceNumber")]
        public string ReferenceNumber { get { return _referenceNumber; } set { _referenceNumber = value; } }

        string _checkNumber = string.Empty;
        [XmlElement("checkNumber")]
        public string CheckNumber { get { return _checkNumber; } set { _checkNumber = value; } }

        string _transactionNumber = string.Empty;
        [XmlElement("transactionNumber")]
        public string TransactionNumber { get { return _transactionNumber; } set { _transactionNumber = value; } }

        [XmlElement("referenceImage")]
        public ParentObject ReferenceImage { get; set; }

        [XmlIgnore]
        public int? ReferenceImageID {
            get {
                int id = int.MinValue;

                if (int.TryParse(this.ppMerchantAccountIDString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.ppMerchantAccountIDString = value.Value.ToString();
                }
            }
        }

        //private string _referenceImageID = string.Empty;
        //[XmlAttribute("referenceImageID")]
        //public string ReferenceImageIDString {
        //    get { return _referenceImageID; }
        //    set { _referenceImageID = value; }
        //}

        [XmlElement("returnDate")]
        public string ReturnDate { get; set; }

        [XmlElement("isSharedAccount")]
        public bool? IsSharedAccount { get; set; }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("createdByPerson")]
        public ParentObject CreatedByPerson { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }

        [XmlElement("lastUpdatedByPerson")]
        public ParentObject LastUpdatedByPerson { get; set; }

        [XmlElement("thank")]
        public bool? Thank { get; set; }

        [XmlArray("rdcBatchItemDetails", IsNullable = true)]
        public List<RDCBatchItemDetail> RDCBatchItemDetails { get; set; }

        private ParentNamedObject _contributionType = new ParentNamedObject();
        [XmlElement("contributionType")]
        public ParentNamedObject ContributionType {
            get { return _contributionType; }
            set { _contributionType = value; }
        }

        [XmlIgnore]
        public int? PPMerchantAccountID
        {
            get
            {
                int id = int.MinValue;

                if (int.TryParse(this.ppMerchantAccountIDString, out id))
                {
                    return id;
                }

                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    this.ppMerchantAccountIDString = value.Value.ToString();
                }
            }
        }

        private string _ppMerchantAccountID = string.Empty;
        [XmlAttribute("ppMerchantAccountID")]
        public string ppMerchantAccountIDString
        {
            get { return _ppMerchantAccountID; }
            set { _ppMerchantAccountID = value; }
        }
       
        [XmlIgnore]
        public int? LocationID {
            get {
                int id = int.MinValue;

                if (int.TryParse(this.locationIDIDString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.locationIDIDString = value.Value.ToString();
                }
            }
        }

        private string _locationID = string.Empty;
        [XmlAttribute("locationID")]
        public string locationIDIDString {
            get { return _locationID; }
            set { _locationID = value; }
        }
       
        #endregion Properties
    }
    
    [Serializable]
    [XmlRoot("rdcBatchItems")]
    public class RDCBatchItemCollection : List<RDCBatchItem> {
        public RDCBatchItemCollection() { }
        public RDCBatchItemCollection(List<RDCBatchItem> rdcBatchItems) {
            if (rdcBatchItems != null) {
                AddRange(rdcBatchItems);
            }
        }
    }
}

