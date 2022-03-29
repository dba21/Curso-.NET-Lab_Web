using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_11
{
    public class Motorcycle : Vehicle
    {
        public override void Start()
        {
            throw new NotImplementedException();
        }

        public enum Models
        {
            SPORT,
            CRUISER,
            ADVENTURE,
        }

        private int topSpeed;

        public Motorcycle(Travel travel, string color, string weight, string brand, string model, Engine engine) : 
            base(travel, color, weight, brand, model, engine)
        {
            
        }

        public override string ToString()
        {
            string str = "";

            str += "The motorcycle model is: " + Models.SPORT + ", " + topSpeed;
            str += "The motorcycle model is: " + Models.CRUISER + ", " + topSpeed;
            str += "The motorcycle model is: " + Models.ADVENTURE + ", " + topSpeed;

            return str;
        }
    }
}
