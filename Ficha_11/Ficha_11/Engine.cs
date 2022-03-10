using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_11
{
    public class Engine
    {
        private int torque;
        private int displacement;
        private int horsepower;

        public Engine(int torque, int displacement, int horsepower)
        {
            this.torque = torque;
            this.displacement = displacement;
            this.horsepower = horsepower;
        }

        public override string ToString()
        {
            return "Torque:" + torque + "Displacement: " + displacement + "HP: " + horsepower;
        }
    }

}
