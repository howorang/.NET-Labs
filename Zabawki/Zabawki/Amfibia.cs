using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabawki
{
    class Amfibia : IDive, IAccelerate
    {
        public int speed
        { get; private set;}

        public int submersion
        { get; private set;}

        public void Accelerate(int amount)
        {
            speed = amount;
        }

        public void Dive(int amount)
        {
            submersion = amount;
        }
    }
}
