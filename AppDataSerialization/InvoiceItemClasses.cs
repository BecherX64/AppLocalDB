using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppDataSerialization
{
	[Serializable]
	[XmlRoot("Invoice",IsNullable=false)]
	public class InvoiceItemClasses
	{
		public ShipppingDestination ShipTo;
		public string OrderDate;

		[XmlArrayAttribute("Products")]
		public Product[] OrderedProducts;

		public decimal ProductTotal;
		public decimal Shipping;
		public decimal InvoiceTotal;

		public override string ToString()
		{
			InvoiceTotal = ProductTotal + Shipping;
			return string.Format("Invoice on {0} had total cost {1:C}", this.OrderDate, this.InvoiceTotal);
		}




	}
	[Serializable]
	public class Product
	{
		public string ProductName;
		public string Description;
		public decimal UnitPrice;
		public int Quantity;
		public decimal ItemTotal;

		public void GetProductTotal()
		{
			ItemTotal = UnitPrice * Quantity;
		}
	}

	[Serializable]
	public class ShipppingDestination
	{
		[XmlAttribute]
		public string PlaceName;
		public string PlaceNameOptional;
		[XmlElement(IsNullable = false)]
		public string City;
		public string State;
		public string Zip;
	}




}
