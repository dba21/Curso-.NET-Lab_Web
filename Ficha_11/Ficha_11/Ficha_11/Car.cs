using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_11
{
    public class Car
    {
        private int doors;
        private int seats;

        
        public Car()
        {
            this.doors = 0;
            this.seats = 0;
        }

        public Car(int doors, int seats)
        {
            this.doors = doors;
            this.seats = seats;
        }
        public override string ToString()
        {
            string str = "";

            str += "Number of doors: " + doors + ", ";
            str += ", places: " + seats + " .";

            return str;
        }

    }
}
