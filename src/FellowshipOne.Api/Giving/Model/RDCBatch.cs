using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Giving.Model {
    [XmlRoot("rdcBatch")]
    public class RDCBatch : APIModel {
        public RDCBatch() {
            this.ParentBatch = new ParentNamedObject();
            this.LastUpdatedByPerson = new ParentObject();
            this.CreatedByPerson = new ParentObject();
        }
        public RDCBatch(int? CreatedByPersonId, int? LastUpdatedByPersonId)
            : this() {
            this.LastUpdatedByPerson.ID = LastUpdatedByPersonId;
            this.CreatedByPerson.ID = CreatedByPersonId;
        }
        #region Properties

        [XmlElement("parentBatch")]
        public ParentNamedObject ParentBatch { get; set; }

        string _name = string.Empty;
        [XmlElement("name")]
        public string Name { get { return _name; } set { _name = value; } }

        string _description = string.Empty;
        [XmlElement("description")]
        public string BatchDescription { get { return _description; } set { _description = value; } }

        [XmlElement("batchCreatedDate")]
        public DateTime BatchCreatedDate { get; set; }

        [XmlElement("currentStatusDateTime")]
        public DateTime? CurrentStatusDateTime { get; set; }

        [XmlElement("itemCount")]
        public int ItemCount { get; set; }

        [XmlElement("batchAmount")]
        public decimal BatchAmount { get; set; }

        string _terminalNumber = string.Empty;
        [XmlElement("terminalNumber")]
        public string TerminalNumber { get { return _terminalNumber; } set { _terminalNumber = value; } }

        [XmlElement("glPostDate")]
        public DateTime? GLPostDate { get; set; }

        [XmlElement("hasMultipleFunds")]
        public bool HasMultipleFunds { get; set; }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("createdByPerson")]
        public ParentObject CreatedByPerson { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }

        [XmlElement("lastUpdatedByPerson")]
        public ParentObject LastUpdatedByPerson { get; set; }

        //[XmlAttribute("activityInstanceID")]
        //public int ActivityInstanceID { get; set; }

        //[XmlAttribute("ppMerchantAccountID")]
        //public int PpMerchantAccountID
        //{
        //    get;
        //    set;
        //}

        //[XmlAttribute("locationID")]
        //public int LocationID
        //{
        //    get;
        //    set;
        //}

        [XmlIgnore]
        public int? ActivityInstanceID {
            get {
                int id = int.MinValue;

                if (int.TryParse(this.activityInstanceIDString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.activityInstanceIDString = value.Value.ToString();
                }
            }
        }

        private string _activityInstanceID = string.Empty;
        [XmlAttribute("activityInstanceID")]
        public string activityInstanceIDString {
            get { return _activityInstanceID; }
            set { _activityInstanceID = value; }
        }





        [XmlIgnore]
        public int? LocationID {
            get {
                int id = int.MinValue;

                if (int.TryParse(this.locationIDIDString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.locationIDIDString = value.Value.ToString();
                }
            }
        }

        private string _locationID = string.Empty;
        [XmlAttribute("locationID")]
        public string locationIDIDString {
            get { return _locationID; }
            set { _locationID = value; }
        }



        [XmlIgnore]
        public int? PPMerchantAccountID {
            get {
                int id = int.MinValue;

                if (int.TryParse(this.ppMerchantAccountIDString, out id)) {
                    return id;
                }

                return null;
            }
            set {
                if (value.HasValue) {
                    this.ppMerchantAccountIDString = value.Value.ToString();
                }
            }
        }

        private string _ppMerchantAccountID = string.Empty;
        [XmlAttribute("ppMerchantAccountID")]
        public string ppMerchantAccountIDString {
            get { return _ppMerchantAccountID; }
            set { _ppMerchantAccountID = value; }
        }





        #endregion Properties
    }
}

