using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace QLbanhang
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        SqlConnection conn;
        SqlCommand cmd;

        // Đổi tên kết nối data source service , function
        string connectionString = "Data Source=KhiemBi\\SQLEXPRESS;Initial Catalog=qlbanhang;Integrated Security=True";
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
        public int InsertChatLieu(ChatLieu c)
        {
            try
            {
                cmd.CommandText = "INSERT INTO tblChatLieu VALUES (@MaChatLieu, @TenChatLieu)";
                cmd.Parameters.AddWithValue("@MaChatLieu", c.MaChatLieu);
                cmd.Parameters.AddWithValue("@TenChatLieu", c.TenChatLieu);
                
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
        public int UpdateChatLieu(ChatLieu c)
        {
            try
            {
                cmd.CommandText = "UPDATE tblChatLieu SET TenChatLieu=@TenChatLieu WHERE MaChatLieu=@MaChatLieu";
                cmd.Parameters.AddWithValue("@MaChatLieu", c.MaChatLieu);
                cmd.Parameters.AddWithValue("@TenChatLieu", c.TenChatLieu);
                
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
        public int DelChatLieu(ChatLieu c)
        {
            try
            {
                cmd.CommandText = "DELETE FROM tblChatLieu WHERE MaChatLieu=@MaChatLieu";
                cmd.Parameters.AddWithValue("@MaChatLieu", c.MaChatLieu);
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
        public List<ChatLieu> GetAll()
        {
            List<ChatLieu> chatlieuList = new List<ChatLieu>();
            try
            {
                cmd.CommandText = "SELECT * FROM tblChatLieu";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ChatLieu chatlieu = new ChatLieu()
                    {
                        MaChatLieu = dr["MaChatLieu"].ToString(),
                        TenChatLieu = dr["TenCHatLieu"].ToString()
                        
                    };
                    chatlieuList.Add(chatlieu);
                }

                // Sắp xếp danh sách theo Id, Name, Age
                chatlieuList = chatlieuList.OrderBy(t => t.MaChatLieu)
                                       .ThenBy(t => t.TenChatLieu)
                                       
                                       .ToList();

                return chatlieuList;
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

        public ChatLieu GetChatLieu(ChatLieu c)
        {
            ChatLieu chatlieu = new ChatLieu();
            try
            {
                cmd.CommandText = "SELECT * FROM tblChatLieu WHERE MaChatLieu = @MaChatLieu OR TenChatLieu = @TenChatLieu";
                cmd.Parameters.AddWithValue("@MaChatLieu", c.MaChatLieu);
                cmd.Parameters.AddWithValue("@TenChatLieu", c.TenChatLieu);
                

                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    chatlieu.MaChatLieu = dr["MaChatLieu"].ToString();
                    chatlieu.TenChatLieu = dr["TenChatLieu"].ToString();
                   
                }
                return chatlieu;
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
        public string CheckDup(ChatLieu c)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(MaChatLieu) FROM tblChatLieu WHERE MaChatLieu=@MaChatLieu";
                cmd.Parameters.AddWithValue("@MaChatLieu", c.MaChatLieu);
                conn.Open();
                return cmd.ExecuteScalar().ToString();
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
        internal class Functionss
        {

        }
    }
}
