using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocalDB
{
	class AppLocalDBMain
	{
		static void Main(string[] args)
		{
			//define Context as DB model
			var Context = new MyAppDBModel1();

			#region Select from DB
			//define People as Products Table from DB
			//Select whole table Products
			var People = Context.Products.OrderBy(item => item.Name);
			
			//List all items and show only ones containing "o" - foreach (var Person in People.Where(item => item.Name.Contains("o"))) - Select using LING and Lambda
			foreach (var Person in People)
			{
				Console.WriteLine("Name:{0}",Person.Name);
			}
			Console.WriteLine();
			#endregion

			var query0 = from c in Context.Products orderby c.Name select c;
			foreach (var Person in query0)
			{
				Console.WriteLine("ID: {0} - Name: {1} - Desc: {2}",Person.Id, Person.Name, Person.Desc);
			}


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

			#region Modify Data in DB
			//Check DB properties "Copy to output Directory"

			Console.WriteLine("Select person");
			int ChoosenID = int.Parse(Console.ReadLine());
			var personToUpdate = (from c in Context.Products where c.Id == ChoosenID select c).SingleOrDefault();
			Console.WriteLine("Enter new name for person ID: {0} - Name: {1}",personToUpdate.Id, personToUpdate.Name);
			personToUpdate.Name = Console.ReadLine();
			try
			{
				Context.SaveChanges();
				Console.WriteLine("Changes saved");
			}
			catch (Exception ex)
			{

				Console.WriteLine("{Error :0}",ex.Message);
			}
			#endregion


			#region List all data at the end
			var query4 = from c in Context.Products select c;
			foreach (var man in query4)
			{
				Console.WriteLine("{0}:{1} - {2} ",man.Id,man.Name,man.Desc);
			}

			#endregion

			#region Add item in DB
			int maxProdId = (from c in Context.Products select c.Id).Max();

			try
			{
				Console.WriteLine("Max ID: {0}",maxProdId);
				Context.Products.Add(new Product() { Id = maxProdId+1, Name = "Alibaba", Desc = "Rum bum bum" });
				Context.SaveChanges();
			}
			catch (Exception)
			{
				Console.WriteLine("Record not saved !");
				throw;
			}
			#endregion
			//query again and list data
			var query5 = from c in Context.Products select new {c.Id, c.Name};
			foreach (var man in query5)
			{
				Console.WriteLine("{0}:{1}", man.Id, man.Name);
			}



			Console.WriteLine("Press any key. ..");
			Console.ReadKey(false);
		}
	}
}
