using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.People.Model;
using FellowshipOne.Api.Model;

namespace FellowshipOne.Api.People.Fixture {
    public class HouseholdBuilder : IBuilder<Household> {
        private int _id = 1;
        private string _oldid = "2";
        private string _hcode = "adsfa23rfv44";
        private string _householdName = "jim bob household";
        private string _householdSortName = "jim bob household";
        private string _householdFirstName = "jim";

        public static HouseholdBuilder Household() {
            return new HouseholdBuilder();
        }

        public HouseholdBuilder WithID(int id) {
            this._id = id;
            return this;
        }

        public HouseholdBuilder WithOldID(string id) {
            this._oldid = id;
            return this;
        }

        public HouseholdBuilder WithHCode(string id) {
            this._hcode = id;
            return this;
        }

        public HouseholdBuilder WithHouseholdName(string householdName) {
            this._householdName = householdName;
            return this;
        }

        public HouseholdBuilder WithHouseholdSortName(string sortName) {
            this._householdSortName = sortName;
            return this;
        }

        public HouseholdBuilder WithHouseholdFirstName(string firstname) {
            this._householdFirstName = firstname;
            return this;
        }

        public Household Build() {
            return new Household {
                ID = _id,
                OldID = _oldid,
                HCode = _hcode,
                HouseholdName = _householdName,
                HouseholdSortName = _householdSortName,
                HouseholdFirstName = _householdFirstName
            };
        }
    }
}
