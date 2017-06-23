using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Groups.Model {
    [Serializable]
    [XmlRoot("groupType")]
    public class GroupType : APIModel {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("isWebEnabled")]
        public bool IsWebEnabled { get; set; }
        [XmlElement("isSearchable")]
        public bool IsSearchable { get; set; }
        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }
    }
}
