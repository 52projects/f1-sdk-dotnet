using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using FellowshipOne.Api.Tests;

namespace FellowshipOne.Api.Tests.Authorize {
    public class FristParty : Base {

        [Test]
        public void authorize_ticket_has_access_token() {
            Ticket.AccessToken.ShouldNotBeEmpty();
        }
    }
}
