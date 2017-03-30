using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabawki
{
    class Plane : IRise
    {
        public int altitude { get; private set; } = 0;


        public void Rise(int amount)
        {
            this.altitude = amount;
        }
    }
}
