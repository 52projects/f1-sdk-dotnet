
namespace FellowshipOne.Api.People.Sets {
    public class Accounts : ApiSet<Model.School> {
        private const string CREATE_URL = "/v1/people/accounts";

        public Accounts(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string CreateUrl { get { return CREATE_URL; } }
    }
}