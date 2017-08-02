using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Attributes;

namespace FellowshipOne.Api.Groups.QueryObject {
    public class MemberQO : BaseQO {
        [QO("personid")]
        public string PersonID { get; set; }

        [QO("membertypeid")]
        public string MemberTypeID { get; set; }
    }
}
