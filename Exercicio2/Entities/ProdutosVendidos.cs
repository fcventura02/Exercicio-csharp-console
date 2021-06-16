using System;

namespace Exercicio2.Entities
{
    public class ProdutosVendidos
    {
         int _quantidade;
         Produto _produto;

         public ProdutosVendidos(int quantidade, Produto produto)
         {
             _quantidade = quantidade;
             _produto = produto;
         }

         public double ValorTotal()
         {
             return _produto.getPrice() * Convert.ToDouble(_quantidade);
         }

         public Produto getProduto()
         {
             return _produto;
         }

          public override string ToString()
        {
            return "-------------------" + System.Environment.NewLine
            + "Quantidade: " + _quantidade + System.Environment.NewLine
            + "Produto: " + _produto.ToString()
            +"-------------------" ;
        }
    }
}