using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_16
{
    internal class TestSync
    {
        //example sync function

        internal void Run()
        {
            RunFirst();
            RunSecond();
            RunThird();
        }
        private void RunThird()
        {
            Console.WriteLine("Run Third");
            //Wait is blocking
            Task.Delay(2000).Wait();
        }

        private void RunSecond()
        {
            Console.WriteLine("Run Second");
            Task.Delay(2000).Wait();
        }

        private void RunFirst()
        {
            Console.WriteLine("Run First");
            Task.Delay(2000).Wait();
        }
    }
}
