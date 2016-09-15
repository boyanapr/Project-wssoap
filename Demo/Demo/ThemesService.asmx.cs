using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace Demo
{
    /// <summary>
    /// Summary description for ThemesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ThemesService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetFreeTheme()
        {
            List<Theme> listTheme = new List<Theme>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from frthemes", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Theme theme = new Theme();
                    theme.id = Convert.ToInt32(rdr["ID"]);
                    theme.Name = rdr["theme"].ToString();
                    theme.Number = Convert.ToInt32(rdr["numbertheme"]);
                    listTheme.Add(theme);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listTheme));
        }
        [WebMethod]
        public void GetAllStudents()
        {
            List<Student> listStudents = new List<Student>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblcheckout", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student student = new Student();
                   
                    student.Names = rdr["Names"].ToString();
                    student.FNumber = Convert.ToInt32(rdr["FNumber"]);
                    student.Theme = rdr["Theme"].ToString();
                    student.Numbertheme = Convert.ToInt32(rdr["Numbertheme"]);
                    student.Email = rdr["Email"].ToString();
                    listStudents.Add(student);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listStudents));
        }
        [WebMethod]
        public void Checkout(Student stu)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("InsertCheckout", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Names",
                    Value = stu.Names
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FNumber",
                    Value = stu.FNumber
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Theme",
                    Value = stu.Theme
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Numbertheme",
                    Value = stu.Numbertheme
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Email",
                    Value = stu.Email
                });
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

    }
}