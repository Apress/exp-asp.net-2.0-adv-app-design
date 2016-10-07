using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

	
	[Serializable()]
	public class BookDetails
	{
		public BookDetails()
		{}

		public BookDetails(int BookID)
		{
			SqlCommand cm = new SqlCommand("usp_GetBook", new SqlConnection(WebStatic.ConnectionString));
			cm.CommandType = CommandType.StoredProcedure;
			cm.Parameters.Add("@BookId",SqlDbType.Int).Value = BookID;
			cm.Connection.Open();
			SqlDataReader dr = cm.ExecuteReader();
			if (dr.Read())
			{
				if (dr["Binding"] != DBNull.Value)
					this.Binding = dr["Binding"].ToString();
				this.BookID = Convert.ToInt32(dr["BookID"]);
				this.BookImage = new Bitmap(new MemoryStream((byte[])dr["CoverImage"]));
				this.ISBN = dr["ISBN"].ToString();
				if (dr["ListPrice"] != DBNull.Value)
					this.ListPrice = Convert.ToDouble(dr["ListPrice"]);
				this.LocationID = Convert.ToInt32(dr["LocationID"]);
				this.LowestPrice = Convert.ToDouble(dr["LowestPrice"]);
				this.PageCount = Convert.ToInt32(dr["PageCount"]);
				this.PublicationDate = Convert.ToDateTime(dr["PublicationDate"]);
				this.Publisher = dr["Publisher"].ToString();
				if (dr["Review"] != DBNull.Value)
					this.Review = dr["Review"].ToString();
				this.ScanDate = Convert.ToDateTime(dr["ScanDate"]);
				this.Title = dr["Title"].ToString();
				this.Weight = Convert.ToDouble(dr["Weight"]);
				dr.Close();
				SqlCommand cmDetails = new SqlCommand("usp_GetBookSubjects", cm.Connection);
				cmDetails.Parameters.Add("@BookId",SqlDbType.Int).Value = this.BookID;
				cmDetails.CommandType = CommandType.StoredProcedure;
				SqlDataReader drDetail = cmDetails.ExecuteReader();
				while (drDetail.Read())
					this.Subjects.Add(drDetail[0].ToString());
				drDetail.Close();
				cmDetails.CommandText = "usp_GetBookAuthors";
				drDetail = cmDetails.ExecuteReader();
				while (drDetail.Read())
					this.Authors.Add(drDetail[0].ToString());
				drDetail.Close();
			}
			else
			{ //throw new Exception(string.Format("Book Not Found.  Book ID: {0}",BookID)); 
            }
		}

		int m_BookID ;
		public int BookID 
		{
			get { return m_BookID ; }
			set { m_BookID = value; }
		}
		string m_ISBN ;
		public string ISBN 
		{
			get { return m_ISBN ; }
			set { m_ISBN = value; }
		}
		int m_LocationID ;
		public int LocationID 
		{
			get { return m_LocationID ; }
			set { m_LocationID = value; }
		}
		string m_Title ;
		public string Title 
		{
			get { return m_Title ; }
			set { m_Title = value; }
		}
		string m_Publisher;
		public string Publisher 
		{
			get { return m_Publisher ; }
			set { m_Publisher = value; }
		}
		int m_PageCount ;
		public int PageCount 
		{
			get { return m_PageCount ; }
			set { m_PageCount = value; }
		}
		DateTime m_PublicationDate ;
		public DateTime PublicationDate 
		{
			get { return m_PublicationDate ; }
			set { m_PublicationDate = value; }
		}
		double m_Weight ;
		public double Weight 
		{
			get { return m_Weight ; }
			set { m_Weight = value; }
		}
		double m_LowestPrice ;
		public double LowestPrice 
		{
			get { return m_LowestPrice ; }
			set { m_LowestPrice = value; }
		}
		double m_ListPrice ;
		public double ListPrice 
		{
			get { return m_ListPrice ; }
			set { m_ListPrice = value; }
		}
		DateTime m_ScanDate ;
		public DateTime ScanDate 
		{
			get { return m_ScanDate ; }
			set { m_ScanDate = value; }
		}
		string m_Review ;
		public string Review 
		{
			get { return m_Review ; }
			set { m_Review = value; }
		}
		string m_Binding ;
		public string Binding 
		{
			get { return m_Binding ; }
			set { m_Binding = value; }
		}
		Bitmap m_BookImage;
		public Bitmap BookImage
		{
			get { return m_BookImage; }
			set { m_BookImage= value; }
		}
		ArrayList m_Authors = new ArrayList();
		public ArrayList Authors
		{
			get { return m_Authors; }			
		}
		ArrayList m_Subjects = new ArrayList();
		public ArrayList Subjects
		{
			get { return m_Subjects; }			
		}

		public void Save()
		{
			if (this.BookID == 0)
				SaveNewBook();
			else
				UpdateBook();
		}

		private void SaveNewBook() 
		{
			SqlCommand cm = new SqlCommand("usp_InsertBook",new SqlConnection(WebStatic.ConnectionString));

			cm.CommandType = CommandType.StoredProcedure;
			cm.Parameters.Add(new SqlParameter("@BookID", SqlDbType.Int)).Direction = ParameterDirection.Output;
			cm.Parameters.Add(new SqlParameter("@ISBN", SqlDbType.VarChar, 15)).Value = this.ISBN;		
			cm.Parameters.Add(new SqlParameter("@PageCount", SqlDbType.Int)).Value = this.PageCount;
			cm.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar,150)).Value = this.Title;
			cm.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.VarChar,150)).Value = this.Publisher;
			cm.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Decimal)).Value = this.Weight;
			cm.Parameters.Add(new SqlParameter("@PublicationDate", SqlDbType.DateTime)).Value = this.PublicationDate;
			cm.Parameters.Add(new SqlParameter("@LowestPrice", SqlDbType.Money)).Value = this.LowestPrice;
			cm.Parameters.Add(new SqlParameter("@ScanDate", SqlDbType.DateTime)).Value = this.ScanDate;
			cm.Parameters.Add(new SqlParameter("@Binding", SqlDbType.VarChar,20)).Value = this.Binding;
			cm.Parameters.Add(new SqlParameter("@ListPrice", SqlDbType.Money)).Value = this.ListPrice;
			cm.Parameters.Add(new SqlParameter("@LocationID", SqlDbType.Int)).Value = this.LocationID;
			cm.Parameters.Add(new SqlParameter("@Review", SqlDbType.Text)).Value = this.Review;
			
			cm.Connection.Open();
			cm.ExecuteNonQuery();
			this.BookID = int.Parse(cm.Parameters["@BookID"].Value.ToString());

			cm.CommandType = CommandType.Text;
			cm.CommandText = "";
			cm.Parameters.Clear();

			SqlCommand getAuthor = new SqlCommand("usp_GetAuthorID",cm.Connection);
			int AuthorID;
			getAuthor.CommandType = CommandType.StoredProcedure;
			getAuthor.Parameters.Add("@AuthorID",SqlDbType.Int).Direction = ParameterDirection.Output;
			getAuthor.Parameters.Add("@AuthorName",SqlDbType.VarChar,80);
			
			foreach (string s in this.Authors)
			{
				getAuthor.Parameters["@AuthorName"].Value = s;
				getAuthor.ExecuteNonQuery();
				AuthorID = int.Parse(getAuthor.Parameters["@AuthorID"].Value.ToString());                
				cm.CommandText += string.Format("INSERT INTO BookAuthor (BookID, AuthorID) VALUES ({0},{1}) ", this.BookID, AuthorID);
			}
			cm.ExecuteNonQuery();

			SqlCommand getSubject = new SqlCommand("usp_GetSubjectID",cm.Connection);
			int SubjectID;
			getSubject.CommandType = CommandType.StoredProcedure;
			getSubject.Parameters.Add("@SubjectID",SqlDbType.Int).Direction = ParameterDirection.Output;
			getSubject.Parameters.Add("@SubjectName",SqlDbType.VarChar,50);

			cm.CommandText = "";
			foreach (string s in this.Subjects)
			{
				getSubject.Parameters["@SubjectName"].Value = s;
				getSubject.ExecuteNonQuery();
				SubjectID = int.Parse(getSubject.Parameters["@SubjectID"].Value.ToString());                
				cm.CommandText += string.Format("INSERT INTO BookSubject (BookID, SubjectID) VALUES ({0},{1}) ", this.BookID, SubjectID);
			}
			cm.ExecuteNonQuery();

			MemoryStream m = new MemoryStream();
			this.BookImage.Save(m,ImageFormat.Jpeg);
			cm.CommandType = CommandType.StoredProcedure;
			cm.CommandText = "usp_InsertBookCoverImage";
			cm.Parameters.Add(new SqlParameter("@BookID",SqlDbType.Int)).Value = this.BookID;
			cm.Parameters.Add(new SqlParameter("@CoverImage",SqlDbType.Image)).Value = m.ToArray();
			cm.ExecuteNonQuery();
			
			cm.Connection.Close();	
			
		}

		private void UpdateBook()
		{
            SqlCommand cm = new SqlCommand("usp_UpdateBook", new SqlConnection(WebStatic.ConnectionString));

            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add(new SqlParameter("@BookID", SqlDbType.Int)).Value = this.BookID;
            cm.Parameters.Add(new SqlParameter("@ISBN", SqlDbType.VarChar, 15)).Value = this.ISBN;
            cm.Parameters.Add(new SqlParameter("@PageCount", SqlDbType.Int)).Value = this.PageCount;
            cm.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar, 150)).Value = this.Title;
            cm.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.VarChar, 150)).Value = this.Publisher;
            //cm.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Decimal)).Value = this.Weight;
            cm.Parameters.Add(new SqlParameter("@PublicationDate", SqlDbType.DateTime)).Value = this.PublicationDate;
            //cm.Parameters.Add(new SqlParameter("@LowestPrice", SqlDbType.Money)).Value = this.LowestPrice;
            cm.Parameters.Add(new SqlParameter("@ScanDate", SqlDbType.DateTime)).Value = this.ScanDate;
            //cm.Parameters.Add(new SqlParameter("@Binding", SqlDbType.VarChar, 20)).Value = this.Binding;
            cm.Parameters.Add(new SqlParameter("@ListPrice", SqlDbType.Money)).Value = this.ListPrice;
            //cm.Parameters.Add(new SqlParameter("@LocationID", SqlDbType.Int)).Value = this.LocationID;
            //cm.Parameters.Add(new SqlParameter("@Review", SqlDbType.Text)).Value = this.Review;

            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();	
		}
	}
    public class WebStatic
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SellyLibrary"].ConnectionString;
        public static string PubsConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["pubsConn"].ConnectionString;
    }

