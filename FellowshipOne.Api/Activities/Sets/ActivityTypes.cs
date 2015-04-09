using Restify;
namespace FellowshipOne.Api.Activities.Sets {
    public class ActivityTypes : ApiSet<Model.ActivityType> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/types";
        private const string GET_URL = "/activities/v1/types/{0}";


        public ActivityTypes(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string ListUrl { get { return LIST_URL; } }
        protected override string GetUrl { get { return GET_URL; } }
    }
}
