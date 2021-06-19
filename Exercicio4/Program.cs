using System;
using System.Collections.Generic;
using Exercicio4.Entitie;

namespace Exercicio4
{
	class Program
	{
		static List<Funcionario> funcionarios = new List<Funcionario>();
		static int ID = 0;
		static void Main(string[] args)
		{
			Menu();
		}
		static void Menu()
		{
			var opt = "";
			var isRun = true;
			while (isRun)
			{
				Console.WriteLine("-----Menu----");
				Console.WriteLine("(1) Adicionar funcionário");
				Console.WriteLine("(2) Alterar Salário");
				Console.WriteLine("(3) Listar funcionário");
				Console.WriteLine("(0) sair");
				opt = Console.ReadLine();

				switch (opt)
				{
					case ("1"):
						Adicionar();
						break;
					case ("2"):
						Atualizar();
						break;
					case ("3"):
						Listar();
						break;
					case ("0"):
						isRun = false;
						break;
					default:
						Console.WriteLine("Opção não encontrada.");
						break;
				}
				Console.Clear();
			}

		}

		static void Adicionar()
		{
			var name = "";
			double salary = 0.0;
			var opt = "";
			var isFinishingAddedFuncionario = false;
			while (!isFinishingAddedFuncionario)
			{

				Console.WriteLine("-----Novo Funcionário----");
				Console.WriteLine("Nome: ");
				name = Console.ReadLine();

				Console.WriteLine("Salário: ");
				salary = Convert.ToDouble(Console.ReadLine());
				funcionarios.Add(new Funcionario(ID, name, salary));
				Console.WriteLine("Funcionário adicionado com sucesso.");
				Console.WriteLine();
				Console.WriteLine("Deseja adicionar outro funcionário? ");
				Console.WriteLine("Digite --- SIM --- para adicionar novo funcionário.");
				Console.WriteLine("Precione Enter para continuar.");
				opt = Console.ReadLine();
				if (String.IsNullOrEmpty(opt))
					isFinishingAddedFuncionario = true;
				ID++;
			}

		}

		static void Listar()
		{
			if (funcionarios.Count != 0)
				foreach (Funcionario item in funcionarios)
					Console.WriteLine(item.ToString());
			else Console.WriteLine("Você nao possui funcionários.");

			Console.WriteLine("Precione Enter para continuar.");
			Console.ReadLine();
		}

		static void Atualizar()
		{
			if (funcionarios.Count != 0)
				foreach (Funcionario item in funcionarios)
				{
					var salary = item.GetSalary();
					item.SetSalary(salary < 900.00 ?
					salary + (salary * 0.3)
					: salary);
				}
			else Console.WriteLine("Você nao possui funcionários.");
			Console.WriteLine("Salários atualizados.");
			Console.WriteLine("Precione Enter para continuar.");
			Console.ReadLine();
		}
	}
}
