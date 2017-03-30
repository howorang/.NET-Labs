using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabawki
{
    class Boat : IDive
    {
        public int submersion { get; private set; } = 0;


        public void Dive(int amount)
        {
            this.submersion = amount;
        }
    }
}
