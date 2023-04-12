using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineComparisonProblem
{
    public class Line : IComparable<Line>
    {
        public double x1, y1, x2, y2;

        public Line(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Line other = (Line)obj;
            return x1 == other.x1 && y1 == other.y1 && x2 == other.x2 && y2 == other.y2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + x1.GetHashCode();
                hash = hash * 23 + y1.GetHashCode();
                hash = hash * 23 + x2.GetHashCode();
                hash = hash * 23 + y2.GetHashCode();
                return hash;
            }
        }

        public int CompareTo(Line other)
        {
            double length1 = this.Length();
            double length2 = other.Length();

            if (length1 == length2)
            {
                return 0;
            }
            else if (length1 > length2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }


    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Line Comparison Computation");
            Line line1 = new Line(0, 0, 1, 1);
            Line line2 = new Line(0, 0, 1, 1);
            Line line3 = new Line(0, 0, 1, 2);

            Console.WriteLine("Line 1 length: " + line1.Length()); 
            Console.WriteLine("Line 1 equals Line 2: " + line1.Equals(line2));
            Console.WriteLine("Line 1 equals Line 3: " + line1.Equals(line3)); 
            Console.WriteLine("Line 1 compared to Line 2: " + line1.CompareTo(line2)); 
            Console.WriteLine("Line 1 compared to Line 3: " + line1.CompareTo(line3));
            Console.ReadLine();
        }
    }
}
