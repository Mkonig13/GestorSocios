using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace datos
{
    public class loginDatos
    {
        public bool login(string user, string pass)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=gestorSocios; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select * from Users where loginName = @user and Password = @pass";
                comando.Parameters.AddWithValue("@user", user);
                comando.Parameters.AddWithValue("@pass", pass);
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    return true;    
                }else
                    return false;


            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}
