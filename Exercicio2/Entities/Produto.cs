using System.Globalization;

namespace Exercicio2.Entities
{
	public class Produto
	{
		private int _id;
		private string _name;
		private double _price;

		public Produto(int id,
		string name,
		double price)
		{
			_id = id;
			_name = name;
			_price = price;
		}

		public int getId() => _id;

		public double getPrice() => _price;

		public override string ToString()
		{
			var preco = _price.ToString("C", CultureInfo.CurrentCulture);
			return "________________________________" + System.Environment.NewLine
			+ "Id: " + _id + " - nome: " + _name + System.Environment.NewLine
			+ "Preço: " + preco + System.Environment.NewLine
			+ "________________________________" + System.Environment.NewLine;
		}
	}
}