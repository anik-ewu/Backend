
using System;

namespace LearnClas
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        static void UseParams()
        {
            var calculator = new Calculator();
            int sum = calculator.Add(1, 2, 3, 4);
            Console.WriteLine("Sum {0}", sum);
        }
        static void UsePoint() 
        {
            try
            {
                //var person = Person.Parse("John");
                //person.Introduce("Sabbir Hasan");
                //var customer = new Customer();
                //var order = new Order();
                //customer.Orders.Add(order);

                var point = new Point(10, 20);
                //point.Move(new Point(100, 200));
                point.Move(null);

                Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);

                point.Move(200, 300);
                Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception error occured");
            }
        }
    }
}
