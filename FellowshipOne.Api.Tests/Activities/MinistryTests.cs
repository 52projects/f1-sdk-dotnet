using FellowshipOne.Api.Activities.Model;
using FellowshipOne.Api.Model;
using NUnit.Framework;
using Restify;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;
using System.Collections.Generic;
using System;
//using FellowshipOne.Api.Activities.QueryObject;

namespace FellowshipOne.Api.Tests.Activities {
    [TestFixture]
    public class MinistryTests : Base {
        [Test]
        public void integration_fellowshipone_api_ministries_find_all_ministries() {
            var ministries = RestClient.ActivitiesRealm.Ministries.FindAll();
            ministries.Items.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void integration_fellowshipone_api_ministries_find_all_ministries_with_page() {
            var ministries = RestClient.ActivitiesRealm.Ministries.FindAll();

            if (ministries.TotalPages > 1) {
                ministries = RestClient.ActivitiesRealm.Ministries.FindAll(2);
                ministries.Items.Count.ShouldBeGreaterThan(0);
            }
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_get_ministry() {
            var ministries = RestClient.ActivitiesRealm.Ministries.FindAll();
            var ministry = RestClient.ActivitiesRealm.Ministries.Get(ministries.Items[0].ID.ToString());

            ministry.ShouldNotBe(null);
        }
    }
}
