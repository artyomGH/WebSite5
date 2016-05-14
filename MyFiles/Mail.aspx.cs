using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
public partial class MyFiles_Mail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name.ToString() == "")
            Response.Redirect("/Default.aspx");
        List<AspNetUser> listUsers = new List<AspNetUser>();
        AspNetUser potochnuj = new AspNetUser();
        using (var db = new Entities5())
        {

            listUsers = db.AspNetUsers.ToList();

            foreach (AspNetUser m in listUsers)
                if (m.UserName == User.Identity.Name.ToString())
                {
                    potochnuj = m;
                }
        }
        listUsers.Remove(potochnuj);
        DropDownList1.DataSource = listUsers;
        DropDownList1.DataTextField = "UserName";
        DropDownList1.DataValueField = "Id";
        if (!IsPostBack)
        {
            DropDownList1.DataBind();
            //db.SaveChanges();

        }
        
        nickname.Text = User.Identity.Name.ToString();

    }

    protected void btnSend(object sender, EventArgs e)
    {
        if (TextBox3.Text != "")
        {
            string toWhom = DropDownList1.SelectedItem.ToString();
            string fromWhom = User.Identity.Name.ToString();
            Mesage message = new Mesage();

            String write_messages = "";
            message.towhom = toWhom;
            message.fromwhom = fromWhom;
            message.read = 0;
            message.message = TextBox3.Text;
            
            message.date = DateTime.Now;

            
            using (var db = new Entities5())
            {
                
                System.Diagnostics.Debug.WriteLine("MESSAGE : " + db.Mesages.Count().ToString());
                if (0 < db.Mesages.Count())
                    message.Id = db.Mesages.Select(m => m.Id).ToList().Max() + 1;
                else
                    message.Id = 0;
                db.Mesages.Add(message);
                db.SaveChanges();

                //==========
                
                

                ///=====
                List<Mesage> messageHistory = db.Mesages.Where(m => (m.towhom.ToString() == toWhom && m.fromwhom.ToString() == fromWhom)
                || (m.fromwhom.ToString() == toWhom && m.towhom.ToString() == fromWhom)).OrderBy(m => m.date).ToList();
                messageHistory.Reverse();
                foreach (Mesage m in messageHistory)
                {
                    write_messages += m.fromwhom + "(" + m.date.Value.ToShortTimeString().ToString() + "):" + "\n";
                    write_messages += "   " + m.message + "\n";
                }
            }
            TextBox1.Text = write_messages;
        }
        else
            Label2.Text = "Введить текст сообщения";
    }
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}