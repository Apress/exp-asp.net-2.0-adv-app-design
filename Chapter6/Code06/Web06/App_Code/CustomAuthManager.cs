using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;

public class CustomAuthManager : UsernameTokenManager
{
  private string ConnStr = "server=.;database=...";
  protected override string AuthenticateToken( UsernameToken token )
  {
    string password = "";

    // Extract user name from the token.
    string username = token.Username;
    SqlCommand cm = new SqlCommand
         ("select Password from UserTable WHERE UserName = @UserName", 
         new SqlConnection( ConnStr));
    cm.Parameters.Add("@UserName", SqlDbType.VarChar, 30).Value = username;
    cm.Connection.Open();
    Object o = cm.ExecuteScalar();
    cm.Connection.Close();
    
    if (o != null)
        password = o.ToString();        
            
    return password;
  }
}
