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
    public class ActivityTypesTests : Base {
        [Test]
        public void integration_fellowshipone_api_ministries_find_all_activitytypes() {
            var results = RestClient.ActivitiesRealm.ActivityTypes.FindAll();
            results.Items.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void integration_fellowshipone_api_ministries_find_all_activitytypes_with_page() {
            var results = RestClient.ActivitiesRealm.ActivityTypes.FindAll();

            if (results.TotalPages > 1) {
                results = RestClient.ActivitiesRealm.ActivityTypes.FindAll(2);
                results.Items.Count.ShouldBeGreaterThan(0);
            }
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_get_activitytype() {
            var results = RestClient.ActivitiesRealm.ActivityTypes.FindAll();
            var result = RestClient.ActivitiesRealm.ActivityTypes.Get(results.Items[0].ID.ToString());

            result.ShouldNotBe(null);
        }
    }
}
