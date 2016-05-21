using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

public partial class MyFiles_OrderTracking : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name.ToString() == "")
            Response.Redirect("/Default.aspx");
         AspNetUser currentUser = new AspNetUser();
        car currentCar = new car();
        List<car> listAvto = new List<car>();
        List<AspNetUser> listUsers = new List<AspNetUser>();        
        List<order> listOrder = new List<order>();
       
        using (var db = new Entities5())
        {
            listUsers = db.AspNetUsers.ToList();
            foreach (AspNetUser m in listUsers)
                if (m.UserName == User.Identity.Name.ToString())
                {
                    currentUser = m;
                }            
        }
        using (var db = new workshopEntities())
        {
            listAvto = db.cars.Where(m => (m.client.email == currentUser.Email)).ToList();
            currentCar = listAvto[0];
            listOrder = db.orders.Where(m => (m.Car_idCar == currentCar.idCar)).ToList();                     
        }

        
        DropDownList1.DataSource = listAvto;
        DropDownList1.DataTextField = "registrNumber";
        DropDownList1.DataValueField = "idCar";

        DropDownList2.DataSource = listOrder;
        DropDownList2.DataTextField = "dateTime";
        DropDownList2.DataValueField = "idOrder";


        if (!IsPostBack)
        {
            DropDownList1.DataBind();

            DropDownList2.DataBind();
        }

        TextBox1.Text= fillTable();
        //fillTable();
    }
    public void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<order> listOrder = new List<order>();

        using (var db = new workshopEntities())
        {
            car curCar = new car();
            curCar = db.cars.Where(m => (m.idCar.ToString() == DropDownList1.SelectedValue)).First();
            
            listOrder = db.orders.Where(m => (m.Car_idCar == curCar.idCar)).ToList();
        }
        DropDownList2.DataSource = listOrder;
        DropDownList2.DataTextField = "dateTime";
        DropDownList2.DataValueField = "idOrder";
        DropDownList2.DataBind();

        //StreamWriter wr = new StreamWriter(@"E:\logWebSite5.txt", true);
        //wr.WriteLine("DropDownList1_SelectedIndexChanged()");
        //wr.WriteLine(DropDownList1.SelectedItem.ToString());
        //wr.WriteLine(DropDownList2.SelectedItem.ToString());
        //wr.Close();
        TextBox1.Text=fillTable();
    }
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
    public string fillTable()
    {
        #region
        //// Generate rows and cells.           
        //int numrows = 3;
        //int numcells = 2;
        //for (int j = 0; j < numrows; j++)
        //{
        //    TableRow r = new TableRow();
        //    for (int i = 0; i < numcells; i++)
        //    {
        //        TableCell c = new TableCell();
        //        c.Controls.Add(new LiteralControl("row "
        //            + j.ToString() + ", cell " + i.ToString()));
        //        r.Cells.Add(c);
        //    }
        //    Table1.Rows.Add(r);
        //}
        // Create a TableHeaderRow.
        if (Table1.Rows != null)
            Table1.Rows.Clear();

        TableHeaderRow headerRow = new TableHeaderRow();
        headerRow.BackColor = Color.BlanchedAlmond;

        // Create TableCell objects to contain 
        // the text for the header.
        TableHeaderCell headerTableCell1 = new TableHeaderCell();
        TableHeaderCell headerTableCell2 = new TableHeaderCell();
        TableHeaderCell headerTableCell3 = new TableHeaderCell();
        headerTableCell1.Text = "Назва операції";
        headerTableCell1.Scope = TableHeaderScope.Column;

        headerTableCell2.Text = "Тривалість";
        headerTableCell2.Scope = TableHeaderScope.Column;

        headerTableCell3.Text = "Ім'я робітника";
        headerTableCell3.Scope = TableHeaderScope.Column;


        // Add the TableHeaderCell objects to the Cells
        // collection of the TableHeaderRow.
        headerRow.Cells.Add(headerTableCell1);
        headerRow.Cells.Add(headerTableCell2);
        headerRow.Cells.Add(headerTableCell3);

        // Add the TableHeaderRow as the first item 
        // in the Rows collection of the table.
        Table1.Rows.AddAt(0, headerRow);
        #endregion
        string tmp = "";
        if (DropDownList1.SelectedItem != null)
        {
            //StreamWriter wr = new StreamWriter(@"E:\logWebSite5.txt", true);
            //wr.WriteLine("fillTable()");
            //wr.WriteLine("fillTable()"+DropDownList1.SelectedItem.ToString());
            //wr.WriteLine("fillTable()"+DropDownList2.SelectedValue.ToString());
            //wr.Close();
            string currentCarRegistrNumber = DropDownList1.SelectedItem.ToString();
            string currentOrderId = DropDownList2.SelectedValue.ToString();
            car currentCar = new car();
            order curOrder = new order();
            //operation operation = new operation();
            List<process> listProcess = new List<process>();
            using (var db = new workshopEntities())
            {
                currentCar = db.cars.Where(m => m.registrNumber == currentCarRegistrNumber).First();
                curOrder = db.orders.Where(m => m.idOrder.ToString() == currentOrderId).First();


                tmp += "carNumber: " + curOrder.car.registrNumber.ToString();
                tmp += "\norder id: " + curOrder.idOrder.ToString();
                tmp += "\norder status: " + curOrder.status.ToString();
                tmp += "\nmanager: " + curOrder.worker.lastName;
                listProcess = db.processes.Where(m => m.Order_idOrder == curOrder.idOrder).ToList();
                foreach (process p in listProcess)
                {
                    TableRow tmp_row = new TableRow();
                    TableCell tmp_cell1 = new TableCell();
                    TableCell tmp_cell2 = new TableCell();
                    TableCell tmp_cell3 = new TableCell();
                    tmp_cell1.Text = p.operation.nameOperation.ToString();
                    tmp_row.Cells.Add(tmp_cell1);
                    tmp_cell2.Text= p.operation.duration.ToString();
                    tmp_row.Cells.Add(tmp_cell2);
                    tmp_cell3.Text = p.worker.lastName.ToString();
                    tmp_row.Cells.Add(tmp_cell3);
                    Table1.Rows.Add(tmp_row);
                    tmp += "\nname operation: " + p.operation.nameOperation.ToString();
                    tmp += "\nduration operation: " + p.operation.duration.ToString();
                    tmp += "\nworker: " + p.worker.lastName.ToString();
                }
                
            }


        }
        
        return tmp;
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