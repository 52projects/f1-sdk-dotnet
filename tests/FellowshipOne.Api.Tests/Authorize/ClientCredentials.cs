using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using FellowshipOne.Api.Tests;
using System.Configuration;

namespace FellowshipOne.Api.Tests.Authorize {
    class ClientCredentials : Base {
        [Test]
        public void authorize_oauth2_client_credentials() {
            this.Ticket = new F1OAuthTicket {
                ConsumerKey = ConfigurationManager.AppSettings["Consumer.Key"],
                ConsumerSecret = ConfigurationManager.AppSettings["Consumer.Secret"],
                ChurchCode = ConfigurationManager.AppSettings["Church.Code"],
                AccessToken = "",
                AccessTokenSecret = ""
            };

            var response = RestClient.AuthorizeWithCredentials(this.Ticket, ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"], bool.Parse(ConfigurationManager.AppSettings["FellowshipOne.Is.Staging"]));
            response.ExpiresIn.ShouldBeGreaterThan(0);
        }
    }
}
