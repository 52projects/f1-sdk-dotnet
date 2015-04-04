using FellowshipOne.Api.Activities.Model;
using FellowshipOne.Api.Model;
using NUnit.Framework;
using Restify;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;
using System.Collections.Generic;
using System;
using FellowshipOne.Api.Activities.QueryObject;

namespace FellowshipOne.Api.Tests.Activities {
    [TestFixture]
    public class ActivitiesTests : Base {
        [Test]
        public void integration_fellowshipone_api_ministries_find_all_activities() {
            var results = RestClient.ActivitiesRealm.Activities.FindAll();
            results.Items.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void integration_fellowshipone_api_ministries_find_all_activities_with_page() {
            var results = RestClient.ActivitiesRealm.Activities.FindAll();

            if (results.TotalPages > 1) {
                results = RestClient.ActivitiesRealm.Activities.FindAll(2);
                results.Items.Count.ShouldBeGreaterThan(0);
            }
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_get_activity() {
            var results = RestClient.ActivitiesRealm.Activities.FindAll();
            var result = RestClient.ActivitiesRealm.Activities.Get(results.Items[0].ID.ToString());

            result.ShouldNotBe(null);
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_search_activities() {
            var ministryResult = RestClient.ActivitiesRealm.Ministries.FindAll();

            var qo = new ActivityQO();
            qo.MinistryID = ministryResult.Items[0].ID;

            var results = RestClient.ActivitiesRealm.Activities.FindBy(qo);
            results.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}
