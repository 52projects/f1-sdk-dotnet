using System;
using System.Xml.Serialization;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.Giving.Model
{
    [XmlRoot("rdcBatchItemDetail")]
    public class RDCBatchItemDetail : APIModel
    {
        public RDCBatchItemDetail() {
            Batch = new ParentNamedObject();
            RDCBatchItem = new ParentObject();
            Fund = new ParentNamedObject();
            SubFund = new ParentNamedObject();
            PledgeDrive = new ParentNamedObject();
            CreatedByPerson = new ParentObject();
            LastUpdatedByPerson = new ParentObject();
        }

        #region Properties

        [XmlElement("batch")]
        public ParentNamedObject Batch { get; set; }

        [XmlElement("rdcBatchItem")]
        public ParentObject RDCBatchItem { get; set; }

        [XmlElement("fund")]
        public ParentNamedObject Fund { get; set; }

        [XmlElement("subFund")]
        public ParentNamedObject SubFund { get; set; }

        [XmlElement("pledgeDrive")]
        public ParentNamedObject PledgeDrive { get; set; }

        [XmlElement("amount")]
        public decimal Amount { get; set; }

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

