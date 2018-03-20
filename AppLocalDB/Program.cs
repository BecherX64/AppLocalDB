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
			var Context = new MyAppDBModel1();
			
			//define People as Products Table from DB
			//Select using LING ???
			var People = Context.Products;
			


			//List all items and show only ones containing "o" - foreach (var Person in People.Where(item => item.Name.Contains("o")))
			foreach (var Person in People)
			{
				
				Console.WriteLine("Name:{0}",Person.Name);
			}
			Console.WriteLine();

			#region Clasic Select using Context varible
			// "c" is arbitrary - must have, some kind of defau;t variable for table
			//Normal Select
			var query1 = from c in Context.Products select c;
			Console.WriteLine("var query1 = from c in Context.Products select c;");
			foreach (var man in query1)
			{
				Console.WriteLine("{0}: {1} - {2}",man.Id,man.Name,man.Desc);
			}
			//Another type of select
			var query2 = from c in Context.Products where c.Id > 2 select c.Name;

			//Select first 2 item order by name
			var query3 = (from c in Context.Products orderby c.Name select c).Take(2);
			Console.WriteLine("var query3 = (from c in Context.Products orderby c.Name select c).Take(2);");
			foreach (var man in query3)
			{
				Console.WriteLine("{0}: {1} - {2}", man.Id, man.Name, man.Desc);
			}

						 #endregion



			Console.WriteLine("Press any key. ..");
			Console.ReadKey(false);
		}
	}
}
