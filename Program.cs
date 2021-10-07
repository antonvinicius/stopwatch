using System.Threading;
using System;

namespace Stopwatch
{
  class Program
  {
    static void Main(string[] args)
    {
      var option = Menu();
      Start(option);
    }

    static int Menu()
    {
      Console.WriteLine("CRONÔMETRO C#");
      Console.WriteLine("\nEm quanto tempo deseja parar o cronômetro? utilize S para segundos, M para minutos ou H para horas");
      Console.WriteLine("Exemplo: 2S = 2 segundos, 5M = 5 minutos, 3H = 3 horas");
      Console.Write("Sua opção: ");
      var opcao = Console.ReadLine();

      int values = int.Parse(opcao.Substring(0, opcao.Length - 1));
      char method = char.Parse(opcao.Substring(opcao.Length - 1, 1));
      if (method != 'S' && method != 'M' && method != 'H' && values < 0)
      {
        Console.WriteLine("Formato inválido, tente novamente");
        Thread.Sleep(500);
        Console.Clear();
        Menu();
      }

      if (method == 'S')
      {
        return values;
      }
      else if (method == 'M')
      {
        return values * 60;
      }
      else if (method == 'H')
        return values * 60 * 60;
      else
      {
        return -1;
      }
    }

    static void Start(int shouldStopIn)
    {
      int seconds = 0, minutes = 0, hours = 0;
      while (seconds != shouldStopIn)
      {
        Thread.Sleep(1000);
        seconds++;
        if (seconds == 60)
        {
          minutes++;
          seconds = 0;
        }
        if (minutes == 60)
        {
          hours++;
          minutes = 0;
        }

        Console.Clear();
        Console.WriteLine($"{hours.ToString().PadLeft(2, '0')}:{minutes.ToString().PadLeft(2, '0')}:{seconds.ToString().PadLeft(2, '0')}");
      }
    }
  }
}
