using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Restify.Attributes;

namespace FellowshipOne.Api.QueryObject {
    public abstract class BaseQO : Restify.QueryObject {
        [QO("page")]
        public int? PageNumber { get; set; }

        [QO("recordsPerPage")]
        public int? RecordsPerPage { get; set; }
    }
}