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
    public class AttendanceTests : OAuth2Base {
        [Test]
        public void integration_fellowshipone_api_attendance_find_atteandance_by_insatnce() {
            var times = new List<bool>();
            for (int i = 0; i < 50; i++) {
                try {
                    var results = this.RestClient.ActivitiesRealm.Attendance.FindAll(27776, 77559029, 1);
                    times.Add(true);
                }
                catch (Exception e) {
                    times.Add(false);
                }
            }
        }
    }
}
