using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.People.Model;

namespace FellowshipOne.Api.People.Fixture {
    public class CommunicationCollectionBuilder : ICollectionBuilder<List<Communication>> {
        private string[] _values;
        private int[] _types;

        public static CommunicationCollectionBuilder CommunicationCollection() {
            return new CommunicationCollectionBuilder();
        }

        public List<Communication> Build(int count) {
            var communicationCollection = new List<Communication>();
            for (var i = 1; i <= count; i++) {
                CommunicationBuilder communictaion = CommunicationBuilder.Communication().WithID(i);

                if (_values.Length > 0) {
                    communictaion = communictaion.WithValue(_values[i]);
                }

                if (_types.Length > 0) {
                    communictaion = communictaion.WithCommunicationTypeID(_types[i]);
                }

                communicationCollection.Add(communictaion.Build());
            }
            return communicationCollection;
        }

        public CommunicationCollectionBuilder WithValues(params string[] values) {
            this._values = values;
            return this;
        }

        public CommunicationCollectionBuilder WithCommunicationTypes(params int[] types) {
            this._types = types;
            return this;
        }
    }
}
