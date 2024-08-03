using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UjalaCityNews1.Models;

namespace UjalaCityNews1.DAL
{
    public class CommonDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public void AddPerson(ContactUs contact)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Proc_AddContactUs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Subject", contact.Subject);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}