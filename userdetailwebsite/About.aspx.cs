using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace userdetailwebsite
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadRecord();
            }
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString);
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void LoadRecord()
        {
            SqlCommand comm = new SqlCommand("Select * from userdetailsTable", con);
            SqlDataAdapter d = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadRecord();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string dob = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string ph = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;

            con.Open();
            SqlCommand comm = new SqlCommand("update userdetailsTable set u_name=@uname, u_DOB=@udob, u_phone=@uphone where u_id = @id", con);
            comm.Parameters.AddWithValue("@id", id);
            comm.Parameters.AddWithValue("@uname", name);
            comm.Parameters.AddWithValue("@udob", dob.Split(' ')[0]);
            comm.Parameters.AddWithValue("@uphone", ph);
            int t = comm.ExecuteNonQuery();
            con.Close();
            if (t > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('successfully updated!')", true);
                GridView1.EditIndex = -1;
                LoadRecord();
            }
            
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadRecord();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());


            con.Open();
            SqlCommand comm = new SqlCommand("delete from userdetailsTable where u_id = @id", con);
            comm.Parameters.AddWithValue("@id", id);
            int t = comm.ExecuteNonQuery();
            con.Close();
            if (t > 0)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('deleted updated!')", true);
                GridView1.EditIndex = -1;
                LoadRecord();
            }
        }

        protected void ChkEmpty_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkstatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkstatus.NamingContainer;
        }

        protected void ChkHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkheader = (CheckBox)GridView1.HeaderRow.FindControl("ChkHeader");
            foreach(GridViewRow row in GridView1.Rows)
            {
                CheckBox chkrow = (CheckBox)row.FindControl("chkEmpty");
                if(chkheader.Checked==true)
                {
                    chkrow.Checked = true;
                }
                else
                {
                    chkrow.Checked = false;
                }
            }
        }

        protected void delbtn_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<GridView1.Rows.Count; i++)
            {
                CheckBox chkdelete = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chkEmpty");
                if (chkdelete.Checked)
                {
                    int id = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
                    con.Open();
                    SqlCommand comm = new SqlCommand("delete from userdetailsTable where u_id = @id", con);
                    comm.Parameters.AddWithValue("@id", id);
                    int t = comm.ExecuteNonQuery();
                    con.Close();
                    if (t > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('deleted updated!')", true);
                        GridView1.EditIndex = -1;
                    }

                }
            }
            LoadRecord();
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        protected void updatebtn_Click(object sender, EventArgs e)
        {
            int chkcount = 0;
            int k = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkupdate = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chkEmpty");
                if (chkupdate.Checked)
                {
                    k = i;
                    chkcount++;
                    if (chkcount > 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Please select one item to update!')", true);
                        break;
                    }
                }
            }
            int id = Convert.ToInt32(GridView1.Rows[k].Cells[1].Text);
            Session["sendid"] = id;
            Response.Redirect("/default.aspx");
            //Response.Redirect("/default.aspx?id=" + id);
        }
    }
}