using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
        Button1.Attributes.Add("onclick", "return confirm('真的要删除吗？')");
    }
    public void bind()//数据绑定
    {
        String constr = "server=(local);database=NewsDB;User ID=sa;pwd=sa2008;";
        SqlConnection conn = new SqlConnection(constr);//得到一个SqlConnection	
        string sqlstr = "select * from news order by NewsDate desc";
        SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
        DataSet ds = new DataSet();
        da.Fill(ds, "dsnews");
        GridView1.DataSource = ds.Tables["dsnews"].DefaultView;
        GridView1.DataKeyNames = new string[] { "NewsID" };
        GridView1.DataBind();

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("Checkbox1");
            if (CheckBox2.Checked)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String constr = "server=(local);database=NewsDB;User ID=sa;pwd=sa2008;";
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        SqlCommand cmd;

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("Checkbox1");
            if (cbox.Checked)
            {
                //删除
                cmd = conn.CreateCommand();
                cmd.CommandText = "select * from news where NewsID=@NewsID";
                cmd.Parameters.Add("@NewsID", SqlDbType.Int).Value = GridView1.DataKeys[i].Value;
                SqlDataReader reader = cmd.ExecuteReader();
                string NewsFile = "";
                string NewsPhoto = "";
                if (reader.Read())
                {
                    NewsFile = reader["NewsFile"].ToString();
                    NewsPhoto = reader["NewsPhoto"].ToString(); 
                }
                if (NewsFile != "")
                {
                    string savepath = Server.MapPath("~/upfile/") + "/" + NewsFile;
                    File.Delete(savepath);
                }
                if (NewsPhoto != "")
                {
                    string savepath2 = Server.MapPath("~/upimage/") + "/" + NewsPhoto;
                    File.Delete(savepath2);
                }
                reader.Close();
                cmd = conn.CreateCommand();
                cmd.CommandText = "delete from news where NewsID=@NewsID";
                cmd.Parameters.Add("@NewsID", SqlDbType.Int).Value = GridView1.DataKeys[i].Value;
                cmd.ExecuteNonQuery();
            }
            else
            {
                //继续查询
            } 
        }
        conn.Close();
        bind(); 
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string constr = "server=(local);database=NewsDB;User ID=sa;pwd=sa2008;";
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        TextBox TBTitle = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
        TextBox TBAuthor = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
        TextBox TBNewsDate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");
        DropDownList DDLState=(DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "update news set Title=@Title,Author=@Author,NewsDate=@NewsDate,State=@State where NewsID=@NewsID";
        cmd.Parameters.Add("@NewsID",SqlDbType.Int).Value = GridView1.DataKeys[e.RowIndex].Value;
        cmd.Parameters.Add("@Title",SqlDbType.NVarChar).Value = TBTitle.Text;
        cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = TBAuthor.Text;
        cmd.Parameters.Add("@NewsDate",SqlDbType.DateTime).Value = TBNewsDate.Text;
        cmd.Parameters.Add("@State",SqlDbType.NVarChar).Value = DDLState.SelectedItem.Value;
        cmd.ExecuteNonQuery();
        conn.Close();
        GridView1.EditIndex = -1;
        bind();

    }
}