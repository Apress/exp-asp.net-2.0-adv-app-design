using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DataReaderIE
/// </summary>
public class DataReaderIE
{
	public DataReaderIE()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public void InsertWithGenSql(string JobDescr, int MinLvl, int MaxLvl)
	{
		string sql = string.Format(
			"INSERT INTO Jobs "
			+ " (job_desc, min_lvl, max_lvl)"
			+ " ('{0}', {1}, {2})",
			JobDescr, MinLvl, MaxLvl
		);

		SqlCommand cm = 
			new SqlCommand(
			sql, 
			new SqlConnection(
			"server=.;database=pubs;uid=sa;pwd=123123")
		);

		cm.Connection.Open();
		cm.ExecuteNonQuery();
		cm.Connection.Close();
	}

	public void InsertWithParams(string JobDescr, int MinLvl, int MaxLvl)
	{
		string sql = "INSERT INTO Jobs "
			+ " (job_desc, min_lvl, max_lvl)"
			+ " ('@descr', @min, @max)";

		SqlCommand cm =
			new SqlCommand(
			sql,
			new SqlConnection(
			"server=.;database=pubs;uid=sa;pwd=123123")
		);

		cm.Parameters.Add(
				new SqlParameter(
				"@descr", 
				SqlDbType.VarChar, 50)
			).Value = JobDescr;

		cm.Parameters.Add(
				new SqlParameter(
				"@min", 
				SqlDbType.TinyInt)
			).Value = MinLvl;

		cm.Parameters.Add(
			new SqlParameter(
			"@min", SqlDbType.TinyInt)
			).Value = MaxLvl;

		cm.Connection.Open();
		cm.ExecuteNonQuery();
		cm.Connection.Close();
	}

	public double DailySalesTotal(DateTime day)
	{
		SqlCommand cm =
			new SqlCommand(
			"usp_GetDailySalesTotal",
			new SqlConnection(
			"server=.;database=pubs;uid=sa;pwd=123123")
		);

		cm.Parameters.Add(
				new SqlParameter(
				"@dayToCalc",
				SqlDbType.DateTime)
			).Value = day;

		cm.Parameters.Add(
				new SqlParameter(
				"@total",
				SqlDbType.Money)
			).Direction = ParameterDirection.Output;

		cm.Connection.Open();
		cm.ExecuteNonQuery();
		cm.Connection.Close();

		return Convert.ToDouble(cm.Parameters["@total"].Value);
	}

	public int GetBookCount(string pubid)
	{
		string sql = "select count(title_id) from titles "
			+ "where pub_id = @pubid";

		SqlCommand cm =
			new SqlCommand(
			sql,
			new SqlConnection(ConfigurationManager.ConnectionStrings
                              ["localPubs"].ToString())
		);

		cm.Parameters.Add(
			new SqlParameter(
			"@pubid", SqlDbType.Char, 4)
		).Value = pubid;

		cm.Connection.Open();
		int count = Convert.ToInt32(cm.ExecuteScalar());
		cm.Connection.Close();

		return count;
	}

}
