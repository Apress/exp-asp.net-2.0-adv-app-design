#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

using System.EnterpriseServices;
using System.Runtime.InteropServices;

using Server;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "insert into jobs ( job_desc, min_lvl, max_lvl) "
                       + "values ('Some job',10,250)";
            QCDemo o = new QCDemo();
            ServicedComponent.DisposeObject(o);
            Console.Write("Component registered.  Press enter to invoke");
            Console.ReadLine();

            IQueuable qable;
            qable = (IQueuable)Marshal.BindToMoniker("queue:/new:Server.QCDemo");

            for(int i = 1; i < 100; i++)
                qable.executeSQL(sql);

            Marshal.ReleaseComObject(qable);

        }
    }
}
