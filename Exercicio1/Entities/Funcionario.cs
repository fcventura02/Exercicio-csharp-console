using System.Globalization;

namespace Exercicio1.Entities
{
	public class Funcionario
	{
		private int id;
		private string name;
		private double valorHoraTrabalhada;
		private double horasTrabalhadas;
		private int dependentes;
		private double imposto;

		public Funcionario(int id,
		 string name,
		 double valorHoraTrabalhada,
		 double horasTrabalhadas,
		 int dependentes,
		 double imposto)
		{
            this.id = id;
			this.name = name;
			this.dependentes = dependentes;
			this.horasTrabalhadas = horasTrabalhadas;
			this.imposto = imposto / 100;
			this.horasTrabalhadas = horasTrabalhadas;
			this.valorHoraTrabalhada = valorHoraTrabalhada;
		}

        public int GetId() => id;

		public double BaseSalary()
		{
			return valorHoraTrabalhada * horasTrabalhadas;
		}

		public double DependentAddition()
		{
			return 30.0 * dependentes;
		}

		public double GrossSalary()
		{
			return BaseSalary() + DependentAddition();
		}

		public double NetSalary()
		{
			var salary = GrossSalary();
			return salary - (imposto * salary);
		}

		public override string ToString()
		{
			var salarioBase = BaseSalary().ToString("C", CultureInfo.CurrentCulture);
			var salarioBruto = GrossSalary().ToString("C", CultureInfo.CurrentCulture);
			var salarioBliquido = NetSalary().ToString("C", CultureInfo.CurrentCulture);
			return "--------------------------------------------" + System.Environment.NewLine
			 + "ID: " + id + " Nome: " + name + System.Environment.NewLine
			 + "Salário base    -> " + salarioBase + System.Environment.NewLine
			 + "Salário bruto   -> " + salarioBruto + System.Environment.NewLine
			 + "Salário líquido -> " + salarioBliquido + System.Environment.NewLine
		     + "--------------------------------------------" + System.Environment.NewLine;
		}
	}
}