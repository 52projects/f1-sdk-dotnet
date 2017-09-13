﻿using System;
using System.Xml;
using System.Xml.Serialization;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.People.Model {
    [Serializable]
    public class Occupation : ParentNamedObject {
        private string _description = string.Empty;
        [XmlElement("description")]
        public string Description {
            get { return _description; }
            set { _description = value; }
        }
    }
}
