using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class newsdetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["newsid"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            String constr = "data source=(local);database=NewsDB;uid=sa;pwd=sa2008;";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from News where NewsID=@NewsID";
            cmd.Parameters.Add("@NewsID", SqlDbType.NVarChar).Value = Request.QueryString["newsid"].ToString();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                lbltitle.Text = reader["Title"].ToString();
                lblauthor.Text = reader["Author"].ToString();
                lbldate.Text = reader["NewsDate"].ToString();
                lblbody.Text = reader["NewsBody"].ToString();
                if (reader["NewsPhoto"].ToString() != "")
                {
                    Image1.ImageUrl = "~/upimage/" + reader["NewsPhoto"].ToString();
                    Image1.Visible = true;
                }
                else
                {
                    Image1.Visible = false;
                }

                if (reader["NewsFile"].ToString() != "")
                {
                    HyperLink1.NavigateUrl = "~/upfile/" + reader["NewsFile"].ToString();
                    HyperLink1.Visible = true;
                }
                else
                {
                    HyperLink1.Visible = false;
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                reader.Close();
                conn.Close();
                Response.Redirect("Default.aspx");
            }



        }
    }
}