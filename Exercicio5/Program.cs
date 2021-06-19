using System;

namespace Exercicio5
{
	class Program
	{
		static void Main(string[] args)
		{
			var sexo = "";
			var altura = 0.0;
			var peso = 0.0;
			var finishing = false;
			while (!finishing)
			{

				try
				{
					Console.WriteLine("Vamos medir sua massa ideal!");
					Console.WriteLine("Qual seu sexo?");
					Console.WriteLine("M - Masculino");
					Console.WriteLine("F - Feminino");
					sexo = Console.ReadLine();
					Console.Write("Informe seu peso: ");
					peso = Convert.ToDouble(Console.ReadLine());
					Console.Write("Informe sua altura em metros: ");
					altura = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
					var resultado = peso / Math.Pow(altura, 2);
					Console.WriteLine(resultado);

					var result = resultado < 16 ?
					    "Baixo peso muito grave"
					    : resultado < 17 ?
					    "Baixo peso grave"
					    : resultado < 19 ?
					    "Baixo peso"
					    : resultado < 25 ?
					"Peso normal"
					: resultado < 30 ?
					"Sobrepeso"
					: resultado < 35 ?
					"Obesidade grau I"
					: "Obesidade mórbida";
					Console.WriteLine("------------------------------");
					Console.WriteLine($"Você está com: {result}");
					Console.WriteLine("------------------------------");

					Console.WriteLine("Deseja Continuar?");
					Console.WriteLine("Precione enter para sair");
					Console.WriteLine("Ou digite 'S' para refazer o teste.");
					var optFinish = Console.ReadLine();
					if (String.IsNullOrEmpty(optFinish))
					{
						finishing = true;
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("Você inseriu um valor invalido");
				}
			}



		}
	}
}
