using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api {
    public interface ICollectionBuilder<T> {
        T Build(int count);
    }
}