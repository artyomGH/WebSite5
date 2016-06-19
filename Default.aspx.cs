using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //AspNetUser currentUser = new AspNetUser();
        //car currentCar = new car();
        //List<car> listAvto = new List<car>();
        //List<AspNetUser> listUsers = new List<AspNetUser>();
        //List<order> listOrder = new List<order>();

        string str = User.Identity.Name.ToString();
        if (str != "")
        {
            using (var db = new Entities5())
            {

                AspNetUser User = db.AspNetUsers.Where(m => m.UserName == str).First();
                if (User.ManagerRights == true)
                    ForManager.Visible = true;

            }
        }

    }

    protected void EnterToChat_Click(object sender, EventArgs e)
    {
        string a = User.Identity.Name.ToString();
        //
        // Response.Write("<script>alert(tra-la-la');</script>");
        if (a != "")
            Response.Redirect("/MyFiles/Mail.aspx");
        else
            Response.Write("<script>window.alert('Увійдіть в систему');" +
                                    "setTimeout('location.replace(\"/Account/Login.aspx\")', 100);</script>");
    }

    protected void GoToComments_Click(object sender, EventArgs e)
    {
        
            Response.Redirect("/MyFiles/Comments.aspx");
        
    }
    protected void OrderTracking_Click(object sender, EventArgs e)
    {
        string a = User.Identity.Name.ToString();
        //
        // Response.Write("<script>alert(tra-la-la');</script>");
        if (a != "")
            Response.Redirect("/MyFiles/OrderTracking.aspx");
        else
            Response.Write("<script>window.alert('Увійдіть в систему');" +
                                    "setTimeout('location.replace(\"/Account/Login.aspx\")', 100);</script>");
    }

    protected void Video_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MyFiles/Video.aspx");
    }

    protected void ForManager_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MyFiles/Managers.aspx");
    }
}