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

        private FellowshipOne.Api.Activities.Sets.Schedules _schedules;
        public FellowshipOne.Api.Activities.Sets.Schedules Schedules {
            get {
                if (_schedules == null) {
                    _schedules = new FellowshipOne.Api.Activities.Sets.Schedules(_ticket, _baseUrl);
                }
                return _schedules;
            }
        }

        private FellowshipOne.Api.Activities.Sets.Rosters _rosters;
        public FellowshipOne.Api.Activities.Sets.Rosters Rosters {
            get {
                if (_rosters == null) {
                    _rosters = new FellowshipOne.Api.Activities.Sets.Rosters(_ticket, _baseUrl);
                }
                return _rosters;
            }
        }

        private FellowshipOne.Api.Activities.Sets.RosterFolders _rosterFolders;
        public FellowshipOne.Api.Activities.Sets.RosterFolders RosterFolders {
            get {
                if (_rosterFolders == null) {
                    _rosterFolders = new FellowshipOne.Api.Activities.Sets.RosterFolders(_ticket, _baseUrl);
                }
                return _rosterFolders;
            }
        }

        private FellowshipOne.Api.Activities.Sets.Instances _instances;
        public FellowshipOne.Api.Activities.Sets.Instances Instances {
            get {
                if (_instances == null) {
                    _instances = new FellowshipOne.Api.Activities.Sets.Instances(_ticket, _baseUrl);
                }
                return _instances;
            }
        }

        private FellowshipOne.Api.Activities.Sets.ActivityTypes _types;
        public FellowshipOne.Api.Activities.Sets.ActivityTypes ActivityTypes {
            get {
                if (_types == null) {
                    _types = new FellowshipOne.Api.Activities.Sets.ActivityTypes(_ticket, _baseUrl);
                }
                return _types;
            }
        }

        private FellowshipOne.Api.Activities.Sets.Assignments _assignments;
        public FellowshipOne.Api.Activities.Sets.Assignments Assignments {
            get {
                if (_assignments == null) {
                    _assignments = new FellowshipOne.Api.Activities.Sets.Assignments(_ticket, _baseUrl);
                }
                return _assignments;
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
