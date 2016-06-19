using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class MyFiles_Managers : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (User.Identity.Name.ToString() == "")
            Response.Redirect("/Default.aspx");
        List<AspNetUser> listUsers = new List<AspNetUser>();
        List<AspNetUser> listManagers = new List<AspNetUser>();
        AspNetUser potochnuj = new AspNetUser();

        StreamWriter wr = new StreamWriter(@"E:\logWebSite5.txt", true);
        wr.WriteLine("Page_Load()");
        
        using (var db = new Entities5())
        {
            listUsers = db.AspNetUsers.Where(m=>m.ManagerRights!= true).ToList();
            listManagers = db.AspNetUsers.Where(m => m.ManagerRights == true).ToList();
            foreach (AspNetUser m in listManagers)
            {
                wr.WriteLine("m.UserName = "+ m.UserName+ " User.Identity.Name.ToString())"+ User.Identity.Name.ToString());
                if (m.UserName == User.Identity.Name.ToString())
                {
                    potochnuj = m;
                }
            }
        }
        wr.Close();
        
        listManagers.Remove(potochnuj);

        CheckBoxList1.DataSource = listUsers;
        CheckBoxList1.DataTextField = "UserName";
        CheckBoxList1.DataValueField = "Id";

        CheckBoxList2.DataSource = listManagers;
        CheckBoxList2.DataTextField = "UserName";
        CheckBoxList2.DataValueField = "Id";
        if (!IsPostBack)
        {
            CheckBoxList1.DataBind();
            CheckBoxList2.DataBind();
            

        }
    }
    
    protected void btnConfirm_Click(object sender, EventArgs e)
    {        
        AspNetUser changedUser;
        StreamWriter wr = new StreamWriter(@"E:\logWebSite5.txt", true);
        wr.WriteLine("btnConfirm_Click()");
        wr.WriteLine(CheckBoxList1.Items.ToString());
       
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                using (var db = new Entities5())
                {
                    changedUser = db.AspNetUsers.Where(m => m.Id == item.Value).First();
                    changedUser.ManagerRights = true;
                    db.SaveChanges();
                    wr.WriteLine("item value "+ item.Value.ToString());
                    wr.WriteLine("changedUser " + changedUser.UserName.ToString());
                    
                }
            }
        }
        wr.Close();
        Response.Redirect("/MyFiles/Managers.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        AspNetUser changedUser;
        StreamWriter wr = new StreamWriter(@"E:\logWebSite5.txt", true);
        wr.WriteLine("btnDelete_Click()");
        wr.WriteLine(CheckBoxList2.Items.ToString());

        foreach (ListItem item in CheckBoxList2.Items)
        {
            if (item.Selected)
            {
                using (var db = new Entities5())
                {
                    changedUser = db.AspNetUsers.Where(m => m.Id == item.Value).First();
                    changedUser.ManagerRights = false;
                    db.SaveChanges();
                    wr.WriteLine("item value " + item.Value.ToString());
                    wr.WriteLine("changedUser " + changedUser.UserName.ToString());

                }
            }
        }
        wr.Close();
        Response.Redirect("/MyFiles/Managers.aspx");
    }
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}