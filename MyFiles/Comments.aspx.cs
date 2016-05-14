using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyFiles_Comments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text != "")
        {
            string toWhom = "all";
            string fromWhom = "";
            if (TextBox2.Text == "")
                fromWhom = "Гість";
            else
                fromWhom = TextBox2.Text;

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
                List<Mesage> messageHistory = db.Mesages.Where(m => (m.towhom.ToString() == toWhom)).ToList();
                messageHistory.Reverse();
                foreach (Mesage m in messageHistory)
                {
                    write_messages += m.fromwhom + "(" + m.date.Value.ToShortTimeString().ToString() + "):" + "\n";
                    write_messages += "   " + m.message + "\n";
                }
            }
            TextBox1.Text = write_messages;
        }

    }
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}
