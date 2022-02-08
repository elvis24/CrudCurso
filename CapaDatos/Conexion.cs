using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        public string CadenaConexion { get; set; }
        public Conexion()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }
    }   
}
