using System;
using System.Threading;
using System.Messaging;
using System.Collections.Generic;
using System.Text;

namespace ConsoleHost
{
    class Program
    {
        private MessageQueue queue;

        bool bDone = false;

        static void Main(string[] args)
        {
            Program p = new Program();
            
            
        }
        private Program()
        {
            queue = new MessageQueue(QLibrary.DocDescr.QueueName);
            Thread t = new Thread(MonitorQueue);
            t.Start();
            Console.Write("Press enter to stop");
            Console.ReadLine();
            bDone = true;
        }
        private void MonitorQueue()
        {
            Message msg;
            while (!bDone)
            {
                try
                {
                    msg = queue.Receive(new TimeSpan(0, 0, 1));
                    Console.WriteLine("Message received");
                    msg.Formatter = new BinaryMessageFormatter();
                    QLibrary.DocDescr d = (QLibrary.DocDescr)msg.Body;
                    Console.WriteLine(string.Format("Sending {0} to database",d.DocName));
                    QLibrary.DocDescr.SendToDatabase(d);

                }
                catch { Thread.Sleep(1000); }
            }
        }
    }
}
