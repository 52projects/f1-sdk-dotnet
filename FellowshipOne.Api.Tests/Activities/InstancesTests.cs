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
    public class InstancesTests : Base {
        [Test]
        public void integration_fellowshipone_api_ministries_find_all_instances() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var schedulesResults = RestClient.ActivitiesRealm.Schedules.FindAll(activityResults.Items[0].ID.ToString());
            var results = RestClient.ActivitiesRealm.Instances.FindAll(schedulesResults.Items[0].ID.ToString());
            results.Items.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void integration_fellowshipone_api_ministries_find_all_instances_with_page() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var schedulesResults = RestClient.ActivitiesRealm.Schedules.FindAll(activityResults.Items[0].ID.ToString());
            var results = RestClient.ActivitiesRealm.Instances.FindAll(schedulesResults.Items[0].ID.ToString());

            if (results.TotalPages > 1) {
                results = RestClient.ActivitiesRealm.Instances.FindAll(schedulesResults.Items[0].ID.ToString(), 2);
                results.Items.Count.ShouldBeGreaterThan(0);
            }
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_get_instance() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var schedulesResults = RestClient.ActivitiesRealm.Schedules.FindAll(activityResults.Items[0].ID.ToString());
            var results = RestClient.ActivitiesRealm.Instances.FindAll(schedulesResults.Items[0].ID.ToString());

            var result = RestClient.ActivitiesRealm.Instances.Get(schedulesResults.Items[0].ID.ToString(), results.Items[0].ID.ToString());

            result.ShouldNotBe(null);
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_search_instances() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var schedulesResults = RestClient.ActivitiesRealm.Schedules.FindAll(activityResults.Items[0].ID.ToString());

            var qo = new InstanceQO();
            qo.Date = new DateTime(2015, 3, 29);

            var results = RestClient.ActivitiesRealm.Instances.FindBy(schedulesResults.Items[0].ID.ToString(), qo);
            results.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}
