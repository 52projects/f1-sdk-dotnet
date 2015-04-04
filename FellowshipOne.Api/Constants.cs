using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api {
    public static class Constants {
        public static class RequestContentType {
            public const string XML = "application/xml";
            public const string XSD = "application/xsd";
            public const string HELP = "application/help";
            public const string HTML = "text/html";
            public const string JSON = "application/json";
            public const string AUTH = "application/x-www-form-urlencoded";
            public const string UNKNOWN = "unknown";
            public const string NONE = "none";
            public const string JPEG = "image/jpeg";

            public static string ConvertFromQueryString(string qsValue) {
                string rValue = string.Empty;
                //Check to see if a value was passed in
                if (!string.IsNullOrEmpty(qsValue)) {
                    switch (qsValue.ToLower()) {
                        case "json":
                            rValue = JSON;
                            break;
                        case "xml":
                            rValue = XML;
                            break;
                        case "xsd":
                            rValue = XSD;
                            break;
                        case "help":
                            rValue = HELP;
                            break;
                        default:
                            //If there was a value and it did not match any above set request content so that we can return 415 - Unsupported Media Type
                            rValue = UNKNOWN;
                            break;
                    }
                }
                //If no value was passed in then default to XML
                else {
                    rValue = XML;
                }
                return rValue;
            }
        }

        public static class HttpMethods {
            public const string GET = "GET";
            public const string POST = "POST";
            public const string PUT = "PUT";
            public const string DELETE = "DELETE";
            public const string HEAD = "HEAD";
            public const string OPTIONS = "OPTIONS";
            public const string TRACE = "TRACE";
        }

        public const string APIShortDateFormat = @"yyyy-MM-dd";

        public const string APILongDateFormat = @"yyyy-MM-ddTHH:mm:ss";
    }
}
