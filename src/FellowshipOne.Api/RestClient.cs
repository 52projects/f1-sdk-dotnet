﻿using System;
using System.Net;
using FellowshipOne.Api.Model;
using RestSharp;
using RestSharp.Authenticators;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Web;
using System.Security;
using System.Runtime.InteropServices;

namespace FellowshipOne.Api {
    public class RestClient : BaseClient {

        #region Properties
        F1OAuthTicket _ticket { get; set; }
        bool _useDemo = false;

        #region API Sets
        public FellowshipOne.Api.Realms.Person PeopleRealm;
        public FellowshipOne.Api.Realms.Giving GivingRealm;
        public FellowshipOne.Api.Realms.F1Activities ActivitiesRealm;
        public FellowshipOne.Api.Realms.GroupsRealm GroupRealm;
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
            GroupRealm = new Realms.GroupsRealm(ticket, baseUrl);
        }

        #endregion Constructor

        #region Methods
        public static F1OAuthTicket ExchangeRequestToken(F1OAuthTicket ticket, bool isStaging = false, bool useDemo = false) {
            BaseClient client = new BaseClient(ticket);
            var authUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);
            return BuildTicket(ticket, authUrl, "v1/Tokens/AccessToken");
        }

        public static F1OAuthTicket GetRequestToken(F1OAuthTicket ticket, bool isStaging = false, bool useDemo = false) {
            BaseClient client = new BaseClient(ticket);
            var requestTokenUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);

            var oauthTicket = BaseClient.GetRequestToken(ticket, "myapp.com", "v1/RequestToken", requestTokenUrl);
            ticket.AccessToken = oauthTicket.AccessToken;
            ticket.AccessTokenSecret = oauthTicket.AccessTokenSecret;
            return ticket;
        }

        public static string CreateAuthorizationUrl(F1OAuthTicket ticket, string callbackurl, bool isStaging = false) {
            var loginUrl = new System.Text.StringBuilder();
            loginUrl.Append(isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode));
            loginUrl.Append("/v1/PortalUser/Login?oauth_token=");
            loginUrl.Append(ticket.AccessToken);
            loginUrl.Append("&oauth_token_secret=");
            loginUrl.Append(ticket.AccessTokenSecret);
            loginUrl.Append("&oauth_callback=");
            loginUrl.Append(callbackurl);
            return loginUrl.ToString();
        }

        public static F1OAuthTicket Authorize(F1OAuthTicket ticket, string username, string password, LoginType loginType, bool isStaging = false)
        {
            var baseUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com", ticket.ChurchCode);
            var client = new BaseClient(ticket, baseUrl);
            var authUrl = string.Format("v1/{0}/AccessToken", loginType);
            return BuildTicket(ticket, username, password, client, authUrl);
        }

        private static F1OAuthTicket BuildTicket(F1OAuthTicket ticket, string username, string password, BaseClient client, string authUrl) {
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
            IRestResponse response = BaseClient.ExchangeRequestToken(ticket, baseurl, authUrl);

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
