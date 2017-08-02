using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api {
    [Serializable]
    public class F1OAuthTicket : OAuthTicket {
        #region Properties
        public string PersonURL { get; set; }
        public string ChurchCode { get; set; }
        #endregion Properties
    }
}
