using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppDataSerialization
{
	class AppDataSerializationMain
	{
		static void Main(string[] args)
		{
			string xmlFileInvoice = "C:\\DataFolder\\Downloads\\TestShare\\invoice.xml";

			XmlSerializer productCruncher =
				new XmlSerializer(typeof(InvoiceItemClasses));
			TextWriter tw = new StreamWriter(xmlFileInvoice);
			InvoiceItemClasses billing = new InvoiceItemClasses();


			//Create Address for billing and shipping
			ShipppingDestination shipAddress = new ShipppingDestination();
			shipAddress.PlaceName = "Bety Baker";
			shipAddress.PlaceNameOptional = "Bety Boka Bakery";
			shipAddress.City = "Alabama";
			shipAddress.State = "Texas";
			shipAddress.Zip = "56012";
			billing.ShipTo = shipAddress;
			billing.OrderDate = System.DateTime.Now.ToLongDateString();

			//Create OrderItem
			Product P1 = new Product();
			P1.ProductName = "SmartPhone";
			P1.Description = "5G Super Phone";
			P1.UnitPrice = (decimal)220.00;
			P1.Quantity = 1;
			P1.GetProductTotal();

			//Insert Product into array
			Product[] item = { P1 };
			billing.OrderedProducts = item;

			//Calculate Total cost
			decimal subTotal = 0M;
			foreach (Product prod in item)
			{

				subTotal += prod.ItemTotal;
			}
			billing.ProductTotal = subTotal;
			billing.Shipping = (decimal)12.51;
			billing.InvoiceTotal = billing.ProductTotal + billing.Shipping;

			productCruncher.Serialize(tw, billing);
			tw.Close();




		}
	}
}
