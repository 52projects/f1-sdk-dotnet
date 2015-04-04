using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FellowshipOne.Api.Giving.Enum {
    public enum PaymentTypes {
        Check = 1,
        Cash = 2,
        CreditCard = 3,
        NonCash = 4,
        ACH = 5,
        Voucher = 6
    }
}
