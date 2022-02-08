using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class ProfesorBL
    {
        ProfesorDAL profesorDAL = new ProfesorDAL();

        public List<ProfesorBE> ListaProfesor()
        {
            return profesorDAL.ListaProfesor();
        }

        public bool InsertarProfesor(ProfesorBE profesorBE)
        {
            return profesorDAL.InsertarProfesor(profesorBE);
        }

        public ProfesorBE BuscarPorID(int idProfesor)
        {
            return profesorDAL.BuscarPorID(idProfesor);
        }

        public bool ActualizarProfesor(ProfesorBE profesorBE)
        {
            return profesorDAL.ActualizarProfesor(profesorBE);
        }

        public bool EliminarProfesor(int idProfesor)
        {
            return profesorDAL.EliminarProfesor(idProfesor);
        }
    }
}
