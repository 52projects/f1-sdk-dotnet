
using FellowshipOne.Api.Attributes;
using FellowshipOne.Api.Giving.Enum;
using System;


namespace FellowshipOne.Api.Giving.QueryObject {
    public class ContributionReceiptQO : BaseQO {
        [QO("batchID")]
        public string BatchID { get; set; }

        [QO("individualID")]
        public string IndividualID { get; set; }

        [QO("householdID")]
        public string HouseholdID { get; set; }

        [QO("startReceivedDate")]
        public DateTime? StartReceivedDate { get; set; }

        [QO("endReceivedDate")]
        public DateTime? EndReceivedDate { get; set; }

        [QO("lastupdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }

        [QO("fundTypeID")]
        public FundType? FundType { get; set; }
    }
}
