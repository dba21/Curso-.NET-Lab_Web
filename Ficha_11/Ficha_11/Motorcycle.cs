using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_11
{
    public class Motorcycle : Vehicle
    {
        public enum Models
        {
            SPORT,
            CRUISER,
            ADVENTURE,
        }

        protected int topSpeed;

        public Motorcycle(int topSpeed)
        {
            this.topSpeed = topSpeed;
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
