using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for PublisherBO
/// </summary>
public class PublisherBO
{
	public PublisherBO()
	{		
	}

	public PublisherBO(string pubId)
	{
		SqlCommand cm =
			new SqlCommand(
            "usp_GetPubDetails",
			new SqlConnection(ConfigurationManager.ConnectionStrings
			                  ["localPubs"].ToString())
		);

		cm.CommandType = CommandType.StoredProcedure;

		cm.Parameters.Add(
			new SqlParameter(
			"@pub_id",
			SqlDbType.Char,4)
		).Value = pubId;

		cm.Parameters.Add(
			new SqlParameter(
			"@pub_name",
			SqlDbType.VarChar,10)
		).Direction = ParameterDirection.Output;

		cm.Parameters.Add(
			new SqlParameter(
			"@city",
			SqlDbType.VarChar,10)
		).Direction = ParameterDirection.Output;

		cm.Parameters.Add(
			new SqlParameter(
			"@state",
			SqlDbType.VarChar,10)
		).Direction = ParameterDirection.Output;

		cm.Parameters.Add(
			new SqlParameter(
			"@country",
			SqlDbType.VarChar,10)
		).Direction = ParameterDirection.Output;

		cm.Connection.Open();
		cm.ExecuteNonQuery();
		cm.Connection.Close();

		this.pubId = cm.Parameters["@pub_id"].Value.ToString();
		this.pubName = cm.Parameters["@pub_name"].Value.ToString();
		this.city  = cm.Parameters["@city"].Value.ToString();
		this.state = cm.Parameters["@state"].Value.ToString();
		this.country = cm.Parameters["@country"].Value.ToString();
	}

	string m_pubId;
	public string pubId 
	{	get { return m_pubId; }
		set { m_pubId = value; }
	}
	string m_pubName;
	public string pubName 
	{	get { return m_pubName; }
		set { m_pubName = value; }
	}
	string m_city ;
	public string city  
	{	get { return m_city ; }
		set { m_city  = value; }
	}
	string m_state;
	public string state 
	{	get { return m_state; }
		set { m_state = value; }
	}
	string m_country;
	public string country
	{	get { return m_country; }
		set { m_country = value; }
	}
}
