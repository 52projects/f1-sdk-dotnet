using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;

namespace FellowshipOne.Api.Tests {
    public class Base {
        internal RestClient RestClient;
        internal F1OAuthTicket Ticket;
        internal int _testIndividualID;

        [TestFixtureSetUp]
        public void Setup() {
            this.Ticket = new F1OAuthTicket {
                ConsumerKey = ConfigurationManager.AppSettings["Consumer.Key"],
                ConsumerSecret =  ConfigurationManager.AppSettings["Consumer.Secret"],
                ChurchCode = ConfigurationManager.AppSettings["Church.Code"],
                AccessToken = "",
                AccessTokenSecret = ""
            };

            RestClient = new RestClient(this.Ticket, true);

            var oauth = RestClient.AuthorizeWithCredentials(this.Ticket, ConfigurationManager.AppSettings["UserName"],  ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["API.Url"], "PortalUser/AccessToken");

            this.Ticket.AccessToken = oauth.AccessToken;
            this.Ticket.AccessTokenSecret = oauth.AccessTokenSecret;

            _testIndividualID = int.Parse(ConfigurationManager.AppSettings["Test.Individual.ID"]);
        }
    }
}