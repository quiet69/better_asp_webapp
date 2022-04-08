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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sendid"] != null)
                {
                    btnUpdate.Visible = true;
                    btncancel.Visible = true;
                    btnSubmit.Visible = false;
                    //string updateID = Request.QueryString["id"]; //problem with autopostback date picker :3
                    string updateID = Session["sendid"].ToString();
                    int loadid;
                    if (updateID != "")
                    {

                        try
                        {
                            loadid = Convert.ToInt32(updateID);
                            getDataByID(loadid);
                        }
                        catch
                        {
                            //
                        }
                    }
                }
            }

        }

        void resetFields()
        {
            nameTB.Text = "";
            dobTB.Text = "";
            ageTB.Text = "";
            phoneTB.Text = "";
        }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString);

        void getDataByID(int loadid)
        {
            con.Open();
            //SqlCommand comm = new SqlCommand("Select * from userdetailsTable where u_id = '" +loadid+ "'", con);
            SqlCommand comm = new SqlCommand("exec SelectUser @id", con);
            comm.Parameters.AddWithValue("@id", loadid);
            SqlDataReader r = comm.ExecuteReader();
            while (r.Read())
            {
                nameTB.Text = r.GetValue(1).ToString();
                //dobTB.Text = phoneTB.Text = (Convert.ToDateTime(r[2]).ToString("yyyy-MM-dd"));
                dobTB.Text = phoneTB.Text = (Convert.ToDateTime(r.GetValue(2)).ToString("yyyy-MM-dd"));
                phoneTB.Text = r.GetValue(3).ToString();

            }
            con.Close();
            calcAge();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            //SqlCommand comm = new SqlCommand("insert into userdetailsTable (u_name, u_DOB, u_phone) values(@uname, @udob, @uphone)", con);
            SqlCommand comm = new SqlCommand("exec InsertUser @uname, @udob, @uphone", con);
            comm.Parameters.AddWithValue("@uname", nameTB.Text);
            comm.Parameters.AddWithValue("@udob", dobTB.Text);
            comm.Parameters.AddWithValue("@uphone", phoneTB.Text);
            comm.ExecuteNonQuery();
            con.Close();
            resetFields();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('successfully inserted')", true);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int owoid = Convert.ToInt32(Session["sendid"]);
            con.Open();
            SqlCommand comm = new SqlCommand("exec UpdateUser @id, @uname, @udob, @uphone", con);
            //SqlCommand comm = new SqlCommand("update userdetailsTable set u_name=@uname, u_DOB=@udob, u_phone=@uphone where u_id = @id", con);
            comm.Parameters.AddWithValue("@uname", nameTB.Text);
            comm.Parameters.AddWithValue("@udob", dobTB.Text);
            comm.Parameters.AddWithValue("@uphone", phoneTB.Text);
            comm.Parameters.AddWithValue("@id", owoid);
            comm.ExecuteNonQuery();
            con.Close();
            resetFields();
            btnUpdate.Visible = false;
            btncancel.Visible = false;
            btnSubmit.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(),"script", "alert('User  updated sucessfully'); window.location = './about.aspx';", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('successfully updated')", true);
            Session.Abandon(); // so that update button disappears
            //Response.Redirect("/about.aspx"); //using this makes alert script no worky owo :{

        }

        protected void dobTB_TextChanged(object sender, EventArgs e)
        {
            calcAge();
    
        }

        void calcAge()
        {
            try
            {
                DateTime dob = DateTime.Parse(dobTB.Text);
                DateTime now = DateTime.Now;
                TimeSpan ts = now - dob;
                int age = (ts.Days / 365);
                if (age > 16 && age < 110)
                {
                    ageTB.Text = age.ToString();
                }
                else
                {
                    dobTB.Text = "";
                }
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter valid DoB')", true);
            }
            catch
            {

            }
    
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/about.aspx");
        }
    }
}