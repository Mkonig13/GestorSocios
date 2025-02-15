using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using datos.mailServices;



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
                comando.CommandText = "select * from users where LoginName = @user and Password = @pass";
                comando.Parameters.AddWithValue("@user", user);
                comando.Parameters.AddWithValue("@pass", pass);
                comando.Connection = conexion;
                

                conexion.Open();
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        UserCache.Id = lector.GetInt32(0);
                        UserCache.LoginName = lector.GetString(1);
                        UserCache.Password = lector.GetString(2);
                        UserCache.FirstName = lector.GetString(3);
                        UserCache.LastName = lector.GetString(4);
                        UserCache.Email = lector.GetString(5);
                    }

                    return true;    
                }else
                    return false;


            }
            catch (Exception ex)
            {
                throw ex;  
            }
            finally
            {
                conexion.Close();
            }
        }

        public string recoverPassword(string userRequest)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=gestorSocios; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select * from users where LoginName = @user or Email = @mail";
                comando.Parameters.AddWithValue("@user", userRequest);
                comando.Parameters.AddWithValue("@mail", userRequest);
                comando.Connection = conexion;


                conexion.Open();
                lector = comando.ExecuteReader();

                if(lector.Read() == true)
                {
                    string userName = lector.GetString(3) + ", " + lector.GetString(4);
                    string userMail = lector.GetString(5);
                    string userPass = lector.GetString(2);

                    var servicioCorreo = new support();
                    servicioCorreo.sendMail(
                        subject: "Recuperación de contraseña",
                        body: "Hola " + userName + "\nTu peticion de recuperacion de contraseña.\n" +
                        "Tu contraseña es: " + userPass +
                        "\nSin embargo, le pedimos que cambie su contraseña una vez que entre al sistema.",
                        to: new List<string> { userMail }
                        );
                    return "Hola " + userName + "\nTu peticion de recuperacion de contraseña fue enviada.\n" +
                        "Revise su correo electronico: " + userMail +
                        "\nSin embargo, le pedimos que cambie su contraseña una vez que entre al sistema.";
                }
                else
                {
                    return "No se encontro el usuario";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public string editProfile(int id, string userName, string password, string name, string lastName,string mail)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=gestorSocios; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "update users set LoginName = @userName, Password = @pass, FirstName = @name, LastName = @lastName, Email = @mail where Id = @id";
                comando.Parameters.AddWithValue("@userName", userName);
                comando.Parameters.AddWithValue("@pass",password);
                comando.Parameters.AddWithValue("@name", name);
                comando.Parameters.AddWithValue("@lastName", lastName);
                comando.Parameters.AddWithValue("@mail", mail);
                comando.Parameters.AddWithValue("@id", id);
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                
                try
                {
                    login(userName, password);
                    return "Datos actualizados correctamente";
                }
                catch (Exception)
                {

                    return "El nombre de usuario ya esta siendo utilizado, por favor elija otro";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


    }
}
