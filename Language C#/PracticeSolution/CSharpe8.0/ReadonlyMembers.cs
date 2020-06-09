using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpe8
{
    class ReadonlyMembers
    {
        public ReadonlyMembers()
        {
            Console.WriteLine("======================[ START ]=========================");
            RunSample();
            Console.WriteLine("=======================[ END ]==========================");
        }
        private void RunSample()
        {
            Point point = new Point()
            {
                pointX = 9.9,
                pointY = 6.6
            };
            Console.WriteLine("Point: "+point.ToString()); 
            
            point.pointX = 1.94;
            Console.WriteLine("Point: "+point.ToString());

            Rectangle rect = new Rectangle()
            {
                Height = 3.4,
                Length = 3.4
            };
            Console.WriteLine("Rectangle: "+rect.Area());
           
        }
    }
    // Mutable Struct
    class Point
    {
        public double pointX { get; set; }
        public double pointY { get; set; }
        public double Distance => Math.Sqrt(pointX * pointX + pointY * pointY);
        public override string ToString()
        {
            return $"({pointX}, {pointY}) is {Distance} from the origin.";
        }
            
    }
    struct Rectangle
    {
        public  double Length { get; set; }
        
        private double _height;
        public double Height
        {
            // Immutable readonly member
            readonly get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public readonly double Area() => Length * Height;
    }
}
