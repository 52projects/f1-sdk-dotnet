using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.People.Model {
    [Serializable]
    [XmlRoot("attributeGroup")]
    public class AttributeGroup : ParentNamedObject {
        [XmlArrayItem(ElementName = "attribute", Type = typeof(Attribute))]
        public List<Attribute> Attributes { get; set; }
    }
}
