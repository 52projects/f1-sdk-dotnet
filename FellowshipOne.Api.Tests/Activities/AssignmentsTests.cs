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
    public class AssignmentsTests : Base {
        [Test]
        public void integration_fellowshipone_api_ministries_find_all_assignments() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var results = RestClient.ActivitiesRealm.Assignments.FindAll(activityResults.Items[0].ID.ToString());
            results.Items.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void integration_fellowshipone_api_ministries_find_all_assignments_with_page() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var results = RestClient.ActivitiesRealm.Assignments.FindAll(activityResults.Items[0].ID.ToString());

            if (results.TotalPages > 1) {
                results = RestClient.ActivitiesRealm.Assignments.FindAll(activityResults.Items[0].ID.ToString(), 2);
                results.Items.Count.ShouldBeGreaterThan(0);
            }
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_get_assignment() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var results = RestClient.ActivitiesRealm.Assignments.FindAll(activityResults.Items[0].ID.ToString());

            var result = RestClient.ActivitiesRealm.Assignments.Get(results.Items[0].Activity.ID.ToString(), results.Items[0].ID.ToString());

            result.ShouldNotBe(null);
        }
    }
}
