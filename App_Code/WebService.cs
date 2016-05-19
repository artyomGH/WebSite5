﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {

        return "a";
    }
    [WebMethod]
    public string obnovit(string str)
    {
         
        System.Diagnostics.Debug.WriteLine("obnovit"+"   "+ str);
        string write_messages = "";
        using (var db = new Entities5())
        {
            string toWhom = str;// DropDownList1.SelectedItem.ToString();
            string fromWhom = User.Identity.Name.ToString();
            if (db.Mesages.Count() > 0)
            {
                List<Mesage> messageHistory = db.Mesages.Where(m => (m.towhom.ToString() == toWhom && m.fromwhom.ToString() == fromWhom)
                 || (m.fromwhom.ToString() == toWhom && m.towhom.ToString() == fromWhom)).OrderBy(m => m.date).ToList();
                messageHistory.Reverse();

                foreach (Mesage m in messageHistory)
                {
                    write_messages += m.fromwhom + "(" + m.date.Value.ToShortTimeString().ToString() + "):" + "\n";
                    write_messages += "   " + m.message + "\n";
                }
            }

        }
        return write_messages;
    }
    [WebMethod]
    public string refresh_comments()
    {
        string write_messages = "";
        using (var db = new Entities5())
        {

            string toWhom = "all";
            
            List<Mesage> messageHistory = db.Mesages.Where(m => (m.towhom==toWhom)).ToList();
            messageHistory.Reverse();
            foreach (Mesage m in messageHistory)
            {
                write_messages += m.fromwhom + "(" + m.date.Value.ToShortTimeString().ToString() + "):" + "\n";
                write_messages += "   " + m.message + "\n";
            }
        }
        return write_messages;

    }
}
