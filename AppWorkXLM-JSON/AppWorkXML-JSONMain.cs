using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppWorkXLM_JSON
{
	class Program
	{
		static void Main(string[] args)
		{
			string xmlFile = "C:\\DataFolder\\Downloads\\TestShare\\CDCatalog.xml";
			string xmlFileProcesses = "C:\\DataFolder\\Downloads\\TestShare\\process.xml";

			XElement myxElement = XElement.Load(xmlFile);
			IEnumerable<XElement> catalogue = myxElement.Elements();

			//read whole XML file
			foreach (var process in catalogue)
			{
				Console.WriteLine("{0}",process);
			}

			//Press any key...
			Console.WriteLine("Press any key");
			Console.ReadKey(false);
			Console.Clear();

			/*
			//Display Only TITLE values
			foreach (var catItem in catalogue)
			{
				Console.WriteLine(catItem.Element("TITLE").Value);
			}
			*/
			
			//Display only TILTE and YEAR where YEAR > 1990
			var name = from c in myxElement.Elements("CD")
						   //where c.Element("TITLE").Value.Contains("a")
					   where Convert.ToInt32(c.Element("YEAR").Value.ToString()) > 1990
					   select c;
			foreach (XElement item in name)
			{
				//Console.WriteLine(item);
				Console.WriteLine("Title: {0} - Year: {1}",item.Element("TITLE").Value, item.Element("YEAR").Value);
				
			}

			//Press any key...
			Console.WriteLine("Press any key");
			Console.ReadKey(false);

			XElement myOtherxElement = XElement.Load(xmlFileProcesses);
			var processes1 = from c in myOtherxElement.Elements()
						  select c;
			Console.WriteLine("Number of processes1: {0}",processes1.Count());

			
			foreach (var process in processes1)
			{
				int i = 0;
				foreach (var element in process.Elements())
				{
					try
					{
						Console.WriteLine(element.Name);
						//Console.WriteLine(element.Element("S").Value.ToString());
						Console.WriteLine("Itteration: #{0} - Press any key", ++i);
						Console.ReadKey(false);
					}
					catch (Exception ex)
					{

						Console.WriteLine(ex);
					}
				}


			}

			//Press any key...
			Console.WriteLine("Press any key");
			Console.ReadKey(false);

		}
		#region Custom Methods and Functions

		#endregion

	}
}
