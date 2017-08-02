using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Giving.Model {
    [XmlRoot("batch")]
    public class Batch : APIModel {
        public Batch()
        {
            this.BatchType = new ParentNamedObject();
            this.BatchStatus = new ParentNamedObject();
            this.CreatedByPerson = new ParentObject();
            this.LastUpdatedByPerson = new ParentObject();
        }
        public Batch(int batchTypeId, int batchStatusId) : this()
        {
            BatchType.ID = batchTypeId;
            BatchStatus.ID = batchStatusId;
        }
        #region Properties
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("amount")]
        public decimal Amount { get; set; }

        [XmlElement("batchType")]
        public ParentNamedObject BatchType { get; set; }

        [XmlElement("batchStatus")]
        public ParentNamedObject BatchStatus { get; set; }

        [XmlElement("batchDate")]
        public DateTime? BatchDate { get; set; }

        [XmlElement("receivedDate")]
        public DateTime? ReceivedDate { get; set; }

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
