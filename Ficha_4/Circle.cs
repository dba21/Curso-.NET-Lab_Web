using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_4
{
    //esta class vai herdar da class Shape
    public class Circle : Shape
    {
        private double radius;

        public Circle()
        {
            this.Position = new Point();
            this.radius = 0;
        }
            //Construtor por parametros

        public Circle(Point position, double radius)
            {
                this.position = position;
                this.radius = radius;
            }
        //Metodo, override ignora o da class objeto e usa este, ignora os metodos abstratos da class shape
        public override double Area()
        {
            return Math.PI * Math.Pow(radius , 2);
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return Position.ToString() + ", Radius: " + this.radius;
        }



    }
}
