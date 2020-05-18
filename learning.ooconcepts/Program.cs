using System;

namespace learning.ooconcepts
{
    #region Replace Conditional Statements (IF/ELSE or SWITCH) With Polymorphism

    public interface ITijolo
    { 
        int CalcularQuantidade(int larguraDaParede);
     }

  public class Maciço : ITijolo {
        public int CalcularQuantidade(int larguraDaParede){
           return larguraDaParede * 5;
        }
    }

  public class Concreto : ITijolo {
        public int CalcularQuantidade(int larguraDaParede){
          return larguraDaParede * 10;
        }
    }

  public class Vidro : ITijolo {
      public int CalcularQuantidade(int larguraDaParede){
      	return larguraDaParede * 15;
      }
    }

    public class Pedreiro {

        public int LarguraDaParede { get; set; }
        public int QuantidadeDeTijolos {get;set;}
        public void CalcularQuantidade(ITijolo tj) {
           QuantidadeDeTijolos = tj.CalcularQuantidade(LarguraDaParede);
       }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calcular a quantidade tijolos ao contruir uma parede.");

            var pedreiro = new Pedreiro();

            pedreiro.LarguraDaParede = 5;
            pedreiro.CalcularQuantidade(new Vidro());

            Console.WriteLine(pedreiro.QuantidadeDeTijolos);
        }
    }
}
