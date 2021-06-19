using System;
using System.Collections.Generic;
using Exercicio2.Entities;

namespace Exercicio2
{
	class Program
	{
		static int Id_Produto = 0;
		static int Id_Venda = 0;
		static List<Produto> produtos = new List<Produto>();
		static List<Venda> vendas = new List<Venda>();
		static void Main(string[] args)
		{
			Menu();
		}
		static void Menu()
		{
			var isRun = true;
			var isInserted = false;
			string opt;
			while (isRun)
			{
				Console.WriteLine("------------- Menu ---------------");
				Console.WriteLine("1 -> Adicionar produto.");
				Console.WriteLine("2 -> Adicionar Venda. ");
				Console.WriteLine("3 -> Listar produtos. ");
				Console.WriteLine("4 -> Listar vendas. ");
				Console.WriteLine("5 -> Sair. ");
				opt = Console.ReadLine();
				Console.Clear();
				switch (opt)
				{
					case ("1"):
						Console.WriteLine("Adicionar produto.");
						while (!isInserted)
						{
							AddProduct();

							Console.WriteLine("Inserir novo produto? ");
							Console.WriteLine("Sim -> S ");
							Console.WriteLine("Não -> Precione ENTER para continuar. ");
							opt = Console.ReadLine();
							if (String.IsNullOrEmpty(opt))
							{
								isInserted = true;
							}
						}
						isInserted = false;
						break;
					case ("2"):
						Console.WriteLine("Adicionar Venda.");
						while (!isInserted)
						{
							if (produtos.Count == 0)
							{
								Console.WriteLine("Você não possui produtos para vender");
								Console.WriteLine("");
								Console.WriteLine("Precione ENTER para continuar....");
								Console.ReadLine();
								break;
							}
							newSale();

							Console.WriteLine("Inserir nova venda? ");
							Console.WriteLine("Sim -> S ");
							Console.WriteLine("Não -> Precione ENTER para continuar. ");
							opt = Console.ReadLine();
							if (String.IsNullOrEmpty(opt))
							{
								isInserted = true;
							}
						}
						isInserted = false;
						break;
					case ("3"):
						Console.WriteLine("Listar produtos.");
						ListarProduto(produtos);
						Console.WriteLine("Precione ENTER para continuar....");
						Console.ReadLine();
						break;
					case ("4"):
						Console.WriteLine("Listar produtos.");
						ListarVendas(vendas);
						Console.WriteLine("Precione ENTER para continuar....");
						Console.ReadLine();
						break;
					case ("5"):
						isRun = false;
						break;

					default:
						Console.WriteLine("Opção não encontrada.");
						break;
				}
				Console.Clear();
			}
		}

		static void AddProduct()
		{
			try
			{
				Console.Write("Nome: ");
				var name = Convert.ToString(Console.ReadLine());
				Console.Write("Preço: ");
				var price = Convert.ToDouble(Console.ReadLine());
				produtos.Add(new Produto(Id_Produto, name, price));
            Id_Produto++;
			}
			catch (FormatException)
			{
				Console.Write("Você inseriu um valor inválido.");
			}
		}
		static void newSale()
		{
			if (produtos.Count == 0)
			{
				Console.WriteLine("Você não possui produtos para vender");
			}
			else
			{
				var produtosVendido = new List<ProdutosVendidos>();
				Produto produto = null;
				var desconto = false;
				var isInserted = false;
				while (!isInserted)
				{
					try
					{
						Console.Write("");
						Console.Write("Id do produto: ");
						var id = Convert.ToInt32(Console.ReadLine());
						Console.Write("Quantidade: ");
						var quantidade = Convert.ToInt32(Console.ReadLine());
						foreach (Produto item in produtos)
						{
							if (item.getId() == id)
								produto = item;
						}
						if (produto != null)
						{
							produtosVendido.Add(new ProdutosVendidos(quantidade, produto));
							Console.WriteLine("Adicionar novo produto?");
							Console.WriteLine("Sim - S");
							Console.WriteLine("Não - N");
							var continuar = Console.ReadLine();
							if (continuar.ToUpper().Contains("N")) isInserted = true;
						}
						else Console.WriteLine("Produto não encontrado");
					}
					catch (FormatException)
					{
						Console.Write("Você inseriu um valor invalido.");
					}
				}
				if (produtosVendido.Count > 0)
				{
					Console.WriteLine("Adicionar desconto?");
					Console.WriteLine("Sim - S");
					Console.WriteLine("Não - N");
					var adicionarDesconto = Console.ReadLine();
					if (adicionarDesconto.ToUpper().Contains("S")) desconto = true;
					vendas.Add(new Venda(Id_Venda, produtosVendido, desconto));
               Id_Venda++;
				}
			}
		}
		static void ListarVendas(List<Venda> list)
		{
			if (list.Count == 0)
				Console.WriteLine("Não foi possivel realizar essa operação. Por favor entre com novos valores.");
			else foreach (Venda obj in list)
					Console.WriteLine(obj.ToString());
		}
		static void ListarProduto(List<Produto> list)
		{
			if (list.Count == 0)
				Console.WriteLine("Não foi possivel realizar essa operação. Por favor entre com novos valores.");
			else foreach (Produto obj in list)
					Console.WriteLine(obj.ToString());
		}

	}
}
