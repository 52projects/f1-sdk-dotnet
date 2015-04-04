using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.People.Model;

namespace FellowshipOne.Api.People.Fixture {
    public class AddressCollectionBuilder : ICollectionBuilder<List<Address>> {
        private string[] _address1;
        private int[] _types;

        public static AddressCollectionBuilder AddressCollection() {
            return new AddressCollectionBuilder();
        }

        public List<Address> Build(int count) {
            var addressCollection = new List<Address>();
            for (var i = 1; i <= count; i++) {
                AddressBuilder address = AddressBuilder.Address().WithID(i);

                if (_address1.Length > 0) {
                    address = address.WithAddress1(_address1[i]);
                }

                if (_types.Length > 0) {
                    address = address.WithAddressTypeID(_types[i]);
                }

                addressCollection.Add(address.Build());
            }
            return addressCollection;
        }

        public AddressCollectionBuilder WithAddress1(params string[] address1) {
            this._address1 = address1;
            return this;
        }

        public AddressCollectionBuilder WithAddressTypes(params int[] types) {
            this._types = types;
            return this;
        }
    }
}