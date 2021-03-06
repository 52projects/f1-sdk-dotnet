﻿using FellowshipOne.Api.Activities.Model;
using FellowshipOne.Api.Model;
using NUnit.Framework;
using Shouldly;

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

            var result = RestClient.ActivitiesRealm.Assignments.Get(activityResults.Items[0].ID.ToString(), results.Items[0].ID.ToString());

            result.ShouldNotBe(null);
        }

        [Test]
        public void integration_Fellowshipone_api_ministries_assignments_create_new() {
            var activityResults = RestClient.ActivitiesRealm.Activities.FindAll();
            var activityID = activityResults.Items[0].ID;

            var assigment = new Assignment {
                URI = string.Empty,
                Activity = new ParentNamedObject {
                    ID = activityID
                },
                Person = new ParentObject {
                    ID = base._testIndividualID
                },
                Type = new ParentNamedObject {
                    ID = 1
                },
                Schedule = new ParentObject(),
                Roster = new ParentObject(),
                RosterFolder = new ParentObject(),
                CreatedByPerson = new ParentObject(),
                LastUpdatedByPerson = new ParentObject()
            };

            var result = RestClient.ActivitiesRealm.Assignments.Create(activityID, assigment);
            result.Data.ID.Value.ShouldBeGreaterThan(0);

            RestClient.ActivitiesRealm.Assignments.Delete(activityID, result.Data.ID.Value);
        }
    }
}
