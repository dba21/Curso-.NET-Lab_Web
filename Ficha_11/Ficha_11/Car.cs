using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_11
{
    public class Car : Vehicle
    {
        private int numberOfDoors;
        private int numberOfSeats;

        public Car(int numberOfDoors, int numberOfSeats, string brand, Engine engine,
            Travel travel) : base(brand, engine, travel)
        {
            this.numberOfDoors = 0;
            this.numberOfSeats = 0;
        }

        public override string ToString()
        {
            string str = "";

            str += "Number of doors: " + numberOfDoors + ", ";
            str += ", places: " + numberOfSeats + " .";

            return str;
        }

        public override void Start()
        {

        }
    }
}
