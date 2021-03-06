﻿

namespace FellowshipOne.Api.Activities.Sets {
    public class Schedules : ApiSet<Model.Schedule> {
        private readonly string _baseUrl = string.Empty;
        private const string LIST_URL = "/activities/v1/activities/{0}/schedules";
        private const string GET_URL = "/activities/v1/activities/{0}/schedules/{1}";
        private const string SEARCH_URL = "/activities/v1/activities/{0}/schedules/search";


        public Schedules(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.JSON) {
            _baseUrl = baseUrl;
        }

        protected override string GetChildListUrl { get { return LIST_URL; } }
        protected override string GetChildUrl { get { return GET_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
    }
}
