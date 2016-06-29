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
    [XmlRoot("member")]
    public partial class Member : APIModel {
        private ParentObject _group = new ParentObject();
        [XmlElement("group")]
        public ParentObject Group {
            get { return _group; }
            set { _group = value; }
        }

        private ParentObject _person = new ParentObject();
        [XmlElement("person")]
        public ParentObject Person {
            get { return _person; }
            set { _person = value; }
        }

        private ParentNamedObject _memberType = new ParentNamedObject();
        [XmlElement("memberType")]
        public ParentNamedObject MemberType {
            get { return this._memberType; }
            set { this._memberType = value; }
        }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }
    }

    [Serializable]
    [XmlRoot("members")]
    public class MemberCollection : Collection<Member> {
        public MemberCollection() { }
        public MemberCollection(List<Member> members) {
            if (members != null) {
                this.AddRange(members);
            }
        }
    }
}
