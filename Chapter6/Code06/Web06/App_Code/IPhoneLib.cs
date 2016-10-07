using System;
using System.Collections;
using System.Web.Services;
using System.Xml.Serialization;
using NumberLib;

/// <summary>
/// Summary description for IPhoneLib
/// </summary>
/// 
[WebServiceBinding(Namespace = "http://www.IntertechTraining.com/WSDemo/PhoneNumberLib")]
public interface IPhoneNumberLib
{
    [WebMethod()]
    PhoneNumber GetNumber();
    [WebMethod()]
    bool SaveNumber(PhoneNumber number);
    [WebMethod()]
    [XmlInclude(typeof(PhoneNumber))]
    ArrayList PhoneNumberList(string criteria);
}


