using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Giving.Model {
    [XmlRoot("pledgeDrive")]
    public class PledgeDrive : APIModel {
        public PledgeDrive() {
            this.ParentBatch = new ParentNamedObject();
            this.LastUpdatedByPerson = new ParentObject();
            this.CreatedByPerson = new ParentObject();
        }
        public PledgeDrive(int? CreatedByPersonId, int? LastUpdatedByPersonId)
            : this() {
            this.LastUpdatedByPerson.ID = LastUpdatedByPersonId;
            this.CreatedByPerson.ID = CreatedByPersonId;
        }
        #region Properties

        [XmlElement("parentBatch")]
        public ParentNamedObject ParentBatch { get; set; }

        string _name = string.Empty;
        [XmlElement("name")]
        public string Name { get { return _name; } set { _name = value; } }

        [XmlElement("startDate")]
        public DateTime? StartDate { get; set; }

        [XmlElement("endDate")]
        public DateTime? EndDate { get; set; }

        [XmlElement("fund")]
        public ParentNamedObject Fund { get; set; }

        [XmlElement("isWebActive")]
        public bool IsWebActive { get; set; }

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
