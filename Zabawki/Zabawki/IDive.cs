using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabawki
{
    interface IDive
    {
        int submersion { get;}
        void Dive(int amount);
    }
}
