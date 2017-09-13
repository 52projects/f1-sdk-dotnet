using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api;
using System.Configuration;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Tests.Authorize {
    public class RequestTokenTests {
        internal F1OAuthTicket Ticket;

        [OneTimeSetUp]
        public void Setup() {
            this.Ticket = new F1OAuthTicket {
                ConsumerKey = "359",
                ConsumerSecret = "cc5ea39d-f6e0-4084-8e1c-131e1f9d2abb",
                ChurchCode = "52projects",
                AccessToken = "",
                AccessTokenSecret = ""
            };
        }

        [Test]
        public async Task integration_f1_request_tokens_get_unauthorized_request_token() {
            var restClient = new RestClient(this.Ticket, false);
            var token = await restClient.GetRequestTokenAsync();

            this.Ticket.AccessToken = token.AccessToken;
            this.Ticket.AccessTokenSecret = token.AccessTokenSecret;

            token.AccessToken.ShouldNotBe(null);
        }

        [Test]
        public async Task integration_f1_authorization_url() {
            var restClient = new RestClient(this.Ticket, false);
            var token = await restClient.GetRequestTokenAsync();

            var url = restClient.CreateAuthorizationUrl(token, "http://localhost:5587/account/fellowshipone");
            url.ShouldContain(token.AccessToken);
        }

        [Test]
        public async Task integration_f1_exchange_request_token() {
            var restClient = new RestClient(this.Ticket, false);

            var accessToken = await restClient.ExchangeRequestTokenAsync("edc9dbeb-1240-45f2-a2a5-3ff2321b956a", "68f3f6d3-14ed-4bae-a0de-aff963eb5671");
            accessToken.AccessTokenSecret.ShouldNotBe(null);
        }
    }
}