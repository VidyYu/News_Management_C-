using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class NewsAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string texttohtml(string chr)
    {
        if (chr == null)
            return "";
        chr = Server.HtmlEncode(chr);
        chr = chr.Replace("\n", "<br />");
        chr = chr.Replace(" ", "&nbsp");
        return (chr);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try { 
        if(Page.IsValid)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            string upfilename = "";
            string upimagename = "";
            string upfilename2 = "";
            string upimagename2 = "";
            string upfilepath = Server.MapPath("~/upfile/");
            string upimagepath = Server.MapPath("~/upimage/");
            DateTime ctime = DateTime.Now;
            string ctimestring = "";
            ctimestring = ctime.Year.ToString() + ctime.Month.ToString() + ctime.Day.ToString() + ctime.Hour.ToString() + ctime.Minute.ToString() + ctime.Second.ToString() + ctime.Millisecond.ToString();
            int upfilestyle = 0;
            int upimagestyle = 0;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentLength > 104857600)
                {
                    Label2.Text = "附件文件太大";
                    upfilestyle = 2;
             
                }
                else
                {
                    upfilestyle = 1;
                    upfilename = FileUpload1.FileName;
                    upfilename2 = upfilename.Substring(upfilename.LastIndexOf("."));
                }
            }
            if (FileUpload2.HasFile)
            {
                if (FileUpload2.PostedFile.ContentLength > 10485760)
                {
                    Label3.Text = "图片文件太大";
                    upimagestyle = 2;

                }
                else
                {
                    upimagename = FileUpload2.FileName;
                    upimagename2 = upimagename.Substring(upimagename.LastIndexOf("."));
                    if(upimagename2.ToLower()==".jpg"||upimagename2.ToLower()==".gif"|| upimagename2.ToLower() == ".png"|| upimagename2.ToLower() == ".bmp")
                    {
                        upimagestyle = 1;
                    }
                    else
                    {
                        Label3.Text = "图片格式不正确";
                        upimagestyle = 2;
                    }
                }
            }
            if (upfilestyle < 2 && upimagestyle < 2)
            {
                if (upfilestyle == 1)
                {

                    upfilename = ctimestring + upfilename2;
                    upfilepath = upfilepath + "/" + upfilename;
                    FileUpload1.SaveAs(upfilepath);
                }
                else
                    upfilename = "";
                if (upimagestyle == 1)
                {
                    upimagename = ctimestring + upimagename2;
                    upimagepath = upimagepath + "/" + upimagename;
                    FileUpload2.SaveAs(upimagepath);
                }
                else
                    upimagename = "";
            String constr = "data source=(local);database=NewsDB;uid=sa;pwd=sa2008;";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into News(Title,Author,NewsDate,NewsBody,NewsPhoto,NewsFile) values(@Title,@Author,@NewsDate,@NewsBody,@NewsPhoto,@NewsFile)";
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = texttohtml(TextBox1.Text);
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = TextBox3.Text;
            cmd.Parameters.Add("@NewsBody", SqlDbType.Text).Value = texttohtml(TextBox2.Text);
            cmd.Parameters.Add("@NewsDate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@NewsPhoto", SqlDbType.NVarChar).Value = upimagename;
            cmd.Parameters.Add("@NewsFile", SqlDbType.NVarChar).Value = upfilename;
            cmd.ExecuteNonQuery();
            conn.Close();
            Label1.Text = "新闻发布成功";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            }

        }
        else
        {
            Label1.Text = "请输入标题";
        }
        }
        catch
        {
            Label1.Text = "程序错误或不合法,请重试";
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}