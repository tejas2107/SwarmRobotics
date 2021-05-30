using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{class Point
    {
        public double X;
        public double Y;
        public Point(double a,double b)
        {
            X = a;
            Y = b;
        }
    }
 class Vector
    {
        public double i;
        public double j;
        public Vector(double x_comp,double y_comp)
        {
            i = x_comp;
            j = y_comp;

        }
    }
 abstract class Region
    { public abstract bool contains(Point A);
      public abstract void rotate(double Angle);
      public abstract void translate(Vector A );}
 class Triangle : Region
    {
        public Point A;
        public Point B;
        public Point C;

        public Triangle(Point P1,Point P2,Point P3) { A = P1;B = P2;C = P3; }
        public double area(Point a, Point b,Point c)
        {
            double x1 = a.X;
            double y1 = a.Y;
            double x2 = b.X;
            double y2 = b.Y;
            double x3 = c.X;
            double y3 = c.Y;


            return Math.Abs((x1 * (y2 - y3) +
                             x2 * (y3 - y1) +
                             x3 * (y1 - y2)) / 2.0);
        }
        public override bool contains(Point Z)
        {
            double x = Z.X;
            double y = Z.Y;
            double A1 = area(Z,A,B);
            double A2 = area(Z,B,C);
            double A3 = area(Z,A,C);
            double X = area(A,B,C);
            if (A1 + A2 + A3 == X) { return true; }
            else { return false; }
        }
        
        public override void translate(Vector L)
        {
            A.X = A.X + L.i;
            A.Y = A.Y + L.j;
            B.X = B.X + L.i;
            B.Y = B.Y + L.j;
            C.X = C.X + L.i;
            C.Y = C.Y + L.j;}
        public override void rotate(double angle)
        {
            double X1 = A.X;
            double Y1 = A.Y;
            double X2 = B.X;
            double Y2 = B.Y;
            double X3 = C.X;
            double Y3 = C.Y;
            double x = (X1 + X2 + X3) / 3;
            double y = (Y1 + Y2 + Y3) / 3;
            Vector S=new Vector(-x,-y);
            translate(S);
            X1 = X1 * Math.Cos(angle) - Y1 * Math.Sin(angle);
            Y1 = X1 * Math.Sin(angle) + Y1 * Math.Cos(angle);
            X2 = X2 * Math.Cos(angle) - Y2 * Math.Sin(angle);
            Y2 = X2 * Math.Sin(angle) + Y2 * Math.Cos(angle);
            X3 = X3 * Math.Cos(angle) - Y3 * Math.Sin(angle);
            Y3 = X3 * Math.Sin(angle) + Y3 * Math.Cos(angle);
            A.X = X1;
            A.X = Y1;
            B.X = X2;
            B.Y = Y2;
            C.X = X3;
            C.Y = Y3;
            S.i = +x;
            S.j = +y;
            translate(S);

        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Point V1 = new Point(0, 0);
            Point V2 = new Point(10, 0);
            Point V3 = new Point(0, 10);

            Vector V4 =new Vector(2,3);

            Triangle T = new Triangle(V1, V2, V3);

            
            Console.WriteLine(T.contains(new Point(1, 9)));
            T.translate(new Vector(-1, -5));
            Console.WriteLine(T.contains(new Point(1, 9)));
            Console.ReadKey();
        }
    }
}
