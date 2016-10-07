using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Timestamp_ascx : System.Web.UI.UserControl
{
	public object TimestampValue
	{
		get 
		{ 
			byte[] ba = new byte[8];
			for(int indx = 0; indx < 8; indx++)
			{
				ba[indx] = Convert.ToByte(
					txtTimestamp.Text.Substring(indx * 3,2),16);
			}
			return ba;
		}
		set 
		{ 			
			txtTimestamp.Text = BitConverter.ToString((byte[])value);
		}
	}

}
