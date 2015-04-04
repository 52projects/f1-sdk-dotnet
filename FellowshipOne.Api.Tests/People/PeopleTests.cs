using NUnit.Framework;
using Shouldly;
using FellowshipOne.Api.People.QueryObject;

namespace FellowshipOne.Api.Tests.People {
    [TestFixture]
    public class PeopleTests : Base {

        [Test]
        public void people_get_by_url() {
            var person = RestClient.PeopleRealm.People.GetByUrl(Ticket.PersonURL);
            person.ShouldNotBe(null);
        }

        [Test]
        public void people_search() {
            var qo = new PeopleQO();
            qo.Name = "sm";
            qo.RecordsPerPage = 5;

            var people = RestClient.PeopleRealm.People.Search<FellowshipOne.Api.People.Model.PersonCollection>(qo);
            people.ShouldNotBe(null);
            people.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void people_create_get_xml_does_not_save() {
            var person = new FellowshipOne.Api.People.Model.Person();
            person.FirstName = "chad";

            string requestXml = string.Empty;

            try {
                person = RestClient.PeopleRealm.People.Create(person, out requestXml);
            }
            catch (System.Exception e) {
            }

            requestXml.ShouldNotBeEmpty();

        }

        [Test]
        public void people_update_get_xml_does_save() {
            var qo = new PeopleQO();
            qo.Name = "chad meyer";
            qo.RecordsPerPage = 5;

            var people = RestClient.PeopleRealm.People.Search<FellowshipOne.Api.People.Model.PersonCollection>(qo);
            var person = people[0];
            person.Status.SubStatuses = null;
            person.Addresses = null;
            person.Communications = null;

            RestClient.PeopleRealm.People.Update(person, person.ID.ToString());
        }
    }
}
