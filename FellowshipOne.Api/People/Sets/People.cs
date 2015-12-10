
using System.IO;

namespace FellowshipOne.Api.People.Sets {
    public class People : ApiSet<Model.Person> {
        private const string GET_URL = "/v1/people/{0}";
        private const string SEARCH_URL = "/v1/people/search";
        private const string CHILD_LIST_URL = "/v1/households/{0}/people";
        private const string CREATE_URL = "/v1/people";
        private const string EDIT_URL = "/v1/people/{0}";
        private const string IMAGE_URL = "/v1/people/{0}/images";
        private const string IMAGE_UPDATE_URL = "/v1/people/{0}/images/{1}";

        public People(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string GetUrl { get { return GET_URL; } }
        protected override string SearchUrl { get { return SEARCH_URL; } }
        protected override string GetChildListUrl { get { return CHILD_LIST_URL; } }
        protected override string CreateUrl { get { return CREATE_URL; } }
        protected override string EditUrl { get { return EDIT_URL; } }

        public byte[] GetImage(string id, string size = "M") {
            var url = string.Format(IMAGE_URL, id, size);
            return this.GetByteArray(url);
        }

        public void CreateImage(string id, byte[] image, string filename, string fileType) {
            var request = this.CreateRestRequest(RestSharp.Method.PUT, string.Format(IMAGE_URL, id), "application/octet-stream");
            request.AddFileBytes("stream", image, filename, fileType);
            var response = this.ExecuteGenericRequest(request);
        }

        public void UpdateImage(string id, byte[] image, string filename, string fileType, string imageID) {
            var request = this.CreateRestRequest(RestSharp.Method.PUT, string.Format(IMAGE_UPDATE_URL, id, imageID), "application/octet-stream");
            request.AddFileBytes("stream", image, filename, fileType);
            var response = this.ExecuteGenericRequest(request);
        }
    }
}
