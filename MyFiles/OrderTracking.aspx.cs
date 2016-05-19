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
        if (User.Identity.Name.ToString() == "")
            Response.Redirect("/Default.aspx");

        List<car> listAvto = new List<car>();
        List<AspNetUser> listUsers = new List<AspNetUser>();
        AspNetUser current = new AspNetUser();

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
            DropDownList1.DataBind();
            
        TextBox1.Text= GetDataForCar();
        
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
    
    public string GetDataForCar()
    {
        string tmp = "";
        if (DropDownList1.SelectedItem != null)
        {
            
            string currentCarRegistrNumber = DropDownList1.SelectedItem.ToString();
            car currentCar = new car();
            List<order> listOrder = new List<order>();
            //operation operation = new operation();
            List<process> listProcess = new List<process>();
            using (var db = new workshopEntities())
            {
                currentCar = db.cars.Where(m => m.registrNumber == currentCarRegistrNumber).First();
                listOrder = db.orders.Where(m => m.Car_idCar == currentCar.idCar).ToList();


                tmp += "carNumber: " + currentCar.registrNumber.ToString();
                foreach (order o in listOrder)
                {
                    tmp += "\norder status: " + o.status.ToString();
                    tmp += "\nmanager: " + o.worker.lastName;
                    listProcess = db.processes.Where(m => m.Order_idOrder == o.idOrder).ToList();
                    foreach (process p in listProcess)
                    {
                        tmp += "\nname operation: " + p.operation.nameOperation.ToString();
                        tmp += "\nduration operation: " + p.operation.duration.ToString();
                        tmp += "\nworker: " + p.worker.lastName.ToString();
                    }
                }
            }

            
        }
        return tmp;
    }
}