using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_11
{
    public abstract class Vehicle
    {
        //private Travel travel;

        public enum Travel
            {
                LAND,
                Water,
                AIR,
            }

        public string color;
        public int weight;
        public string brand;
        public string model;
        Engine engine;

        public override string ToString()
        {
            return "Brand: " + brand;
            
        }
        public abstract void Start();
       
    }
}
