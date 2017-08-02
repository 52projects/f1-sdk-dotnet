using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Giving.Model {
    [XmlRoot("fund")]
    public class Fund : APIModel {

        public Fund() {
            this.FundType = new ParentNamedObject();
            this.LastUpdatedByPerson = new ParentObject();
            this.CreatedByPerson = new ParentObject();
        }
        public Fund(int? CreatedByPersonId, int? LastUpdatedByPersonId)
            : this() {
            this.LastUpdatedByPerson.ID = LastUpdatedByPersonId;
            this.CreatedByPerson.ID = CreatedByPersonId;
        }
        #region Properties

        string _name = string.Empty;
        [XmlElement("name")]
        public string Name { get { return _name; } set { _name = value; } }

        [XmlElement("fundType")]
        public ParentNamedObject FundType { get; set; }

        string _fundCode = string.Empty;
        [XmlElement("fundCode")]
        public string FundCode { get { return _fundCode; } set { _fundCode = value; } }
        [XmlElement("isWebActive")]
        public bool IsWebActive { get; set; }

        [XmlElement("isActive")]
        public bool IsActive { get; set; }

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
