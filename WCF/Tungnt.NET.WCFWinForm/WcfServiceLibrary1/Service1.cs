using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        SqlConnection conn;
        SqlCommand cmd;

        // Connection string for your database
        string connectionString = "Data Source=DESKTOP-JRD3VOD\\SQLEXPRESS;Initial Catalog=TOSHIBA.WCF;Integrated Security=True";
        public Service1()
        {
            ConnectToDb();
        }

        void ConnectToDb()
        {
            conn = new SqlConnection(connectionString);
            cmd = conn.CreateCommand();
        }

        // Define the method to insert a person
        public int InsertPerson(Person p)
        {
            try
            {
                cmd.CommandText = "INSERT INTO t_person VALUES (@Id, @Name, @Age)";
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Age", p.Age);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex; // Throw the actual exception for better error handling
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        // Implementing the GetDataUsingDataContract method
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException(nameof(composite));
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        // Implementing the GetData method
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public int UpdatePerson(Person p)
        {
            try
            {
                cmd.CommandText = "UPDATE t_person SET Name=@Name, Age=@Age WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Age", p.Age);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

    }
}
