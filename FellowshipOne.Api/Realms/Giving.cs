using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api.Realms {
    public class Giving {
        
        #region Properties
        F1OAuthTicket _ticket { get; set; }
        string _baseUrl { get; set; }

        private FellowshipOne.Api.Giving.Sets.Batches _batches;
        public FellowshipOne.Api.Giving.Sets.Batches Batches {
            get {
                if (_batches == null) {
                    _batches = new FellowshipOne.Api.Giving.Sets.Batches(_ticket, _baseUrl);
                }
                return _batches;
            }
        }

        private FellowshipOne.Api.Giving.Sets.RDCBatches _rDCBatches;
        public FellowshipOne.Api.Giving.Sets.RDCBatches RDCBatches
        {
            get
            {
                if (_rDCBatches == null)
                {
                    _rDCBatches = new FellowshipOne.Api.Giving.Sets.RDCBatches(_ticket, _baseUrl);
                }
                return _rDCBatches;
            }
        }

        private FellowshipOne.Api.Giving.Sets.RDCBatchItems _rDCBatchItems;
        public FellowshipOne.Api.Giving.Sets.RDCBatchItems RDCBatchItems
        {
            get
            {
                if (_rDCBatchItems == null)
                {
                    _rDCBatchItems = new FellowshipOne.Api.Giving.Sets.RDCBatchItems(_ticket, _baseUrl);
                }
                return _rDCBatchItems;
            }
        }

        private FellowshipOne.Api.Giving.Sets.ReferenceImages _referenceImages;
        public FellowshipOne.Api.Giving.Sets.ReferenceImages ReferenceImages {
            get {
                if (_referenceImages == null) {
                    _referenceImages = new FellowshipOne.Api.Giving.Sets.ReferenceImages(_ticket, _baseUrl);
                }
                return _referenceImages;
            }
        }

        private FellowshipOne.Api.Giving.Sets.Funds _funds;
        public FellowshipOne.Api.Giving.Sets.Funds Funds {
            get {
                if (_funds == null) {
                    _funds = new FellowshipOne.Api.Giving.Sets.Funds(_ticket, _baseUrl);
                }
                return _funds;
            }
        }

        private FellowshipOne.Api.Giving.Sets.PledgeDrives _pledgeDrives;
        public FellowshipOne.Api.Giving.Sets.PledgeDrives PledgeDrives {
            get {
                if (_pledgeDrives == null) {
                    _pledgeDrives = new FellowshipOne.Api.Giving.Sets.PledgeDrives(_ticket, _baseUrl);
                }
                return _pledgeDrives;
            }
        }


        private FellowshipOne.Api.Giving.Sets.SubFunds _subFunds;
        public FellowshipOne.Api.Giving.Sets.SubFunds SubFunds {
            get {
                if (_subFunds == null) {
                    _subFunds = new FellowshipOne.Api.Giving.Sets.SubFunds(_ticket, _baseUrl);
                }
                return _subFunds;
            }
        }


        private FellowshipOne.Api.Giving.Sets.ContributionReceipts _contributionReceipts;
        public FellowshipOne.Api.Giving.Sets.ContributionReceipts ContributionReceipts {
            get {
                if (_contributionReceipts == null) {
                    _contributionReceipts = new FellowshipOne.Api.Giving.Sets.ContributionReceipts(_ticket, _baseUrl);
                }
                return _contributionReceipts;
            }
        }
        #endregion Properties

        #region Constructor
        public Giving(F1OAuthTicket ticket, string baseUrl) {
            _ticket = ticket;
            _baseUrl = baseUrl;
        }
        #endregion Constructor
    }
}
