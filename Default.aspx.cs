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

    }

    protected void EnterToChat_Click(object sender, EventArgs e)
    {
        string a = User.Identity.Name.ToString();
        //
        // Response.Write("<script>alert(tra-la-la');</script>");
        if (a != "")
            Response.Redirect("/MyFiles/Mail.aspx");
        else
            Response.Write("<script>window.alert('Войдите в систему');</script>");
        //Response.Write("window.alert('Успешно');");
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
            Response.Write("<script>window.alert('Войдите в систему');</script>");
        //Response.Write("window.alert('Успешно');");
    }

    protected void Video_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MyFiles/Video.aspx");
    }
}