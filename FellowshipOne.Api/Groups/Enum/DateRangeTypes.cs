using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FellowshipOne.Api.Groups.Enum {
    public enum DateRangeTypes {
        Unspecified = 0,
        Ticks = 1,
        Milliseconds = 2,
        Seconds = 3,
        Days = 4,
        Weeks = 5,
        Months = 6,
        Years = 7,
        DOB = 8,
    }
}
