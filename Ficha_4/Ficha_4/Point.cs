using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_4
{
    public  class Point
    {
        private double x; //atributo x do tipo double, implementação da class
        private double y; //atributo y do tipo double
        public Point()  // o () omissão, não tem argumentos construtor por omissão e com parâmetros
        {
            this.x = 0; //Inicializar os atributos Seletores/propriedades para aceder aos atributos
            this.y = 0;
        }

        internal double DistanceTo(Point other)
        {
            double dx = Math.Pow((other.x - this.x), 2);
            double dy = Math.Pow((other.y - this.y), 2);

            return Math.Sqrt(dx + dy);
        }

        public Point (double x, double y) //tem atributos
        {
            this.x = x;
            this.y = y;

        }

        //Metodos para alterar os valores, getters p selecionar valorers, setters p alt valores
        public void SetX (double x)
        {
            this.x = x;
        }

        public void SetY(double y)
        {
            this.y = y;
        }
        public void SetXY(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetX()
        {
            return this.x;
        }

        public double GetY()
        {
            return this.y;

        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }

        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }

        }

        public override string ToString()
        {
            return "X: " + this.X + ", Y: " + this.Y;
            
        }


    }
}
