using FellowshipOne.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FellowshipOne.Api.People.Model {
    public class ChurchConfig : APIModel {
        
        [XmlElement("cultureInfo")]
        public string CultureInfo { get; set; }

        [XmlElement("defaultCountry")]
        public string DefaultCountry { get; set; }

        [XmlElement("defaultCurrency")]
        public string DefaultCurrency { get; set; }

        private TimeZone _timezone = new TimeZone();
        [XmlElement("timezone")]
        public TimeZone Timezone {
            get { return this._timezone; }
            set { this._timezone = value; }
        }

        [XmlElement("timeFormat")]
        public string TimeFormat { get; set; }

        [XmlElement("monthDayPattern")]
        public string MonthDayPattern { get; set; }
    }
}
