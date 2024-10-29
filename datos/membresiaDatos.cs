using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace datos
{
    public class membresiaDatos
    {
        public List<membresia> listar()
        {
            List<membresia>lista = new List<membresia>();
            accesoDatos datos = new accesoDatos();

            try
            {
                datos.setearConsulta("select Id, Tipo, Valor from Membresias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    membresia aux = new membresia();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Tipo = (string)datos.Lector["Tipo"];
                    aux.Valor = (int)datos.Lector["Valor"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
