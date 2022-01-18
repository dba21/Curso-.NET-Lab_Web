using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_4
{
    public abstract class Shape
    {
        internal Point position; //, por omição fazemos esta class sempre pirvate, atributo Point chamado position
         //construtor por omição
         public Shape() //n recebe argumentos
        {
            position = new Point();
        }

        //construtor por parametros, com atributos
        public Shape (Point position)
        {
                // atributo = argumento
            this.position = position;
        }

        //Definição dos Metodos
        public Point Position 
        { 
            get { return position; }
            set { position = value; }
        }

        //Métodos abstratos só providenciam a assinatura do método
        public abstract double Area();

        public abstract double Perimeter();
    }
}
