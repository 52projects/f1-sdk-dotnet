using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;

namespace FellowshipOne.Api.Tests {
    public class OAuth2Base {
        internal RestClient RestClient;
        internal F1OAuthTicket Ticket;
        internal int _testIndividualID;

        [TestFixtureSetUp]
        public void Setup() {
            this.Ticket = new F1OAuthTicket {
                ConsumerKey = ConfigurationManager.AppSettings["Consumer.Key"],
                ConsumerSecret = ConfigurationManager.AppSettings["Consumer.Secret"],
                ChurchCode = ConfigurationManager.AppSettings["Church.Code"],
                AccessToken = "",
                AccessTokenSecret = ""
            };

            var response = RestClient.AuthorizeWithCredentials(this.Ticket, ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"], bool.Parse(ConfigurationManager.AppSettings["FellowshipOne.Is.Staging"]));
            RestClient = new RestClient(response, bool.Parse(ConfigurationManager.AppSettings["FellowshipOne.Is.Staging"]));
            _testIndividualID = int.Parse(ConfigurationManager.AppSettings["Test.Individual.ID"]);
        }
    }
}
