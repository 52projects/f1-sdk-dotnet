using FellowshipOne.Api.Giving.Model;
using FellowshipOne.Api.Model;
using NUnit.Framework;
using Restify;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;
using System.Collections.Generic;
using System;
using FellowshipOne.Api.Giving.QueryObject;

namespace FellowshipOne.Api.Tests.Giving {

    [TestFixture]
    public class BatchesTest : Base {
        private RestClient _client;

        [SetUp]
        public void SetupClient() {
            var oAuth = RestClient.Authorize(
                new F1OAuthTicket() {
                    ConsumerKey = ConfigurationManager.AppSettings["Consumer.Key"],
                    ConsumerSecret = ConfigurationManager.AppSettings["Consumer.Secret"],
                    ChurchCode = ConfigurationManager.AppSettings["Church.Code"]
                },
                ConfigurationManager.AppSettings["Username"],
                ConfigurationManager.AppSettings["Password"],
                LoginType.PortalUser,
                ConfigurationManager.AppSettings["API.Url"],
                false
            );

            _client = new RestClient(oAuth, ConfigurationManager.AppSettings["API.Url"], false, false);
        }

        [Test]
        public void BatchSearchForScannedContributionBatchesInProgress() {
            var batchQO = new BatchQO() {
                BatchStatusID = "6",
                BatchTypeID = "4"
            };

            var batches = _client.GivingRealm.Batches.Search<BatchSearchResults>(batchQO);
            batches.PageNumber.ShouldBe(1);
        }

        [Test]
        public void GetRdcBatchByBatchID() {
            var rdcBatch = _client.GivingRealm.RDCBatches.Get("1518983");
            rdcBatch.Name.ShouldBe("Test RDC Batch May 16 2012 10:53AM");
        }

        [Test]
        public void GetRdcBatchItemsByBatchID() {
            var batchQO = new BatchQO() {
                BatchStatusID = "6",
                BatchTypeID = "4"
            };

            var batches = _client.GivingRealm.Batches.Search<BatchSearchResults>(batchQO);

            var rdcBatchItems = _client.GivingRealm.RDCBatchItems.GetListByBatchId(batches[0].ID.GetValueOrDefault());
            rdcBatchItems.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void GetRdcBatchItemByID() {
            var person = _client.PeopleRealm.People.Get("33175804");

            var rdcBatchItem = _client.GivingRealm.RDCBatchItems.Get("2");
            rdcBatchItem.ReferenceNumber = "T:0C38BWZ7w";
        }

        [Test]
        public void GetReferenceImageByID() {
            var bytes = _client.GivingRealm.ReferenceImages.GetBytes(37869261);
            bytes.Length.ShouldBeGreaterThan(0);
        }
    }
}
