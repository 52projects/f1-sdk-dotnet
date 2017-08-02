using FellowshipOne.Api.Giving.Model;
using FellowshipOne.Api.Model;
using NUnit.Framework;
using System.Linq;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;
using System.Collections.Generic;
using System;
using FellowshipOne.Api.Giving.QueryObject;


namespace FellowshipOne.Api.Tests.Groups {
    [TestFixture]
    class GroupTests : Base {

        [SetUp]
        public void Setup() { }

        [Test]
        public void tests_groups_groups_list_all() {
            var groupTypes = this.RestClient.GroupRealm.GroupTypes.List();
            var groups = this.RestClient.GroupRealm.Groups.List(groupTypes.First().ID.ToString());
            groups.Count.ShouldBeGreaterThan(0);
        }
    }
}
