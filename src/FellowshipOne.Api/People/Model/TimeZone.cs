using System;
using System.Xml.Serialization;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.People.Model {
    [Serializable]
    public class TimeZone : ParentNamedObject {
        private string _bias = string.Empty;
        [XmlElement("bias")]
        public string Bias {
            get { return _bias; }
            set { _bias = value; }
        }
    }
}
