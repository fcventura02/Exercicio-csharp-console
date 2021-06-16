using System;
using System.Collections.Generic;
using System.Globalization;


namespace Exercicio2.Entities
{
	public class Venda
	{
		private int _id;
		private List<ProdutosVendidos> _produtos;
		private double _valorTotal;
		private DateTime _date;
		private bool _desconto;

		public Venda(int Id,
		List<ProdutosVendidos> Produtos, bool Desconto)
		{
			_date = DateTime.Now;
			_id = Id;
			_produtos = Produtos;
			_valorTotal = calcValorToal();
			_desconto = Desconto;
		}

		public void setDesconto(bool desconto)
		{
			_desconto = desconto;
		}

		public double calcValorToal()
		{
			double total = 0;
			foreach (ProdutosVendidos item in _produtos)
			{
				total = total + item.ValorTotal();
			}
			return total;
		}

		public double valorDesconto()
		{
			return _desconto ? (_valorTotal - (_valorTotal * 0.15)) : _valorTotal;
		}

		public override string ToString()
		{
			var valorToal = valorDesconto();
			var comissao = (valorToal * 0.05);
            var produtos = String.Join(System.Environment.NewLine, _produtos);
			return "_______________________________" + System.Environment.NewLine
				    + "Id da venda: " + _id
				    + " - " + _date.ToString("dd/MM/yyyy HH:mm") + System.Environment.NewLine
				    + "Sub-total: " + _valorTotal.ToString("C", CultureInfo.CurrentCulture) + System.Environment.NewLine
				    + "Valor Total: " + valorToal.ToString("C", CultureInfo.CurrentCulture) + System.Environment.NewLine
				    + "Valor da comissão: " + comissao.ToString("C", CultureInfo.CurrentCulture) + System.Environment.NewLine
				    + "Produtos: " + System.Environment.NewLine
				    + produtos
		    + "_______________________________" + System.Environment.NewLine;
		}
	}
}