using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Action> workers = new List<Action>();
            for (int i = 0; i < Environment.ProcessorCount / 2; i++)
            {
                Cracker cracker = new Cracker("hello",1,6,i);
                cracker.Start();
                workers.Add(delegate { Console.WriteLine(cracker.GetHashCode()); });
            }
            foreach (Action action in workers) action();
            Console.ReadKey();
        }
    }
}
