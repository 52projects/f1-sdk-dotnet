﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Realms {
    public class Groups {
        #region Properties
        F1OAuthTicket _ticket { get; set; }
        string _baseUrl { get; set; }

        private FellowshipOne.Api.Groups.Sets.Members _members;
        public FellowshipOne.Api.Groups.Sets.Members Members {
            get {
                if (_members == null) {
                    _members = new Api.Groups.Sets.Members(_ticket, _baseUrl);
                }
                return _members;
            }
        }

        private FellowshipOne.Api.Groups.Sets.GroupTypes _groupTypes;
        public FellowshipOne.Api.Groups.Sets.GroupTypes GroupTypes {
            get {
                if (_groupTypes == null) {
                    _groupTypes = new Api.Groups.Sets.GroupTypes(_ticket, _baseUrl);
                }
                return _groupTypes;
            }
        }

        #endregion Properties

        #region Constructor
        public Groups(F1OAuthTicket ticket, string baseUrl) {
            _ticket = ticket;
            _baseUrl = baseUrl;
        }
        #endregion Constructor
    }
}
