using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Model {
    public class F1Collection<T> {
        public F1Collection() {
            this.Items = new List<T>();
        }

        [XmlIgnore]
        public string RawResponse { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public List<T> Items { get; set; }
    }
}
