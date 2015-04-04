using FellowshipOne.Api.QueryObject;
using Restify.Attributes;
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
    }
}
