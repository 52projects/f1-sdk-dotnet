﻿using FellowshipOne.Api.Activities.Model;
using FellowshipOne.Api.Model;
using NUnit.Framework;

using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;
using System.Collections.Generic;
using System;
using FellowshipOne.Api.Activities.QueryObject;

namespace FellowshipOne.Api.Tests.Activities {
    [TestFixture]
    public class SchedulesTests : Base {
        [Test]
        public void integration_fellowshipone_api_ministries_find_all_schedules() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var results = RestClient.ActivitiesRealm.Schedules.FindAll(activityResults.Items[0].ID.ToString());
            results.Items.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void integration_fellowshipone_api_ministries_find_all_schedules_with_page() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var results = RestClient.ActivitiesRealm.Schedules.FindAll(activityResults.Items[0].ID.ToString());

            if (results.TotalPages > 1) {
                results = RestClient.ActivitiesRealm.Schedules.FindAll(activityResults.Items[0].ID.ToString(), 2);
                results.Items.Count.ShouldBeGreaterThan(0);
            }
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_get_schedule() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var results = RestClient.ActivitiesRealm.Schedules.FindAll(activityResults.Items[0].ID.ToString());

            var result = RestClient.ActivitiesRealm.Schedules.Get(results.Items[0].Activity.ID.ToString(), results.Items[0].ID.ToString());

            result.ShouldNotBe(null);
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_search_schedules() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();

            var qo = new ScheduleQO();
            qo.Name = "Sunday";

            var results = RestClient.ActivitiesRealm.Schedules.FindBy(activityResults.Items[0].ID.ToString(), qo);
            results.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}
