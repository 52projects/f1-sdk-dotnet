using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;

namespace FellowshipOne.Api.Tests {
    [TestFixture]
    public class Base {
        public FellowshipOne.Api.RestClient Client;
        public F1OAuthTicket Ticket;

        [SetUp]
        public void Setup() {
            //Ticket = FellowshipOne.Api.RestClient.Authorize(new F1OAuthTicket {
            //    ConsumerKey = ConfigurationManager.AppSettings["Consumer.Key"],
            //    ConsumerSecret = ConfigurationManager.AppSettings["Consumer.Secret"],
            //    ChurchCode = ConfigurationManager.AppSettings["Church.Code"]
            //}, ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], LoginType.PortalUser, true);

            //Client = new RestClient(Ticket, false);
        }

        [TearDown]
        public void TearDown() {
            Ticket = null;
            Client = null;
        }
    }
}