using System;
using System.Xml;
using System.Xml.Serialization;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.People.Model {
    [Serializable]
    public partial class AccessRight : APIModel {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("accessRightGroup")]
        private ParentNamedObject _accessRightGroup = new ParentNamedObject();
        public ParentNamedObject AccessRightGroup {
            get { return _accessRightGroup; }
            set { _accessRightGroup = value; }
        }
    }
}
