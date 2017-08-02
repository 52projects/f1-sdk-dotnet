using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowshipOne.Api {
    interface IBuilder<T> {
        T Build();
    }
}
