using System;
namespace Exercicio4.Entitie
{
    public class Funcionario
    {
        private int _id;
        private string _name;
        private double _salary;

        public Funcionario(int id, string name, double salary)
        {
            _id = id;
            _name = name;
            _salary = salary;
        }

        public int GetId()
        {
            return _id;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public double GetSalary()
        {
            return _salary;
        }
        public void SetSalary(double salary)
        {
            _salary = salary;
        }

        public override string ToString()
        {
            return "-------------------------------" + Environment.NewLine
            + $"{_name} --- id: {_id}" + Environment.NewLine
            + $"Salário: {_salary}" + Environment.NewLine
            + "-------------------------------" ;
        }
    }
}