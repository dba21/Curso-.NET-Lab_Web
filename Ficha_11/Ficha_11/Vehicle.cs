using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_11
{
    public enum Travel
    {
        LAND,
        Water,
        AIR,
    }

    public abstract class Vehicle : IVehicle
    {
        private string color;
        private string weight;
        private string brand;
        private Engine engine;
        private Travel travel;
        public Travel Travel { get { return travel; } }

        public Vehicle(Travel travel, string color, string weight, string brand, string model, Engine engine)
        {
            this.travel = travel;
            this.color = color;
            this.weight = weight;
            this.brand = brand;
            this.engine = engine;
        }

        protected Vehicle(string brand, Engine engine, Travel travel)
        {
            this.brand = brand;
            this.engine = engine;
            this.travel = travel;
        }

        public abstract void Start();
       
    }
}
