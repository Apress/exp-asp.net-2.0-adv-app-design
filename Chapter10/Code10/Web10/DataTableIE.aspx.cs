using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DataTableIE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = GetAuthorData();
        SaveDataTableToDisk(dt);
        dt = ReadDataTableFromDisk(dt.TableName);
        GridView gv = new GridView();
        gv.DataSource = dt;
        gv.DataBind();
        this.form1.Controls.Add(gv);

        gv = new GridView();
        gv.DataSource = GetTitleReader();
        gv.DataBind();
        this.form1.Controls.Add(gv);
    }

    public DataTable GetAuthorData()
    {
        string conn = ConfigurationManager.ConnectionStrings["localPubs"].ToString();
        SqlConnection cn = new SqlConnection(conn);
        SqlCommand cm = new SqlCommand("select * from authors", cn);
        DataTable dt = new DataTable();

        cn.Open();
        dt.Load(cm.ExecuteReader());
        cn.Close();
        dt.TableName = "Authors";
        return dt;
    }

    public IDataReader GetTitleReader()
    {
        bool caching = Convert.ToBoolean(
            ConfigurationManager.AppSettings["UseCaching"]);
        DataTable dt = null;
        IDataReader dr;

        if (caching) dt = (DataTable)Cache["TitleData"];

        if (dt == null)
        {
            string conn = 
                ConfigurationManager.ConnectionStrings["localPubs"].ToString();
            SqlConnection cn = new SqlConnection(conn);
            SqlCommand cm = new SqlCommand("select * from titles", cn);
            dt = new DataTable();

            cn.Open();
            if (caching)
            {
                dt.Load(cm.ExecuteReader());
                Cache.Insert("TitleData", dt);
                cn.Close();
                dr = dt.CreateDataReader();
            }
            else            
                dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
            
        }
        else
            dr = dt.CreateDataReader();
        
        return dr;
    }

    public void SaveDataTableToDisk(DataTable dt)
    {
        string schemaFile = string.Format("{0}.xsd",dt.TableName);
        string xmlFile = string.Format("{0}.xml",dt.TableName);

        schemaFile = Server.MapPath(schemaFile);
        xmlFile = Server.MapPath(xmlFile);

        dt.WriteXmlSchema(schemaFile);
        dt.WriteXml(xmlFile);
    }

    public DataTable ReadDataTableFromDisk(string TableName)
    {
        DataTable dt = new DataTable(TableName);
        string schemaFile = string.Format("{0}.xsd", TableName);
        string xmlFile = string.Format("{0}.xml", TableName);

        schemaFile = Server.MapPath(schemaFile);
        xmlFile = Server.MapPath(xmlFile);

        dt.ReadXmlSchema(schemaFile);
        dt.ReadXml(xmlFile);

        return dt;
    }
}
//'dt.ReadXml
//'dt.WriteXml
//dt.WriteXmlSchema

//dt.CreateDataReader

