using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Messaging;
using System.Text;

namespace QLibrary
{
    [Serializable()]
    public class DocDescription
    {
        public const string PrivateQ = @"\private$\";
        public const string LocalQName = "queuetest";
        public static readonly string QueueName = string.Format("{0}{1}{2}",
                                             System.Net.Dns.GetHostName(),
                                            PrivateQ,
                                            LocalQName);

        public DocDescription() { }

        public DocDescription(string docIP, string docPath, string docName)
        {
            this.DocIP = docIP;
            this.DocPath = docPath;
            this.DocName = docName;
        }

        private string docName;
        public string DocName
        {
            get { return docName; }
            set { docName = value; }
        }
        private string docIP;
        public string DocIP
        {
            get { return docIP; }
            set { docIP = value; }
        }
        private string docPath;
        public string DocPath
        {
            get { return docPath; }
            set { docPath = value; }
        }

        public static void SendToDatabase(DocDescription d)
        {
            SqlConnection cn = new SqlConnection
                                ("server=.;database=pubs;uid=sa;pwd=123123");
            SqlCommand cm = new SqlCommand("usp_InsertDoc", cn);

            cm.CommandType = System.Data.CommandType.StoredProcedure;

            cm.Parameters.Add(new SqlParameter
                              ("@DocIP", SqlDbType.VarChar,20)).Value = d.DocIP;
            cm.Parameters.Add(new SqlParameter 
                              ("@DocPath", SqlDbType.VarChar,250)).Value = d.DocPath;
            cm.Parameters.Add(new SqlParameter 
                              ("@DocName", SqlDbType.VarChar,250)).Value = d.DocName;

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public static void SendToQueue(DocDescription d)
        {
            MessageQueue q = new MessageQueue(QueueName);
            Message msg = new Message(d, new BinaryMessageFormatter());
            q.Send(msg);            
        }
    }
}
