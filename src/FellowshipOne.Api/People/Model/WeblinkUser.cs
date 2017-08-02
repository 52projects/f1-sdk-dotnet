using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.People.Model {
    [Serializable]
    public class WeblinkUser {
        private string _userID = string.Empty;
        [XmlElement("userID")]
        public string UserID {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _passwordHint = string.Empty;
        [XmlElement("passwordHint")]
        public string PasswordHint {
            get { return _passwordHint; }
            set { _passwordHint = value; }
        }

        private string _passwordAnswer = string.Empty;
        [XmlElement("passwordAnswer")]
        public string PasswordAnswer {
            get { return _passwordAnswer; }
            set { _passwordAnswer = value; }
        }
    }
}
