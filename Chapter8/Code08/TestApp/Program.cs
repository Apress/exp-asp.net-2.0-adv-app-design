using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxies.JITAService j = new TestApp.Proxies.JITAService();
            for (int i = 0; i < 10; i++)
            {
                DateTime t = j.GetCreateStamp();
                Console.WriteLine(t);
            }

        }
    }
}
