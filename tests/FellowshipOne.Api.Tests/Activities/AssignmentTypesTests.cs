using FellowshipOne.Api.Activities.Model;
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
    public class AssignmentTypesTests : Base {
        [Test]
        public void integration_fellowshipone_api_assignmenttypes_findall() {
            var results = RestClient.ActivitiesRealm.AssignmentTypes.FindAll();
            results.Items.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void integration_fellowshipone_api_assignment_types_findall_with_page() {
            var results = RestClient.ActivitiesRealm.AssignmentTypes.FindAll();

            if (results.TotalPages > 1) {
                results = RestClient.ActivitiesRealm.AssignmentTypes.FindAll(2);
                results.Items.Count.ShouldBeGreaterThan(0);
            }
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_get_activitytype() {
            var results = RestClient.ActivitiesRealm.AssignmentTypes.FindAll();
            var result = RestClient.ActivitiesRealm.AssignmentTypes.Get(results.Items[0].ID.ToString());

            result.ShouldNotBe(null);
        }
    }
}
