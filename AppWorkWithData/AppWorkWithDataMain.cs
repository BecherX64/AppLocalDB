using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWorkWithData
{
	class AppWorkWithDataMain
	{
		static void Main(string[] args)
		{


			string[] firstNames = { "Xaver", "Yxxo", "Jano", "Jozo", "Palo", "Peter", "Stefan", "Juraj", "Daniel", "Oliver", "Tomas", "Onan" };
			string[] lastNames = { "Jano Hruska", "Palo Jablko", "Fero Mrkva", "Peter Slivka", "Tono Palicka", "Jakub Sekera" };
			string[] namesFirst = { "Jano", "Jozo", "Palo", "Peter", "Stefan" };
			string[] namesLast = { "Hruska", "Jablko", "Slivka", "Banan" };


			#region SQL style query
			var shortNameSQL = from c in firstNames where c.Length == 4 select c;

			if (shortNameSQL.Count() == 0)
			{
				Console.WriteLine("Empty query");
			}
			else
			{
				Console.WriteLine("SQL select short name == 4");
				ShowObject(shortNameSQL);
			}
			#endregion

			#region Function style query
			//var shortNameFS = (names.Where(item => item.Length == 3)).DefaultIfEmpty();
			var shortNameFS = firstNames.Where(item => item.Length == 8);

			if (shortNameFS.Count() == 0)
			{
				Console.WriteLine("Empty query");
			}
			else
			{
				Console.WriteLine("Functional select short name == 5");
				ShowObject(shortNameFS);
			}
			#endregion

			#region Select Subtring from char " "
			var fullNamesSQL = from c in lastNames select c.Substring(c.IndexOf(' ', 0));

			if (fullNamesSQL.Count() == 0)
			{
				Console.WriteLine("Empty query");
			}
			else
			{
				Console.WriteLine("SQL select full name from \"space\"");
				ShowObject(fullNamesSQL);
			}
			#endregion

			#region Select from 2 objects - "join" select
			var select_names =
				from first in namesFirst
				from last in namesLast
				where first.Length == last.Length
				select new { first, last };

			if (select_names.Count() == 0)
			{
				Console.WriteLine("Empty query");
			}
			else
			{
				Console.WriteLine("select from First and Last");
				//ShowObject Method cannot be used :(
				foreach (var item in select_names)
				{
					Console.WriteLine("First Name: {0} - Last Name: {1}", item.first, item.last);
				}

			}
			#endregion


			#region Select lastName from 2 and select 3 of them
			var anotherLastNames = (from c in lastNames select c).Skip(2).Take(3);

			if (anotherLastNames.Count() == 0)
			{
				Console.WriteLine("Empty query");
			}
			else
			{
				Console.WriteLine("From Last Names skip 2 and Select 3");
				ShowObject(anotherLastNames);
			}
			#endregion

			#region Grouping
			var name_groups =
				from c in firstNames orderby c.Length ascending
				group c by c.Length into g
				select new { nameLenght = g.Key, names = g };
			foreach (var item in name_groups)
			{
				Console.WriteLine("Names with leght: {0} - Count: {1}", item.nameLenght, item.names.Count());
				ShowObject(item.names);
				/*foreach (var name in item.names)
				{
					Console.WriteLine("Name: {0}", name);
				}*/
			}

			#endregion

			#region Select from first number to int Enum Array and work with it
			var firstNamesLenght = from c in namesFirst select c.Length;

			int maxFirstNameLength = firstNamesLenght.Max();
			int minFirstNameLenght = firstNamesLenght.Min();
			double avrFirstNameLenght = firstNamesLenght.Average();
			int sumFirstNameLenght = firstNamesLenght.Sum();

			Console.WriteLine("Max: {0} - Min: {1} - Sum: {2} - Avr: {3:N2}", maxFirstNameLength, minFirstNameLenght, sumFirstNameLenght, avrFirstNameLenght);
			#endregion

			//just some fun - create new array from numbers
			string[] myArray = { maxFirstNameLength.ToString(), minFirstNameLenght.ToString(), sumFirstNameLenght.ToString(), avrFirstNameLenght.ToString() };
			ShowObject(myArray);
			

			#region Press any key
			Console.WriteLine("Press any key...");
			Console.ReadKey(false);
			#endregion

		}

		#region Methods and Functions
		private static void ShowObject(IEnumerable<string> _objToDisplay)
		{
			int i = 0;
			foreach (var item in _objToDisplay)
			{
				Console.WriteLine("Object [{0}]: {1}",++i,item);
				
			}
		}
		#endregion

	}
}
