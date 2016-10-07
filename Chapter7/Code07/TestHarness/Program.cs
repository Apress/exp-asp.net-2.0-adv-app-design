#region Using directives

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using ESDemo;

#endregion

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uncomment the line calling the functionality you want to exercise
            //CarService c = new CarService();
            //TestJITA();
            TestPool();
            
        }

        private static void TestPool()
        {
            for (int i = 0; i < 500; i++)
            {
                System.Threading.Thread t = new System.Threading.Thread(Program.ExPool);
                t.Start();
                //System.Threading.Thread.Sleep(200);
            }
        }
        private static void ExPool()
        {
            string[] tables = 
                { "authors", "employee", "titles", "publishers", "sales" };
            Random r = new Random();
            using (Poolable p = new Poolable())
            {
                for (int i = 1; i < 10; i++)
                {
                    string s = string.Format(
                        "select * from {0}", tables[r.Next(tables.Length - 1)]);
                    DataSet ds = p.GetSomeData(s);
                }
            }
            //Dispose called automatically when 'using' goes out of scope
        }

        private static void TestJITA()
        {
            JITA j = new JITA();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(j.GetCreateStamp());
                Thread.Sleep(3000);
            }
            Console.ReadLine();
        }

    }
}
