using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_11
{
   
    public abstract class Vehicle : IVehicle
    {
        public enum Travel
        {
            LAND,
            Water,
            AIR,
        }

        protected Travel travel;
        protected string color;
        protected int weight;
        protected string brand;
        protected string model;
        protected Engine engine;

        public Vehicle(Travel travel, string color, int weight, string brand, string model, Engine engine)
        {

        }

        public override string ToString()
        {
            return "Brand: " + brand + engine.ToString() + "Travel: " + travel;
            
        }
        public abstract void Start();
       
    }
}
