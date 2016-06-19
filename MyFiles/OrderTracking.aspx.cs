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
            if (db.cars.Where(m => (m.client.email == currentUser.Email)).Count() > 0)
            {
                listAvto = db.cars.Where(m => (m.client.email == currentUser.Email)).ToList();
                currentCar = listAvto[0];
                listOrder = db.orders.Where(m => (m.Car_idCar == currentCar.idCar)).ToList();
            }                   
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

        fillTable();
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
        fillTable();
    }
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
    public string fillTable()
    {


        Table1.BackColor = Color.WhiteSmoke;
        if (Table1.Rows != null)
            Table1.Rows.Clear();

        TableHeaderRow headerRow = new TableHeaderRow();
        headerRow.BackColor = Color.BlanchedAlmond;

        string[] headerName= { "Назва операції", "Прізвище робітника", "Рівень кваліфікації робітника",
                               "Робота повинна була розпочатись", "Фактично розпочалась", "Робота повинна була завершитись", "Фактично закінчилась", "Статус операції"};
        int numberOfHeadCell = headerName.Length;
        TableHeaderCell[] headerTableCells = new TableHeaderCell[numberOfHeadCell];

        for (int i=0;i<numberOfHeadCell;i++)
        {
            headerTableCells[i] = new TableHeaderCell();
            headerTableCells[i].Text = headerName[i];
        }
        
        headerRow.Cells.AddRange(headerTableCells);
        
        Table1.Rows.AddAt(0, headerRow);
       
        string tmp = "";
        string tmp2 = "";
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
            List<process> listProcess = new List<process>();
            //операция и воркер создавать 
            using (var db = new workshopEntities())
            {
                currentCar = db.cars.Where(m => m.registrNumber == currentCarRegistrNumber).First();
                curOrder = db.orders.Where(m => m.idOrder.ToString() == currentOrderId).First();


                tmp += "carNumber: " + curOrder.car.registrNumber.ToString();
                tmp += "\norder id: " + curOrder.idOrder.ToString();
                tmp += "\norder status: " + curOrder.status.ToString();
                tmp += "\nmanager: " + curOrder.worker.lastName;
                listProcess = db.processes.Where(m => m.Order_idOrder == curOrder.idOrder).ToList();
                List<TableRow> listRows=new List<TableRow>();
                foreach (process p in listProcess)
                {

                    TableRow table1Row = new TableRow();
                    listRows.Add(table1Row);
                    TableCell[] TableCells = new TableCell[numberOfHeadCell];
                    for (int i = 0; i < numberOfHeadCell; i++)
                    {
                        TableCells[i] = new TableHeaderCell();
                    }
                    tmp2=p.operation.nameOperation.ToString();
                    TableCells[0].Text = tmp2.Replace("+", " ");
                    TableCells[1].Text = p.worker.lastName.ToString();
                    if (true== db.workerhasskills.Select(m => ((m.Worker_idWorker == p.Worker_idWorker) && (m.Operation_idOperation == p.Operation_idOperation))).First())
                        TableCells[2].Text = db.workerhasskills.Where(m => ((m.Worker_idWorker == p.Worker_idWorker) && (m.Operation_idOperation == p.Operation_idOperation))).First().level.ToString();
                    else
                        TableCells[2].Text = "Не зазначено";
                    TableCells[6].Width = " 2016-03-31".Length+40;
                    TableCells[3].Text = p.dateTimeStart.ToString() ?? "Не зазначено";
                    TableCells[4].Text = p.dateTimeStartFact.ToString() ?? "Не зазначено";                    
                    TableCells[5].Text = p.dateTimeFinish.ToString() ?? "Не зазначено";
                    TableCells[6].Text = p.dateTimeFinishFact.ToString() ?? "Не зазначено";
                    if(p.dateTimeFinishFact==null && p.dateTimeFinish<DateTime.Now)
                    {
                        TableCells[7].Text = "Затримка";
                        TableCells[7].ForeColor = Color.OrangeRed;
                    }
                    else if (p.dateTimeFinish < p.dateTimeFinishFact)
                    {
                        TableCells[7].Text = "Була затримка";
                        TableCells[7].ForeColor = Color.Gold;
                    }
                    else if (p.dateTimeFinishFact == null  &&  DateTime.Now<p.dateTimeFinishFact)
                    {
                        TableCells[7].Text = "В роботі";
                        //TableCells[7].ForeColor = Color.Yellow;
                    }
                    else
                    {
                        TableCells[7].Text = "Вчасно";
                        TableCells[7].ForeColor = Color.DarkSeaGreen;
                    }

                    table1Row.Cells.AddRange(TableCells);
                    

                    Table1.Rows.Add(table1Row);

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