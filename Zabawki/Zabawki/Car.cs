using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabawki
{
    class Car : IAccelerate
    {
        public int speed { get; private set; } = 0;


        public void Accelerate(int amount)
        {
            this.speed = amount;
        }
    }
}
