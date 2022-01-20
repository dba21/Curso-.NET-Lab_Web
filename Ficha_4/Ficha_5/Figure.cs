using Ficha_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_5
{
    public class Figure
    {
        //private List<int> lista de inteiros

        private List<Shape> shapes;

        public Figure() //construtor
        {
            this.shapes = new List<Shape>();
        }

        public void Add(Shape shape) //Shape tipo metodo shape nome da variavel
        {
            this.shapes.Add(shape); //this atributo da class shapes
        }

        public List<Shape> Shapes
        {
            get { return this.shapes; }
        }

    }
}
