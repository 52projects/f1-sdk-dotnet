using System;
using System.Net;
using FellowshipOne.Api.Model;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Contrib;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Restify;
using System.Security;
using System.Runtime.InteropServices;

namespace FellowshipOne.Api {
    public class RestClient : Restify.Client {

        #region Properties
        F1OAuthTicket _ticket { get; set; }
        bool _useDemo = false;

        #region API Sets
        public FellowshipOne.Api.Realms.Person PeopleRealm;
        public FellowshipOne.Api.Realms.Giving GivingRealm;
        public FellowshipOne.Api.Realms.F1Activities ActivitiesRealm;
        #endregion API Sets

        #endregion Properties

        #region Constructor
        public RestClient(F1OAuthTicket ticket, bool isStaging = false, bool useDemo = false)
            : base(ticket) {
            var baseUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);
            
            SetProperties(ticket, useDemo, baseUrl);
        }
        public RestClient(F1OAuthTicket ticket, string baseUrl, bool isSecure = false, bool useDemo = false)
            : base(ticket) {
            var url = string.Format("{0}://{1}.{2}/", isSecure == true ? "https" : "http", ticket.ChurchCode, baseUrl);
            SetProperties(ticket, useDemo, url);
        }
        private void SetProperties(F1OAuthTicket ticket, bool useDemo, string baseUrl) {
            _ticket = ticket;
            _useDemo = useDemo;
            PeopleRealm = new Realms.Person(ticket, baseUrl);
            GivingRealm = new Realms.Giving(ticket, baseUrl);
            ActivitiesRealm = new Realms.F1Activities(ticket, baseUrl);
        }

        #endregion Constructor

        #region Methods
        public static F1OAuthTicket ExchangeRequestToken(F1OAuthTicket ticket, bool isStaging = false, bool useDemo = false) {
            Client client = new Client(ticket);
            var authUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);
            return BuildTicket(ticket, authUrl, "v1/Tokens/AccessToken");
        }

        public static F1OAuthTicket Authorize(F1OAuthTicket ticket, string username, string password, LoginType loginType, bool isStaging = false, bool useDemo = false) {
            Client client = new Client(ticket);
            var authUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);
            authUrl += "v1/" + loginType.ToString() + "/AccessToken";
            return BuildTicket(ticket, username, password, client, authUrl);
        }

        public static F1OAuthTicket GetRequestToken(F1OAuthTicket ticket, bool isStaging = false, bool useDemo = false) {
            Client client = new Client(ticket);
            var requestTokenUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);

            var oauthTicket = Client.GetRequestToken(ticket, "myapp.com", "v1/RequestToken", requestTokenUrl);
            ticket.AccessToken = oauthTicket.AccessToken;
            ticket.AccessTokenSecret = oauthTicket.AccessTokenSecret;
            return ticket;
        }

        public static F1OAuthTicket Authorize(F1OAuthTicket ticket, string username, string password, LoginType loginType, string baseUrl, bool isSecure = false, bool isStaging = false, bool useDemo = false)
        {
            var client = new Client(ticket);
            var authUrl = string.Format("{0}://{1}.{2}/{3}/{4}/{5}", isSecure == true ? "https" : "http", ticket.ChurchCode, baseUrl, "v1", loginType, "AccessToken");
            return BuildTicket(ticket, username, password, client, authUrl);
        }

        private static F1OAuthTicket BuildTicket(F1OAuthTicket ticket, string username, string password, Client client, string authUrl) {
            IRestResponse response = client.AuthorizeFirstParty(ticket, username, password, authUrl);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.StatusDescription);
            else {
                var qs = HttpUtility.ParseQueryString(response.Content);
                ticket.AccessToken = qs["oauth_token"];
                ticket.AccessTokenSecret = qs["oauth_token_secret"];
                if (response.Headers.SingleOrDefault(x => x.Name == "Content-Location") != null) {
                    ticket.PersonURL = response.Headers.SingleOrDefault(x => x.Name == "Content-Location").Value.ToString();
                }
            }
            return ticket;
        }

        private static F1OAuthTicket BuildTicket(F1OAuthTicket ticket, string baseurl, string authUrl) {
            IRestResponse response = Client.ExchangeRequestToken(ticket, baseurl, authUrl);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.StatusDescription);
            else {
                var qs = HttpUtility.ParseQueryString(response.Content);
                ticket.AccessToken = qs["oauth_token"];
                ticket.AccessTokenSecret = qs["oauth_token_secret"];
                if (response.Headers.SingleOrDefault(x => x.Name == "Content-Location") != null) {
                    ticket.PersonURL = response.Headers.SingleOrDefault(x => x.Name == "Content-Location").Value.ToString();
                }
            }
            return ticket;
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

        #endregion Methods
    }

    public enum LoginType {
        PortalUser = 1,
        WeblinkUser = 2
    }
}
