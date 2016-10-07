using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

using NumberLib;

[WebService(Namespace = "http://www.IntertechTraining.com/WSDemo/NumberService")]
public class NumberService : System.Web.Services.WebService , IPhoneNumberLib
{       
    public PhoneNumber GetNumber()
    {
        return new PhoneNumber("612", "555-3434", PhoneType.Home);
    }

    public bool SaveNumber(PhoneNumber number)
    {
        return true;
    }
        
    public System.Collections.ArrayList PhoneNumberList(string criteria)
    {
        ArrayList al = new ArrayList();
        al.Add(new PhoneNumber("612","5551212",PhoneType.Cell));
        al.Add(new PhoneNumber("612","5551213",PhoneType.Fax));
        al.Add(new PhoneNumber("612","5551214",PhoneType.Home));
        al.Add(new PhoneNumber("612", "5551215", PhoneType.Office));
        return al;
    }
}
