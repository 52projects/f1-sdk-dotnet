using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Giving.Model {
    [XmlRoot("subFund")]
    public class SubFund : APIModel {
        [XmlElement("parentFund")]
        public ParentNamedObject ParentFund { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("generalLedger")]
        public string GeneralLedger { get; set; }

        [XmlElement("subFundCode")]
        public string SubFundCode { get; set; }

        [XmlElement("isWebEnabled")]
        public string IsWebEnabled { get; set; }

        [XmlElement("isActive")]
        public string IsActive { get; set; }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("createdByPerson")]
        public ParentObject CreatedByPerson { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }

        [XmlElement("lastUpdatedByPerson")]
        public ParentObject LastUpdatedByPerson { get; set; }
    }
}
