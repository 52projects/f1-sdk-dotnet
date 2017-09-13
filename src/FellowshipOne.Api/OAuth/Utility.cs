using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace FellowshipOne.Api.OAuth {
    public static class Utility {
        public delegate byte[] HashFunction(byte[] key, byte[] buffer);

        private static readonly Random random = new Random();
        public static HashFunction ComputeHash { private get; set; }

        static string GenerateSignature(string consumerSecret, Uri uri, HttpMethod method, Token token, IEnumerable<KeyValuePair<string, string>> parameters) {
            if (ComputeHash == null) {
                throw new InvalidOperationException("ComputeHash is null, must initialize before call OAuthUtility.HashFunction = /* your computeHash code */ at once.");
            }

            var hmacKeyBase = consumerSecret.UrlEncode() + "&" + ((token == null) ? "" : token.Secret).UrlEncode();

            // escaped => unescaped[]
            var queryParams = Utility.ParseQueryString(uri.GetComponents(UriComponents.Query | UriComponents.KeepDelimiter, UriFormat.UriEscaped));

            var stringParameter = parameters
                .Where(x => x.Key.ToLower() != "realm")
                .Concat(queryParams)
                .Select(p => new { Key = p.Key.UrlEncode(), Value = p.Value.UrlEncode() })
                .OrderBy(p => p.Key, StringComparer.Ordinal)
                .ThenBy(p => p.Value, StringComparer.Ordinal)
                .Select(p => p.Key + "=" + p.Value)
                .ToString("&");
            var signatureBase = method.ToString() +
                "&" + uri.GetComponents(UriComponents.SchemeAndServer | UriComponents.Path, UriFormat.Unescaped).UrlEncode() +
                "&" + stringParameter.UrlEncode();

            var hash = ComputeHash(Encoding.UTF8.GetBytes(hmacKeyBase), Encoding.UTF8.GetBytes(signatureBase));
            return Convert.ToBase64String(hash).UrlEncode();
        }

        public static IEnumerable<KeyValuePair<string, string>> BuildBasicParameters(string consumerKey, string consumerSecret, string url, HttpMethod method, Token token = null, IEnumerable<KeyValuePair<string, string>> optionalParameters = null) {
            Precondition.NotNull(url, "url");

            var parameters = new List<KeyValuePair<string, string>>(capacity: 7)
            {
                new KeyValuePair<string,string>("oauth_consumer_key", consumerKey),
                new KeyValuePair<string,string>("oauth_nonce", random.Next().ToString() ),
                new KeyValuePair<string,string>("oauth_timestamp", DateTime.UtcNow.ToUnixTime().ToString() ),
                new KeyValuePair<string,string>("oauth_signature_method", "HMAC-SHA1" ),
                new KeyValuePair<string,string>("oauth_version", "1.0" )
            };
            if (token != null) parameters.Add(new KeyValuePair<string, string>("oauth_token", token.Key));
            if (optionalParameters == null) optionalParameters = Enumerable.Empty<KeyValuePair<string, string>>();

            var signature = GenerateSignature(consumerSecret, new Uri(url), method, token, parameters.Concat(optionalParameters));

            parameters.Add(new KeyValuePair<string, string>("oauth_signature", signature));

            return parameters;
        }

        public static HttpClient CreateOAuthClient(string consumerKey, string consumerSecret, AccessToken accessToken, IEnumerable<KeyValuePair<string, string>> optionalOAuthHeaderParameters = null) {
            return new HttpClient(new MessageHandler(consumerKey, consumerSecret, accessToken, optionalOAuthHeaderParameters));
        }


        public static HttpClient CreateOAuthClient(HttpMessageHandler innerHandler, string consumerKey, string consumerSecret, AccessToken accessToken, IEnumerable<KeyValuePair<string, string>> optionalOAuthHeaderParameters = null) {
            return new HttpClient(new MessageHandler(innerHandler, consumerKey, consumerSecret, accessToken, optionalOAuthHeaderParameters));
        }

        static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long ToUnixTime(this DateTime target) {
            return (long)(target - unixEpoch).TotalSeconds;
        }

        /// <summary>Escape RFC3986 String</summary>
        public static string UrlEncode(this string stringToEscape) {
            return Uri.EscapeDataString(stringToEscape)
                .Replace("!", "%21")
                .Replace("*", "%2A")
                .Replace("'", "%27")
                .Replace("(", "%28")
                .Replace(")", "%29");
        }

        public static string UrlDecode(this string stringToUnescape) {
            return UrlDecodeForPost(stringToUnescape)
                .Replace("%21", "!")
                .Replace("%2A", "*")
                .Replace("%27", "'")
                .Replace("%28", "(")
                .Replace("%29", ")");
        }

        public static string UrlDecodeForPost(this string stringToUnescape) {
            stringToUnescape = stringToUnescape.Replace("+", " ");
            return Uri.UnescapeDataString(stringToUnescape);
        }


        public static IEnumerable<KeyValuePair<string, string>> ParseQueryString(string query, bool post = false) {
            var queryParams = query.TrimStart('?').Split('&')
               .Where(x => x != "")
               .Select(x => {
                   var xs = x.Split('=');
                   if (post) {
                       return new KeyValuePair<string, string>(xs[0].UrlDecode(), xs[1].UrlDecodeForPost());
                   }
                   else {
                       return new KeyValuePair<string, string>(xs[0].UrlDecode(), xs[1].UrlDecode());
                   }
               });

            return queryParams;
        }

        public static string Wrap(this string input, string wrapper) {
            return wrapper + input + wrapper;
        }

        public static string ToString<T>(this IEnumerable<T> source, string separator) {
            return string.Join(separator, source);
        }
    }
}
