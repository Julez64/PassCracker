using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PassCracker
{
    public class Cracker
    {
        private Random random = new Random();
        private int count = 0;
        private string password, crack;
        private int debut, fin, num, i, length, number;
        private char rand;
        private bool started;
        private Thread worker;

        public Cracker(string password,int debut, int fin, int number)
        {
            this.password = password;
            this.debut = debut;
            this.fin = fin;
            this.number = number;
        }

        public void Start()
        {
            if (!started){
                worker = new Thread(cracker);
                worker.Start();
                
            }
        }

        public void Stop()
        {
            worker.Abort();
        }

        private void cracker()
        {
            started = true;
            do
            {
                crack = "";
                length = 0;
                i = 0;
                length = random.Next(debut, fin);
                while (i != length)
                {
                    num = random.Next(0, 26);
                    rand = (char)('a' + num);
                    crack = crack.Insert(0, rand.ToString());
                    i++;
                }
                count++;
            } while (crack != password);
            started = false;
            Console.WriteLine("{0} Done",number);
            worker.Abort();
        }

        public bool Started
        {
            get;
        }
    }
}
