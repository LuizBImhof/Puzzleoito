using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzleoito
{
    class Comparador : IComparer<Nodo>
    {
        public int Compare(Nodo x, Nodo y)
        {
            return x.par2 - y.par2;
        }
    }
}
