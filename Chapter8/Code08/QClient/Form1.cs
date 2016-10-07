using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QClient
{
    public partial class Form1 : Form
    {
        bool bDone = false;
        int count;
        string ip = System.Net.Dns.GetHostAddresses
                     (System.Net.Dns.GetHostName())[0].ToString();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            count = 0;
            bDone = false;
            btnScan.Enabled = false;
            btnCancel.Enabled = true;
            Thread t = new Thread(FindDocs);
            t.Start();
        }

        private void FindDocs()
        {
            FindDocs(new DirectoryInfo(@"c:\"));
            btnCancel.Enabled = false;
            btnScan.Enabled = true;
        }

        private void FindDocs(DirectoryInfo dir)
        {            
            QLibrary.DocDescription doc;
            string name;            
            string path;
            if (bDone) return;            
            try
            {
                foreach (FileInfo fi in dir.GetFiles("*.doc"))
                {
                    name = fi.Name;
                    path = fi.FullName.Substring(0, fi.FullName.LastIndexOf(@"\"));
                    doc = new QLibrary.DocDescription(ip, path, name);
                    QLibrary.DocDescription.SendToQueue(doc);
                    label1.Text = string.Format("{0} documents found", ++count);

                    if (bDone) break;
                }

                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    FindDocs(d);
                    if (bDone) break;
                }
            }
            catch {  }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bDone = true;
            btnCancel.Enabled = false;
            btnScan.Enabled = true;
        }
    }
}