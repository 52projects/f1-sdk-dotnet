using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Exceptions {
    public class BaseException : ApplicationException {
        public BaseException() { }
        public BaseException(string message) : base(message) { }
        public BaseException(string message, Exception inner) : base(message, inner) { }

        #region Properties
        public string RequestUrl { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        #endregion Properties
    }

    public class APIAccessException : BaseException {
        public APIAccessException() { }
        public APIAccessException(string message) : base(message) { }
        public APIAccessException(string message, Exception inner) : base(message, inner) { }
    }
}
