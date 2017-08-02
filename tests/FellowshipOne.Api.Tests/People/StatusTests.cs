using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Collections.Generic;
using System.Linq;

namespace FellowshipOne.Api.Tests.People {
    public class StatusTests : Base {

        [Test]
        public void status_list_all() {
            var statuses = RestClient.PeopleRealm.Statuses.List();
            statuses.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void status_list_get_sub_statuses() {
            var statuses = RestClient.PeopleRealm.Statuses.List();
            var subStatuses = statuses.First().SubStatuses;

            subStatuses.Count.ShouldBeGreaterThan(0);
        }
    }
}
