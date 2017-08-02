using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using RestSharp.Extensions.MonoHttp;
using FellowshipOne.Api.Exceptions;
using Newtonsoft.Json.Linq;

namespace FellowshipOne.Api {
    public class BaseClient {
        #region Properties
        public OAuthTicket Ticket { get; set; }
        public ContentType ContentType { get; set; }
        public string BaseUrl { get; set; }
        public IDictionary<string, string> RequestHeaders { get; set; }

        #endregion Properties

        #region Constructor
        public BaseClient(OAuthTicket ticket) {
        }

        public BaseClient(OAuthTicket ticket, string baseUrl) {
            this.Ticket = ticket;
            this.BaseUrl = baseUrl;
        }

        public BaseClient(IDictionary<string, string> requestHeaders, string baseUrl) {
            this.BaseUrl = BaseUrl;
            this.RequestHeaders = requestHeaders;
        }
        #endregion Constructor

        #region Methods
        public virtual IRestResponse AuthorizeFirstParty(OAuthTicket ticket, string username, string password, string authorizeUrl) {
            var restClient = new RestSharp.RestClient(this.BaseUrl);
            restClient.Authenticator = OAuth1Authenticator.ForClientAuthentication(ticket.ConsumerKey, ticket.ConsumerSecret, username, password);

            var request = new RestRequest(authorizeUrl, Method.POST);
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(username + " " + password);

            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("ec", System.Convert.ToBase64String(toEncodeAsBytes, 0, toEncodeAsBytes.Length));
            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {
                return response;
            }
        }

        public static F1OAuthTicket AuthorizeWithCredentials(F1OAuthTicket ticket, string username, string password, bool isStaging) {
            var baseUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);
            var restClient = new RestSharp.RestClient(baseUrl);

            var request = new RestRequest("v1/oauth2/token", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("client_id", ticket.ConsumerKey);
            request.AddParameter("client_secret", ticket.ConsumerSecret);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("grant_type", "password");
            
            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {
                var json = JObject.Parse(response.Content);

                ticket.AccessToken = json.SelectToken("access_token").ToString();
                ticket.TokenType = json.SelectToken("token_type").ToString();
                ticket.RefreshToken = json.SelectToken("refresh_token").ToString();
                ticket.ExpiresIn = decimal.Parse(json.SelectToken("expires_in").ToString());
                ticket.PersonID = int.Parse(json.SelectToken("person").SelectToken("id").ToString());
                return ticket;
            }
        }

        public static OAuthTicket AuthorizeWithCredentials(OAuthTicket ticket, string churchCode, string username, string password, string authorizeUrl, bool isStaging = false) {
            var baseUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", churchCode) : string.Format("https://{0}.fellowshiponeapi.com/", churchCode);
            var restClient = new RestSharp.RestClient(baseUrl);
            restClient.Authenticator = OAuth1Authenticator.ForClientAuthentication(ticket.ConsumerKey, ticket.ConsumerSecret, username, password);

            var request = new RestRequest(authorizeUrl, Method.POST);
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(username + " " + password);

            request.AddHeader("Content-Type", "application/xml");
            request.AddParameter("ec", System.Convert.ToBase64String(toEncodeAsBytes, 0, toEncodeAsBytes.Length));
            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {
                var qs = HttpUtility.ParseQueryString(response.Content);
                ticket.AccessToken = qs["oauth_token"];
                ticket.AccessTokenSecret = qs["oauth_token_secret"];
                return ticket;
            }
        }

        public static OAuthTicket GetRequestToken(OAuthTicket ticket, string callback, string requestTokenUrl, string baseUrl) {
            var restClient = new RestSharp.RestClient(baseUrl);
            restClient.Authenticator = OAuth1Authenticator.ForRequestToken(ticket.ConsumerKey, ticket.ConsumerSecret, callback);

            var request = new RestRequest(requestTokenUrl, Method.POST);
            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {
                var qs = HttpUtility.ParseQueryString(response.Content);
                ticket.AccessToken = qs["oauth_token"];
                ticket.AccessTokenSecret = qs["oauth_token_secret"];
                return ticket;
            }
        }

