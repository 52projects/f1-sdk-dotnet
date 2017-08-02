using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Model {
    [Serializable]
    [XmlRoot("results")]
    public class Collection<T> : List<T> {
        [XmlIgnore]
        public string RawResponse { get; set; }

        [XmlAttribute("count")]
        public new int Count { get; set; }

        [XmlAttribute("pageNumber")]
        public int PageNumber { get; set; }

        [XmlAttribute("totalRecords")]
        public int TotalRecords { get; set; }

        [XmlAttribute("additionalPages")]
        public int AdditionalPages { get; set; }
    }
}
