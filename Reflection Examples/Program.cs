using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Examples
{
	class Program
	{
		static void Main(string[] args)
		{
			//using  reflection
			//Type type = Type.GetType("Reflection_Examples.Employee"); // another way
			//														  //Type type = typeof(Employee)

			////get some characteristics of the assembly
			//Console.WriteLine("The full name of the type is {0}", type.FullName);
			//Console.WriteLine("The name of the type is {0}", type.Name);
			//Console.WriteLine("The namespace of the type is {0}", type.Namespace);


			//Console.WriteLine();
			//Console.WriteLine("==================================================================");
			//Console.WriteLine();

			////find all the public propertis in the assembly
			//PropertyInfo[] infos = type.GetProperties();
			//Console.WriteLine("The available public propeties in this project are:");
			//foreach(PropertyInfo propertyInfo in infos)
			//{
			//	Console.WriteLine(propertyInfo.Name);
			//}


			//Console.WriteLine();
			//Console.WriteLine("==================================================================");
			//Console.WriteLine();


			////Find all the method in the Assembly
			//MethodInfo[] methods = type.GetMethods();
			//Console.WriteLine("The available methods in this project are:");
			//foreach (MethodInfo methodInfo in methods)
			//{
			//	Console.WriteLine(methodInfo.ReflectedType.Name);
			//	Console.WriteLine(methodInfo.Name);
			//}



			//Lazy loading with Reflection. This is done at runtime
			Assembly executable = Assembly.GetExecutingAssembly();
			Type _type = executable.GetType("Reflection_Examples.Employee");

			object objExecutable = Activator.CreateInstance(_type);

			MethodInfo methodInfo = _type.GetMethod("DisplayName");

			string[] parameter = new string[1];
			parameter[0] = "DigitalKenth";

			string employName = (string)methodInfo.Invoke(objExecutable, parameter);


			Console.ReadLine();
		}
	}


	class Employee
	{
		public int EmpId { get; set; }
		public string Name { get; set; }
		public double Salary { get; set; }

		public Employee()
		{
			EmpId = -1;
			Name = string.Empty;
			Salary = 0;
		}

		public Employee(int Id, string name, double salary)
		{
			EmpId = Id;
			Name = name;
			Salary = salary;
		}

		private void DisplayName()
		{
			Console.WriteLine("Name is {0}", Name);
			Console.ReadKey();
		}

		private void GetSalary()
		{
			Console.WriteLine("Salary is {0}", Salary);
		}
	}
}
