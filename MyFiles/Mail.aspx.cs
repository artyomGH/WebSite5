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
            if (potochnuj.ManagerRights == false)
                listUsers = db.AspNetUsers.Where(m => m.ManagerRights == true).ToList();
            else
            {
                //listUsers = db.AspNetUsers.ToList();
                listUsers.Remove(potochnuj);
            }
        }
        
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
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}