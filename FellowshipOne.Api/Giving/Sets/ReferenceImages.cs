using System.Collections.Generic;
using Restify;
using RestSharp;

namespace FellowshipOne.Api.Giving.Sets {
    public class ReferenceImages : ApiSet<dynamic> {
        private readonly string _baseUrl = string.Empty;
        private const string GET_URL = "/giving/v1/referenceimages/{0}";

        public ReferenceImages(OAuthTicket ticket, string baseUrl)
            : base(ticket, baseUrl, ContentType.XML) {
            _baseUrl = baseUrl;
        }

        public byte[] GetBytes(int id, string imageType = "gif") {
            var request = new RestRequest(Method.GET) {
                Resource = string.Format(GET_URL, id)
            };

            request.AddParameter("imagetype", imageType);

            return base.GetByteArray(string.Format(GET_URL, id));
        }
    }
}
