using FellowshipOne.Api.Giving.Model;
using FellowshipOne.Api.Model;
using NUnit.Framework;

using Shouldly;
using FellowshipOne.Api.People.QueryObject;
using System.Configuration;
using System.Collections.Generic;
using System;
using FellowshipOne.Api.Giving.QueryObject;


namespace FellowshipOne.Api.Tests.Groups {
    [TestFixture]
    class GroupTypesTest : Base {

        [SetUp]
        public void Setup() { }

        [Test]
        public void tests_groups_grouptypes_list_all() {
            var groupTypes = this.RestClient.GroupRealm.GroupTypes.List();
            groupTypes.Data.Count.ShouldBeGreaterThan(0);
        }
    }
}
