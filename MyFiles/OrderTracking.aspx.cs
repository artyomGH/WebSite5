using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyFiles_OrderTracking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<car> listAvto = new List<car>();
        AspNetUser current = new AspNetUser();

        if (User.Identity.Name.ToString() == "")
            Response.Redirect("/Default.aspx");
        List<AspNetUser> listUsers = new List<AspNetUser>();

        using (var db = new Entities5())
        {
            listUsers = db.AspNetUsers.ToList();
            foreach (AspNetUser m in listUsers)
                if (m.UserName == User.Identity.Name.ToString())
                {
                    current = m;
                }            
        }
        using (var db = new workshopEntities())
        {
            listAvto = db.cars.Where(m => (m.client.email == current.Email)).ToList();            
        }
        DropDownList1.DataSource = listAvto;
        DropDownList1.DataTextField = "registrNumber";
        DropDownList1.DataValueField = "idCar";
        if (!IsPostBack)
        {
            DropDownList1.DataBind();
            //db.SaveChanges();

        }
        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        cell.Text = "blah blah blah";
        row.Cells.Add(cell);
        Table1.Rows.Add(row);

        TableRow row1 = new TableRow();
        TableCell cell1 = new TableCell();
        cell1.Text = "blah blah blah";
        row1.Cells.Add(cell1);
        

        Table1.Rows.Add(row1);
        
    }
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}