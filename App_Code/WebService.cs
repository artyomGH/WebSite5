using System;
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
        using (var db = new Entities4())
        {
            string toWhom = str;// DropDownList1.SelectedItem.ToString();
            string fromWhom = User.Identity.Name.ToString();
            if (db.Mesages.Count() > 0)
            {
                List<Mesage> messageHistory = db.Mesages.Where(m => (m.towhom == toWhom && m.fromwhom == fromWhom)
                 || (m.fromwhom == toWhom && m.towhom == fromWhom)).OrderBy(m => m.date).ToList();
                messageHistory.Reverse();

                foreach (Mesage m in messageHistory)
                {
                    write_messages += m.fromwhom + "(" + m.date.Value.ToShortTimeString().ToString() + "):" + "\n";
                    write_messages += "   " + m.message + "\n";
                }
            }

        }
        
        /*var fromEncodind = Encoding.UTF8;//из какой кодировки
        var bytes = fromEncodind.GetBytes(write_messages);
        var toEncoding = Encoding.GetEncoding(1251);//в какую кодировку
        write_messages = toEncoding.GetString(bytes);
        System.Diagnostics.Debug.WriteLine(write_messages);*/
        return write_messages;
    }

}
