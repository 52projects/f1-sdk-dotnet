using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Realms {
    public class F1Activities {
        #region Properties
        F1OAuthTicket _ticket { get; set; }
        string _baseUrl { get; set; }

        private FellowshipOne.Api.Activities.Sets.Ministries _ministries;
        public FellowshipOne.Api.Activities.Sets.Ministries Ministries {
            get {
                if (_ministries == null) {
                    _ministries = new FellowshipOne.Api.Activities.Sets.Ministries(_ticket, _baseUrl);
                }
                return _ministries;
            }
        }

        private FellowshipOne.Api.Activities.Sets.Activities _activities;
        public FellowshipOne.Api.Activities.Sets.Activities Activities {
            get {
                if (_activities == null) {
                    _activities = new FellowshipOne.Api.Activities.Sets.Activities(_ticket, _baseUrl);
                }
                return _activities;
            }
        }
        #endregion Properties

        #region Constructor
        public F1Activities(F1OAuthTicket ticket, string baseUrl) {
            _ticket = ticket;
            _baseUrl = baseUrl;
        }
        #endregion Constructor
    }
}
