using System;
using Class_and_Object.Math;

namespace Class_and_Object
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Person person = new Person();
			person.firstName = "Sabbir Hasan";
			person.lastName = "Anik";
			person.fullName();

			Calculator calculator = new Calculator();
			Console.WriteLine(calculator.add(5, 6));
		}
	}
}
