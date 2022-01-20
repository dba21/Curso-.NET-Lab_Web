// See https://aka.ms/new-console-template for more information

//Name space
using Ficha_4;


/*
//Nome da Classe, nome da instância = new Nome Classe(...)
Point p1 = new Point();

Point p2 = new Point(10,20);

Console.WriteLine(p1.GetX()); 
Console.WriteLine(p2.GetY());

p1.SetX(100);
p1.SetY(20);

Console.WriteLine(p1.GetX());

p1.SetXY(9, 9);
Console.WriteLine(p1.GetX());
Console.WriteLine(p1.Gety());


*/

/*
Point p1 = new Point(1,1);

Point p2 = new Point(4,4);

double distance = p1.DistanceTo(p2);

Console.WriteLine(p1.DistanceTo(p2));
*/
//inicia o Triangulo
Point p1 = new Point(1, 1); //invocação do objeto chamado p

Point p2 = new Point(4, 4); //invocação do objeto chamado p

Point p3 = new Point(6, 6); 

Triangle t1 = new Triangle();
Triangle t2 = new Triangle(p1, p2, p3);

//Rectangle r1= new Rectangle();
//Rectangle r2 = new Rectangle(new Point(0, 5), 5, 5);

Circle circle = new Circle();
Circle circle2 = new Circle(new Point (5, 5), 10);


double height = t2.Height();
double area = t1.Area();

Console.WriteLine(t2.Height());
Console.WriteLine(t1.Area());


Rectangle r1= new Rectangle();
Rectangle r2= new Rectangle(new Point (0, 5), 5, 5);

double areaRect = r2.Area();
double perimRect = r2.Perimetro();

Console.WriteLine("Area Retangulo: " + areaRect );
Console.WriteLine("O Perímetro do Retangulo: " + perimRect);
Point point = new Point(1, 4); // criar nova instancia para saber o point 1,4

Point point2 = new Point(6, 2);

bool contains = r2.Contains(point);//envocação do metodo
bool contains2 = r2.Contains(point2); 
Console.WriteLine("O ponto 1,4 esta dentro do rectangulo? {0} " , r2.Contains(point));
Console.WriteLine("O ponto 6,2 esta dentro do rectangulo? {0} ", r2.Contains(point2));

Circle  c1 = new Circle();
Circle c2 = new Circle(new Point (5, 5), 5);

double areaC = c2.Area();
double perimeterC =c2.Perimeter();

Console.WriteLine("Area do circulo: " + areaC);
Console.WriteLine("Posição do circulo: " + c2.position);

Console.WriteLine(c2.ToString());