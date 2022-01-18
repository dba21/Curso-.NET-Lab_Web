using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_4
{
    public class Rectangle : Shape
    {
        //atributos
        
        private double height;
        private double width;
    

    //propriedades
    public Point TopLeftPoint
        {
        get { return position; } 
        set { position = value; }
    
    }
        public double Height
        {
            get { return height; }
            set { height = value; }

        }
        public double Width
        {
            get { return width; }
            set { width = value; }

        }

        //construtores
        public Rectangle()
    {
        this.position = new Point();
        this.height = 0;
        this.width = 0;
    }

    public Rectangle(Point topLeftPoint, double height, double width)
    {
            this.position = topLeftPoint;
            this.height = height;
            this.width = width;
    }
        //metodos
   
     public double Perimetro()
        {
            return (height * 2) + (width * 2);
        }
       
        public bool Contains(Point point)
        {
            Point topRightPoint = new Point(position.X + width, position.Y);
            Point bottomLeftPoint = new Point(position.X, position.Y - height);
            Point bottomRightPoint = new Point(topRightPoint.X, bottomLeftPoint.Y);

            if (point.X > position.X && point.X < topRightPoint.X && point.Y > bottomLeftPoint.Y && point.Y < position.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public override double Area()
        {
            return height * width;
        }

        public override double Perimeter()
        {
            return (height * 2) + (width * 2);
        }


    }
}
