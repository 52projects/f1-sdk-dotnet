using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;

namespace FellowshipOne.Api.Tests {
    public class Base {
        internal RestClient RestClient;
        internal F1OAuthTicket Ticket;
        internal int _testIndividualID;

        [OneTimeSetUp]
        public void Setup() {
            this.Ticket = new F1OAuthTicket {
                ConsumerKey = "",
                ConsumerSecret = "",
                ChurchCode = "",
                AccessToken = "",
                AccessTokenSecret = ""
            };

            var isStaging = false;

            RestClient = new RestClient(this.Ticket, isStaging);
            //var oauth = RestClient.AuthorizeWithCredentials(this.Ticket, ConfigurationManager.AppSettings["Church.Code"], ConfigurationManager.AppSettings["UserName"],  ConfigurationManager.AppSettings["Password"], "v1/PortalUser/AccessToken", isStaging);

            //this.Ticket.AccessToken = oauth.AccessToken;
            //this.Ticket.AccessTokenSecret = oauth.AccessTokenSecret;

            // _testIndividualID = int.Parse(ConfigurationManager.AppSettings["Test.Individual.ID"]);
        }
    }
}