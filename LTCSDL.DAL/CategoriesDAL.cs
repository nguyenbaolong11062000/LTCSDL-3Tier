using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using LTCSDL.DAL.DTO;

namespace LTCSDL.DAL
{
    public class CategoriesDAL
    {
        SqlConnection cnn;

        public CategoriesDAL()
        {
            string cnstr = "Server = localhost; Database = Northwind; Integrated Security = true;";
            this.cnn = new SqlConnection(cnstr);
        }

        public int insert(string name, string description)
        {
            int res =0;
            //string sql = "Insert Into Categories(CategoryName, [Description])";
            //sql = sql + " Values('"+ name + "', '"+ description + "')";
            StringBuilder sb = new StringBuilder("Insert Into Categories(CategoryName, [Description]) ");
            sb.AppendFormat("Values('{0}', '{1}');", name, description);
            sb.Append("SELECT @@IDENTITY as [CateID]");
            try
            {
                if(cnn.State == ConnectionState.Closed)
                    cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sb.ToString();

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {                    
                    res = int.Parse(sdr["CateID"].ToString());
                }                
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return res;
        }        

        public CategoriesDTO getCategoryById(int id, out string msg)
        {
            msg = "";
            CategoriesDTO res = new CategoriesDTO();
            StringBuilder sb = new StringBuilder("SELECT * FROM Categories ");
            sb.AppendFormat("WHERE CategoryID={0}", id.ToString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sb.ToString();
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    res.CategoryID = int.Parse(sdr["CategoryID"].ToString());
                    res.CategoryName = sdr["CategoryName"].ToString();
                    res.Description = sdr["Description"].ToString();
                }
                cnn.Close();                
            }
            catch (SqlException ex)
            {
                msg = "OOPs, something went wrong.\n" + ex.Message;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return res;
        }

        public void update(string name, string description)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendFormat("update Categories set CategoryName = '{0}', [Description] = '{1}' where CategoryID = 8", name, description);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sb.ToString();

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex.Message);
                cnn.Close();
            }
            

        }

        public void delete(int CateID)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendFormat("delete from Categories where CategoryID = {0}", CateID);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sb.ToString();

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex.Message);
                cnn.Close();
            }
        }

        public List<CategoriesDTO> getCategories()
        {
            List<CategoriesDTO> res = new List<CategoriesDTO>();
            
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("SELECT * FROM Categories ");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sb.ToString();
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    res.Add(new CategoriesDTO
                    {
                        CategoryID = int.Parse(sdr["CategoryID"].ToString()),
                        CategoryName = sdr["CategoryName"].ToString(),
                        Description = sdr["Description"].ToString()
                    }
                    );
                    
                }
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return res;
        }
    }
}
