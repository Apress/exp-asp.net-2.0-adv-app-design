#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Server
{   
    public interface IQueuable
    {
        void executeSQL(string sql);
    }

    [InterfaceQueuing(Interface = "IQueuable")]
    public class QCDemo : ServicedComponent, IQueuable
    {
        public QCDemo() {}

        public void executeSQL(string sql)
        {
            SqlCommand cm = new SqlCommand(sql, new SqlConnection(ConnStr));
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }

        private readonly string ConnStr = "server=.;database=pubs;uid=sa;pwd=123123";
    }
}
