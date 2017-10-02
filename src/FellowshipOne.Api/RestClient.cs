using System;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using FellowshipOne.Api.OAuth;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FellowshipOne.Api {
    public class RestClient {

        #region Properties
        private F1OAuthTicket _ticket { get; set; }
        private bool _useDemo = false;
        private bool _isStaging = false;
        private string _baseUrl;

        #region API Sets
        public FellowshipOne.Api.Realms.Person PeopleRealm;
        //public FellowshipOne.Api.Realms.Giving GivingRealm;
        //public FellowshipOne.Api.Realms.F1Activities ActivitiesRealm;
        //public FellowshipOne.Api.Realms.GroupsRealm GroupRealm;
        #endregion API Sets

        #endregion Properties

        #region Constructor
        public RestClient(F1OAuthTicket ticket, bool isStaging = false, bool useDemo = false) {
            _isStaging = isStaging;
            SetProperties(ticket, useDemo);

            Utility.ComputeHash = (key, buffer) => { using (var hmac = new HMACSHA1(key)) { return hmac.ComputeHash(buffer); } };
        }

        #endregion Constructor

        #region Methods
        public async Task<F1OAuthTicket> ExchangeRequestTokenAsync(string accessToken, string accessTokenSecret, bool isStaging = false, bool useDemo = false) {
            var authUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", _ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", _ticket.ChurchCode);
            authUrl += "v1/Tokens/AccessToken";

            var requestToken = new RequestToken(accessToken, accessTokenSecret);
            var authorizer = new Authorizer(_ticket.ConsumerKey, _ticket.ConsumerSecret);
            var tokenResponse = await authorizer.GetAccessTokenAsync(authUrl, requestToken, null);

            _ticket.AccessToken = tokenResponse.Token.Key;
            _ticket.AccessTokenSecret = tokenResponse.Token.Secret;
            return _ticket;
        }

        public async Task<F1OAuthTicket> GetRequestTokenAsync() {
            var requestTokenUrl = _baseUrl + "v1/Tokens/RequestToken";
            var authorizer = new Authorizer(_ticket.ConsumerKey, _ticket.ConsumerSecret);

            var tokenResponse = await authorizer.GetRequestTokenAsync(requestTokenUrl);
            var requestToken = tokenResponse.Token;
            _ticket.AccessToken = requestToken.Key;
            _ticket.AccessTokenSecret = requestToken.Secret;
            SetProperties(_ticket, _useDemo);
            return _ticket;
        }

        public string CreateAuthorizationUrl(F1OAuthTicket ticket, string callbackurl) {
            var loginUrl = new System.Text.StringBuilder();
            loginUrl.Append(_baseUrl);
            loginUrl.Append("v1/PortalUser/Login?oauth_token=");
            loginUrl.Append(ticket.AccessToken);
            loginUrl.Append("&oauth_token_secret=");
            loginUrl.Append(ticket.AccessTokenSecret);
            loginUrl.Append("&oauth_callback=");
            loginUrl.Append(callbackurl);
            return loginUrl.ToString();
        }
        
        public void UpdateTokens(string accessToken, string accessTokenSecret) {
            _ticket.AccessToken = accessToken;
            _ticket.AccessTokenSecret = accessTokenSecret;
            SetProperties(_ticket, _useDemo);
        }

        public void UpdateChurchCode(string churchCode) {
            _ticket.ChurchCode = churchCode;
            SetProperties(_ticket, _useDemo);
        }

        //public static F1OAuthTicket Authorize(F1OAuthTicket ticket, string username, string password, LoginType loginType, bool isStaging = false)
        //{
        //    var baseUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com", ticket.ChurchCode);
        //    var client = new BaseClient(ticket, baseUrl);
        //    var authUrl = string.Format("v1/{0}/AccessToken", loginType);
        //    return BuildTicket(ticket, username, password, client, authUrl);
        //}

        //private static F1OAuthTicket BuildTicket(F1OAuthTicket ticket, string username, string password, BaseClient client, string authUrl) {
        //    IRestResponse response = client.AuthorizeFirstParty(ticket, username, password, authUrl);

        //    if (response.StatusCode != HttpStatusCode.OK)
        //        throw new Exception(response.StatusDescription);
        //    else {
        //        var qs = HttpUtility.ParseQueryString(response.Content);
        //        ticket.AccessToken = qs["oauth_token"];
        //        ticket.AccessTokenSecret = qs["oauth_token_secret"];
        //        if (response.Headers.SingleOrDefault(x => x.Name == "Content-Location") != null) {
        //            ticket.PersonURL = response.Headers.SingleOrDefault(x => x.Name == "Content-Location").Value.ToString();
        //        }
        //    }
        //    return ticket;
        //}

        //private F1OAuthTicket BuildTicket(F1OAuthTicket ticket, string baseurl, string authUrl) {
        //    IRestResponse response = BaseClient.ExchangeRequestToken(ticket, baseurl, authUrl);

        //    if (response.StatusCode != HttpStatusCode.OK)
        //        throw new Exception(response.StatusDescription);
        //    else {
        //        var qs = HttpUtility.ParseQueryString(response.Content);
        //        ticket.AccessToken = qs["oauth_token"];
        //        ticket.AccessTokenSecret = qs["oauth_token_secret"];
        //        if (response.Headers.SingleOrDefault(x => x.Name == "Content-Location") != null) {
        //            ticket.PersonURL = response.Headers.SingleOrDefault(x => x.Name == "Content-Location").Value.ToString();
        //        }
        //    }
        //    return ticket;
        //}

            private void SetBaseUrl() {
            var baseUrl = _isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", _ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", _ticket.ChurchCode);
            _baseUrl = baseUrl;
        }

        private static String SecureStringToString(SecureString value)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(value);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }

        private void SetProperties(F1OAuthTicket ticket, bool useDemo) {
            _ticket = ticket;
            _useDemo = useDemo;
            SetBaseUrl();
            PeopleRealm = new Realms.Person(ticket, _baseUrl);
            //GivingRealm = new Realms.Giving(ticket, baseUrl);
            //ActivitiesRealm = new Realms.F1Activities(ticket, baseUrl);
            //GroupRealm = new Realms.GroupsRealm(ticket, baseUrl);
        }

        #endregion Methods
    }

    public enum LoginType {
        PortalUser = 1,
        WeblinkUser = 2
    }
}
