using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace LogicaNegocio
{
    public class CursoBL
    {
        CursoDAL cursoDAL = new CursoDAL();

        public List<CursoBE> ListarCurso()
        {
            return cursoDAL.ListarCurso();
        }

        public bool InsertarCurso(CursoBE cursoBE)
        {
            return cursoDAL.InsertarCurso(cursoBE);
        }

        public bool AcutalizarCurso(CursoBE cursoBE)
        {
            return cursoDAL.AcutalizarCurso(cursoBE);
        }

        public CursoBE BuscarPorId(int idCurso)
        {
            return cursoDAL.BuscarPorId(idCurso);
        }

        public bool EliminarCurso(int idCurso)
        {
            return cursoDAL.EliminarCurso(idCurso);
        }
    }
}
