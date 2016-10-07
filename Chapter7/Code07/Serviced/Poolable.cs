#region Using directives

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

#endregion

using System.EnterpriseServices;
using System.Data.SqlClient;

namespace ESDemo
{
    [ObjectPooling(5, 500)]        
    [JustInTimeActivation(true)]
    [EventTrackingEnabled(true)]
    public class Poolable : ServicedComponent
    {
        public DataSet GetSomeData(string sql)
        {
            SqlConnection cn = new SqlConnection(ConnStr);
            SqlCommand cm = new SqlCommand(sql, cn);
            DataSet ds = new DataSet();

            cn.Open();            
            new SqlDataAdapter(cm).Fill(ds);
            cn.Close();
            ContextUtil.DeactivateOnReturn = true;
            return ds;
            
        }
        protected override bool CanBePooled()
        {
            return true;
        }

        private readonly string ConnStr = "server=.;database=pubs;uid=sa;pwd=";
    }
    
}