        public static IRestResponse ExchangeRequestToken(OAuthTicket ticket, string baseurl, string accessTokenUrl) {
            var restClient = new RestSharp.RestClient(baseurl);
            restClient.Authenticator = OAuth1Authenticator.ForAccessToken(ticket.ConsumerKey, ticket.ConsumerSecret, ticket.AccessToken, ticket.AccessTokenSecret);

            var request = new RestRequest(accessTokenUrl, Method.POST);
            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {
                return response;
            }
        }

        public static IRestResponse ExchangeRequestToken(OAuthTicket ticket, string baseurl, string accessTokenUrl, string additionalParamters = null) {
            var restClient = new RestSharp.RestClient(baseurl);
            restClient.Authenticator = OAuth1Authenticator.ForAccessToken(ticket.ConsumerKey, ticket.ConsumerSecret, ticket.AccessToken, ticket.AccessTokenSecret);
            var request = new RestRequest(accessTokenUrl, Method.POST);

            string[] additionParms = additionalParamters.Split('&');

            foreach (var current in additionParms) {
                string[] nameValue = current.Split('=');

                if (nameValue.Length == 2) {
                    request.AddParameter(nameValue[0], nameValue[1]);
                }
            }

            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {
                var qs = RestSharp.Extensions.MonoHttp.HttpUtility.ParseQueryString(response.Content);
                ticket.AccessToken = qs["oauth_token"];
                ticket.AccessTokenSecret = qs["oauth_token_secret"];

                return response;
            }
        }
        
        public static IRestResponse AuthorizeClientCredentials(string clientID, string clientSecret, string baseUrl) {
            var restClient = new RestSharp.RestClient(baseUrl);
            var request = new RestRequest("v1/oauth2/token", Method.POST);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", clientID);
            request.AddParameter("client_secret", clientSecret);
            request.AddParameter("grant_type", "client_credentials");

            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {
                var qs = HttpUtility.ParseQueryString(response.Content);
                return null;
            }
        }

        public static void RevokeAccessToken(F1OAuthTicket ticket, bool isStaging) {
            var baseUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);
            var restClient = new RestSharp.RestClient(baseUrl);
            
            var request = new RestRequest("v1/oauth2/revoke", Method.GET);
            request.AddParameter("client_id", ticket.ConsumerKey);
            request.AddParameter("client_secret", ticket.ConsumerSecret);
            request.AddParameter("token", ticket.AccessToken);

            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {

            }
        }

        public static F1OAuthTicket RefreshToken(F1OAuthTicket ticket, bool isStaging) {
            var baseUrl = isStaging ? string.Format("https://{0}.staging.fellowshiponeapi.com/", ticket.ChurchCode) : string.Format("https://{0}.fellowshiponeapi.com/", ticket.ChurchCode);
            var restClient = new RestSharp.RestClient(baseUrl);

            var request = new RestRequest("v1/oauth2/token", Method.POST);
            request.AddParameter("client_id", ticket.ConsumerKey);
            request.AddParameter("client_secret", ticket.ConsumerSecret);
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("refresh_token", ticket.RefreshToken);

            var response = restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                throw new ApiAccessException(response.StatusDescription) {
                    StatusCode = response.StatusCode,
                    StatusDescription = response.StatusDescription,
                    RequestUrl = response.ResponseUri.AbsoluteUri
                };
            }
            else {
                var json = JObject.Parse(response.Content);

                ticket.AccessToken = json.SelectToken("access_token").ToString();
                ticket.TokenType = json.SelectToken("token_type").ToString();
                ticket.RefreshToken = json.SelectToken("refresh_token").ToString();
                ticket.ExpiresIn = decimal.Parse(json.SelectToken("expires_in").ToString());
                ticket.PersonID = int.Parse(json.SelectToken("person").SelectToken("id").ToString());
                return ticket;
            }
        }
        #endregion Methods
    }

    public enum ContentType {
        XML = 1,
        JSON = 2
    }
}
