using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;

using System.Messaging;

namespace QListener
{
    public partial class ListenerSvc : ServiceBase
    {
        private MessageQueue queue;        
        bool bDone = false;       

        protected override void OnStart(string[] args)
        {
            if (!MessageQueue.Exists(QLibrary.DocDescription.QueueName))
            {
                MessageQueue.Create(QLibrary.DocDescription.QueueName);
            }
            queue = new MessageQueue(QLibrary.DocDescription.QueueName);
            Thread t = new Thread(MonitorQueue);
            t.Start();            
        }

        protected override void OnStop()
        {
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
                    msg.Formatter = new BinaryMessageFormatter();
                    QLibrary.DocDescription d = (QLibrary.DocDescription)msg.Body;                    
                    QLibrary.DocDescription.SendToDatabase(d);
                    
                }
                catch { Thread.Sleep(1000); }
            }
        }

        public ListenerSvc()
        {
            InitializeComponent();
        }
    }
}
