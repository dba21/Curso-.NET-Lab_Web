using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_4
{
    public class Triangle : Shape //shape já tem um ponto de referencia, temos que apagar um ponto do atributo (tipo Point) do triangulo
    {
        //Atributos
        //private  Point a { get; set; }

        private  Point b { get; set; }
        private  Point c { get; set; }

        //Construtor por omição
        public Triangle()
        {
            //a = new Point();
            b = new Point();
            c = new Point();

        }

        //Construtor por parametros, recebe os parametros, tem 3 argumentos que recebe da class
        public  Triangle(Point a, Point b, Point c)
        {
            //this.a = a;
            this.position = a;
            this.b = b;
            this.c = c;
        }

        //expor propriedade
        public Point Position //expor o seu point em letra maiuscula
        {
            get { return position; }
            set { position = value; }
        }

        public Point B
        {
            get { return b; }
            set { b = value; }
        }

        public Point C
        {
            get { return c; }
            set { c = value; }
        }

        /*
        public double CalculateWidth()
        {
            return (a.DistanceTo(b));
        }

        public double CalculateHeight()
        {
            return (a.DistanceTo(c));
        }

        public double CalculateArea()
        {
            double width = CalculateHeight();
            double heigt = CalculateHeight();

            double area = (width * heigt) / 2;
            return area;
        }
        */
         //ou podemos fazer diferente forma

        public double Base()
        {
            return position.DistanceTo(b);
        }

        public double Height()
        {
            return position.DistanceTo(c);
        }

        public override double Area()
        {
            return (Base() * Height()) / 2;
        }
        public override double Perimeter()
        {
            /*podemos fazer desta forma o calculo do Perimeter 
            double l1 = position .DistanceTo(b);
            double l2 = position .DistanceTo(c);
            double l3 = b.DistanceTo (c);

            double perimeter = l1 + l2 + l3;
            return perimeter; ou como exemplo abaixo*/

            return position.DistanceTo(b) + position.DistanceTo(c) + b.DistanceTo(c);
            
        }

    }
}
