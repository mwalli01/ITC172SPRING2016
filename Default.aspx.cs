using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    DataClass dc = new DataClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDropDownList();
    }
    protected void LoadDropDownList()
    {
        DataTable tbl = dc.GetServices();
        DropDownList1.DataSource = tbl;
        DropDownList1.DataTextField = "GrantTypeName";
        DropDownList1.DataValueField = "GrantTypeKey";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Choose A Service");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(!IsPostBack)
        FillGrid();
    }

    protected void FillGrid()
    {
        int key = int.Parse(DropDownList1.SelectedValue.ToString());
        DataTable tbl = dc.GetGrants(key);
        GridView1.DataSource = tbl;
        GridView1.DataBind();
    }
}
