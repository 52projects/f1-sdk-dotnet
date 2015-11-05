

namespace FellowshipOne.Api.Activities.Sets {
    public class Rooms : ApiSet<Model.Room> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/rooms";
        private const string GET_URL = "/activities/v1/rooms/{0}";


        public Rooms(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string ListUrl { get { return LIST_URL; } }
    }
}
