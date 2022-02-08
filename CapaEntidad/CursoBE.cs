using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CursoBE
    {
        public int idCurso { get; set; }
        public string curso { get; set; }
        public ProfesorBE profesorBE = new ProfesorBE();
    }
}
