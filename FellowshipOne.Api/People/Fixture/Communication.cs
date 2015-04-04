using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using FellowshipOne.Api.People.Model;

namespace FellowshipOne.Api.People.Fixture {
    public class CommunicationBuilder : FellowshipOne.Api.IBuilder<FellowshipOne.Api.People.Model.Communication> {
        private int _id = 1;
        private int _householdID = 1;
        private int _personID = 1;
        private int _communicationTypeID = 1;
        private string _communicationValue = "1231231234";
        private string _communicationTypeName = "Home Phone";

        public static CommunicationBuilder Communication() {
            return new CommunicationBuilder();
        }


        public CommunicationBuilder WithID(int id) {
            _id = id;
            return this;
        }

        public CommunicationBuilder WithHouseholdID(int id) {
            _householdID = id;
            return this;
        }

        public CommunicationBuilder WithPersonID(int id) {
            _personID = id;
            return this;
        }

        public CommunicationBuilder WithCommunicationTypeID(int id) {
            _communicationTypeID = id;
            return this;
        }

        public CommunicationBuilder WithValue(string value) {
            _communicationValue = value;
            return this;
        }

        public CommunicationBuilder WithCommunicationTypeName(string name) {
            _communicationTypeName = name;
            return this;
        }

        public Communication Build() {
            return new Model.Communication {
                ID = _id,
                Household = new ParentObject { ID = _householdID },
                Person = new ParentObject { ID = _personID },
                CommunicationType = new ParentNamedObject { ID = _communicationTypeID, Name = _communicationTypeName },
                CommunicationValue = _communicationValue
            };
        }
    }
}
