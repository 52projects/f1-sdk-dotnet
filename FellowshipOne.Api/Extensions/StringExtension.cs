using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Extensions {
    public static class StringExtension {
        public static string HtmlEncode(this string s) {
            return System.Web.HttpUtility.HtmlEncode(s);
        }

        public static string HtmlDecode(this string s) {
            return System.Web.HttpUtility.HtmlDecode(s);
        }

        public static string UrlEncode(this string s) {
            return System.Web.HttpUtility.UrlEncode(s);
        }

        public static string UrlDecode(this string s) {
            return System.Web.HttpUtility.UrlDecode(s);
        }
    }
}
