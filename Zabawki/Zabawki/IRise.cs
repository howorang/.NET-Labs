using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabawki
{
    interface IRise
    {
        int altitude { get; }
        void Rise(int amount);
    }
}
