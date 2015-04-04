using FellowshipOne.Api.QueryObject;
using Restify.Attributes;

namespace FellowshipOne.Api.Giving.QueryObject {
    public class BatchQO : BaseQO {
        [QO("searchFor")]
        public string Name { get; set; }

        [QO("batchTypeID")]
        public string BatchTypeID { get; set; }

        [QO("batchStatusID")]
        public string BatchStatusID { get; set; }
    }
}
