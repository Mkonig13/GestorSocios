using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Net.Configuration;

namespace datos
{
    public class socioDatos
    {
        public List<socio> listar()
        {
            List<socio> lista = new List<socio>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=gestorSocios; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT s.Id AS SocioId, s.Nombre, s.Apellido, s.Documento, s.FechaNacimiento, s.Domicilio, s.TelefonoContacto, s.Email, m.Tipo AS TipoMembresia FROM Socios s JOIN Membresias m ON s.MembresiaId = m.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    socio aux = new socio();
                    aux.id = (int)lector["Id"];
                    aux.nombre = (string)lector["Nombre"];
                    aux.apellido = (string)lector["Apellido"];
                    aux.documento = (string)lector["Documento"];
                    aux.fechaNacimiento = (DateTime)lector["Fecha de nacimiento"];
                    aux.domicilio = (string)lector["Domicilio"];
                    aux.telefonoContacto = (string)lector["Contacto"];
                    aux.email = (string)lector["Email"];

                    membresia aux2 = new membresia();
                    aux2.Id = (int)lector["IdMembresia"];
                    aux2.Tipo = (string)lector["Tipo"];
                    aux2.Valor = (int)lector["Valor"];


                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public void agregar(socio nuevo)
        {
            accesoDatos datos = new accesoDatos();

            try
            {
                datos.setearConsulta("insert into Socios(Nombre, Apellido, Documento)values(@nombre, @apellido, @documento)");
                datos.setearParametro("@nombre", nuevo.nombre);
                datos.setearParametro("@apellido", nuevo.apellido);
                datos.setearParametro("@documento", nuevo.documento);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(socio soc)
        {
            accesoDatos datos = new accesoDatos();
            try
            {
                datos.setearConsulta("update Socios set nombre = @nombre, apellido = @apellido, documento = @documento where id = @id");
                datos.setearParametro("@nombre", soc.nombre);
                datos.setearParametro("@apellido", soc.apellido);
                datos.setearParametro("@documento", soc.documento);
                datos.setearParametro("@id", soc.id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
