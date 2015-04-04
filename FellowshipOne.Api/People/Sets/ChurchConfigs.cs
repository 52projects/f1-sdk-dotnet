using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using Restify;
using FellowshipOne.Api.People.Model;

namespace FellowshipOne.Api.People.Sets {
    public class ChurchConfigs : ApiSet<ChurchConfig> {
        #region Constructor
        public ChurchConfigs(F1OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }
        #endregion Constructor

        #region Properties
        protected override string GetUrl {
            get {
                return "/v1/churchconfig/";
            }
        }
        #endregion Properties

        #region Methods
        public ChurchConfig Get() {
            return base.Get(string.Empty);
        }
        #endregion
    }
}
