using FellowshipOne.Api.Giving.Model;
using FellowshipOne.Api.Model;
using NUnit.Framework;

using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;
using System.Collections.Generic;
using System;
using FellowshipOne.Api.Giving.QueryObject;

namespace FellowshipOne.Api.Tests.Giving {
    [TestFixture]
    public class ContributionReceiptTests : Base {
        private RestClient _client;

        [SetUp]
        public void SetupClient() {
            var oAuth = RestClient.Authorize(
                new F1OAuthTicket() {
                    ConsumerKey = "498",
                    ConsumerSecret = "f4d4d5ff-d347-4c44-a72e-65b0bcdeeb91",
                    ChurchCode = "MEETINGHOUSE"
                },
                "rmeredith",
                "M33tingHouse@&))",
                LoginType.PortalUser,
                false
            );

            _client = new RestClient(this.Ticket, false);
        }

        [Test]
        public void ContributionReceiptsSearch() {
            var qo = new ContributionReceiptQO() {
                StartReceivedDate = new DateTime(2018, 1, 1),
                EndReceivedDate = new DateTime(2019, 1, 1),
                FundType = Api.Giving.Enum.FundType.Contribution
            };

            var receipts = _client.GivingRealm.ContributionReceipts.Search<ContributionReceiptCollection>(qo);
            receipts.Data.PageNumber.ShouldBe(1);
        }

        [Test]
        public void ContributionTypeSearch() {
            var types = _client.GivingRealm.ContributionTypes.List();
            types.Data.Count.ShouldBeGreaterThan(0);
        }
    }
}