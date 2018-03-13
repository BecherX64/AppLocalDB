using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocalDB
{
	class Program
	{
		static void Main(string[] args)
		{
			//define Context as DB model
			var Context = new Model1();
			//define People as Products Table from DB
			var People = Context.Products;

			//List all items and show only ones containing "o" - foreach (var Person in People.Where(item => item.Name.Contains("o")))
			foreach (var Person in People)
			{
				Console.WriteLine("Name:{0}",Person.Name);
			}
			Console.WriteLine();

			//define man as first item from DB
			var man = People.First();
			Console.WriteLine("{0}", man.Name);

			Console.WriteLine();
			//give me first item starts with "J"
			//man = People.First(item => item.Name.StartsWith("J"));
			//Console.WriteLine("{0}", man.Name);

			//rename first item name to "Nove  Meno"
			man.Name = "Nove Meno";
			Context.SaveChanges();
			//list DB content again with saved changes
			People = Context.Products;
			foreach (var Person in People)
			{
				Console.WriteLine("Name:{0}", Person.Name);
			}
			Console.WriteLine();

			//remove item from DB - var man is pointing to "Nove Meno"
			Context.Products.Remove(man);
			Context.SaveChanges();

			People = Context.Products;
			foreach (var Person in People)
			{
				Console.WriteLine("Name:{0}", Person.Name);
			}


			Console.WriteLine("Press any key. ..");
			Console.ReadKey(false);
		}
	}
}
