using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using FellowshipOne.Api.People.Model;

namespace FellowshipOne.Api.People.Fixture {
    public class PersonBuilder : IBuilder<Person> {
        private int _id = 1;
        private int _householdID = 1;
        private string _firstName = "Jim";
        private string _lastName = "Bob";
        private string _gender = "";
        private string _maritalStatus = "";
        private DateTime? _dateOfBirth = null;

        public static PersonBuilder Person() {
            return new PersonBuilder();
        }

        public Person Build() {
            return new Person() {
                ID = this._id,
                HouseholdID = this._householdID,
                FirstName = this._firstName,
                LastName = this._lastName,
                Gender = this._gender,
                MaritalStatus = this._maritalStatus,
                DateOfBirth = this._dateOfBirth
            };
        }

        public PersonBuilder WithID(int id) {
            this._id = id;
            return this;
        }

        public PersonBuilder WithFirstName(string firstName) {
            this._firstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName) {
            this._lastName = lastName;
            return this;
        }

        public PersonBuilder WithHouseholdID(int householdID) {
            this._householdID = householdID;
            return this;
        }

        public PersonBuilder WithGender(string gender) {
            this._gender = gender;
            return this;
        }

        public PersonBuilder WithMaritalStatus(string maritalStatus) {
            this._maritalStatus = maritalStatus;
            return this;
        }

        public PersonBuilder WithDateOfBirth(DateTime dateOfBirth) {
            this._dateOfBirth = dateOfBirth;
            return this;
        }
    }
}
