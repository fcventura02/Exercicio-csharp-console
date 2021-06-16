using System;
using System.Collections;
using Exercicio1.Entities;

namespace Exercicio1
{
	class Program
	{
		static ArrayList funcionarios = new ArrayList();
		static int ID = 0;
		static void Main(string[] args)
		{

			Menu();
		}
		public static void Menu()
		{
			int opt = 10;
			while (opt != 0)
			{
				Console.WriteLine("         MENU");
				Console.WriteLine("1. Inserir novo funcionário");
				Console.WriteLine("2. Listar funcionários");
				Console.WriteLine("3. Apagar funcionário");
				Console.WriteLine("0. Sair");
				opt = Convert.ToInt32(Console.ReadLine());
				Console.Clear();
				switch (opt)
				{
					case (0):
						Console.WriteLine("Saindo!!!");
						break;
					case (1):
						Console.WriteLine("Inserir.");
						AdicionaFuncionario();
						break;
					case (2):
						Console.WriteLine("Listar.");
						if (funcionarios.Count == 0)
						{
							Console.WriteLine("Você não possui funcionários.");
							Console.WriteLine("Por favor insira novos funcionários.");
							break;
						}
						ListFuncionarios();
						Console.WriteLine("Precione ENTER para continuar....");
						Console.ReadLine();
						break;
					case (3):
						Console.WriteLine("Deletar.");
						if (funcionarios.Count == 0)
						{
							Console.WriteLine("Você não possui funcionários.");
							Console.WriteLine("Por favor insira novos funcionários.");
							break;
						}
						Console.WriteLine("Selecione o ID do funcionário para ser excluído.");
						int id = Convert.ToInt32(Console.ReadLine());
						foreach (Funcionario funcionario in funcionarios)
						{
							if (funcionario.GetId() == id)
							{
								RemoveFuncionario(funcionario);
								Console.WriteLine("Funcionário removido com sucesso!");
								break;
							}
						}
						break;

					default:
						Console.WriteLine("Opção nao encontrada.");
						break;
				}
			}
		}

		public static void ListFuncionarios()
		{
			foreach (Funcionario funcionario in funcionarios)
				Console.WriteLine(funcionario.ToString());
		}

		public static void RemoveFuncionario(object funcionario)
		{
			funcionarios.Remove(funcionario);
		}

		public static void AdicionaFuncionario()
		{
			var isInserted = false;
			while (!isInserted)
			{
				try
				{
					Console.WriteLine("Nome: ");
					var name = Console.ReadLine();
					Console.WriteLine("Valor da hora trabalhada: ");
					var valorHoraTrabalhada = Convert.ToDouble(Console.ReadLine());
					Console.WriteLine("Horas Trabalhadas: ");
					var horasTrabalhadas = Convert.ToDouble(Console.ReadLine());
					Console.WriteLine("Quantidade de dependentes: ");
					var dependentes = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine("Imposto: ");
					var imposto = Convert.ToInt32(Console.ReadLine());
					if (String.IsNullOrEmpty(name))
					{
						Console.WriteLine("Não foi possivel inserir um dos dados.");
						Console.WriteLine("Por favor entre com valores válidos");
					}
					else
					{
						funcionarios.Add(new Funcionario(ID, name,
									    valorHoraTrabalhada,
									horasTrabalhadas,
									dependentes,
									imposto));
						ID++;
                  isInserted = true;
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("Não foi possivel inserir um dos dados.");
					Console.WriteLine("Por favor entre com valores válidos");
				}
			}

		}

	}
}
