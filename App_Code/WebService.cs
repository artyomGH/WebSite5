using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.IO;
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
    public string refreshChat(string str)
    {   
        string write_messages = "";
        using (var db = new Entities5())
        {
            string toWhom = str;
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
    public string addMessage(string str,string textOfMess)
    {
        string toWhom = str;
        string fromWhom = User.Identity.Name.ToString();
        string write_messages = "";

        StreamWriter w = new StreamWriter(@"E:\logWebSite5.txt");
        w.WriteLine(write_messages);
        w.Close();
        Mesage message = new Mesage();        
        message.towhom = toWhom;
        message.fromwhom = fromWhom;
        message.read = 0;
        message.message = textOfMess;
        message.date = DateTime.Now;
                
        using (var db = new Entities5())
        {            
            if (0 < db.Mesages.Count())
                message.Id = db.Mesages.Select(m => m.Id).ToList().Max() + 1;
            else
                message.Id = 0;

            db.Mesages.Add(message);
            db.SaveChanges();
            refreshChat(toWhom);            
            return write_messages;
        }
    }
    [WebMethod]
    public string refresh_comments()
    {
        List<Mesage> messageHistory = new List<Mesage>() ;
        string write_messages = "";
        using (var db = new Entities5())
        {

            string toWhom = "all";
            if(db.Mesages.Select(m => (m.towhom == toWhom)).Count() > 0)
                messageHistory = db.Mesages.Where(m => (m.towhom==toWhom)).ToList();
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
