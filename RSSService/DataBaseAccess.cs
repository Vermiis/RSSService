using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace RSSReader
{
    class DataWriter
    {
        public class Post
        {
            public string PublishedDate;
            public string Description;
            public string Title;
            public string link;

        }
        public static object XmlDisplay { get; private set; }

        public static void Write()
        {


            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=RSSReader.Class.DataBase;Trusted_Connection=true";

                string query = "INSERT INTO tabela1(kol 1, kol2, kol3) VALUES (czas, opis, url)";

                //user  iduser,id cat, feeds, category


            }


        }
    
        public static void ZapisTest(List<Post> wpisy)
        {

            string strCon = @"Data Source=localhost\\SQLEXPRESS;" + "Initial Catalog=RSSReader.Class.DataBase;Integrated Security=SSPI";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            try
            {
                foreach (var wpis in wpisy)
                {
                    string strSql = "INSERT INTO Feeds(Date, Title, Url) VALUES (" + wpis.PublishedDate + "," + wpis.Title + ", " + wpis.link + ")";
                    SqlCommand cmd = new SqlCommand(strSql, con);
                    DataSet dset = new DataSet();
                    cmd.ExecuteNonQuery();
                }
                //dset.ReadXml(cmd.ExecuteXmlReader(), XmlReadMode.Fragment);
                // XmlDisplay.DocumentContent = dset.GetXml();
            }
            finally
            {
                con.Close();
            }


        }

        public static void Connect()
        {
            //setup the global SqlConnection object and constr in your class
            SqlConnection con = null;
            string constr = "Integrated Security=SSPI;" +
            "Initial Catalog=RSSReader.Class.DataBase;" +
            "Data Source=localhost\\SQLEXPRESS;";

           
        }


    }




}