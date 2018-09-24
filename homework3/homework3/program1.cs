using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace homework3
{
    //工厂类
    public class ShapeFactory {
        //定义静态工厂方法用于不同对象的创建
        public static Shape CreateShape(string shapeName)
        {
            Shape shape = null;
            switch (shapeName)
            {
                case "triangle":
                    //输入相应的数据
                    Console.Write("Please input two numbers as baseside and height of triangle: ");
                    string sBaseSide = "";
                    sBaseSide = Console.ReadLine();
                    double baseSide = Double.Parse(sBaseSide);
                    string sHeight = "";
                    sHeight = Console.ReadLine();
                    double height = Double.Parse(sHeight);

                    shape = new Triangle(baseSide,height, "triangle");
                    return shape;
                case "square":
                    Console.Write("Please input a number as side of square: ");
                    string s = "";
                    s = Console.ReadLine();
                    double side = Double.Parse(s);

                    shape = new Square(side,"square");
                    return shape;
                case "rectangle":
                    Console.Write("Please input two numbers as longth and width of rectangle: ");
                    string sLongth = "";
                    sLongth = Console.ReadLine();
                    double longth = Double.Parse(sLongth);
                    string sWidth = "";
                    sWidth = Console.ReadLine();
                    double width = Double.Parse(sWidth);

                    shape = new Rectangle(longth, width, "rectangle");
                    return shape;
               case "circle":
                    Console.Write("Please input a number as radius of circle: ");
                    string sRadius = "";
                    sRadius = Console.ReadLine();
                    double radius = Double.Parse(sRadius);

                    shape = new Circle(radius, "circle");
                    return shape;
                default:

                    return null;
            }
        }
    }
    //抽象方法类
    public abstract class Shape
    {
        //获取图形类型
        private string whatShape;

        public Shape(string s)
        {
            receiveShape = s;
        }
        public string receiveShape
        {
            get { return whatShape; }
            set { whatShape = value; }
        }
        public abstract double Area
        {
            get;
        }
        public override string ToString()
        {
            return "You have created a " + receiveShape + ", its area is " + string.Format("{0:F2}", Area);
        }
    }

    public class Triangle:Shape
    {
        private double baseSide;//底
        private double height;//高

        public Triangle(double baseSide, double height,string shape):base(shape)
        {
            this.baseSide = baseSide;
            this.height = height;
        }
        public override double Area
        {
            get { return 0.5 * baseSide * height; }
        }
    }

    public class Square : Shape
    {
        private double side;

        public Square(double side, string shape) : base(shape)
        {
            this.side = side;
        }
        public override double Area
        {
            get { return side*side; }
        }
    }

    public class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width, string shape) : base(shape)
        {
            this.length = length;
            this.width = width;
        }
        public override double Area
        {
            get { return length * width; }
        }
    }

    public class Circle : Shape
    {
        private double radius;
        
        public Circle(double radius, string shape) : base(shape)
        {
            this.radius = radius;
        }
        public override double Area
        {
            get { return radius*radius*Math.PI; }
        }
    }

    class program1
    {
        static void Main(string[] args)
        {
            //利用数组将创建的对象输出到控制台
            Shape[] shapes = { ShapeFactory.CreateShape("triangle"),
                               ShapeFactory.CreateShape("rectangle"),
                               ShapeFactory.CreateShape("square"),
                               ShapeFactory.CreateShape("circle")
                             };
            Console.WriteLine("The result: ");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }
            Console.Write("Done!!!");
        }
    }
}
