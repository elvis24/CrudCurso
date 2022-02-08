using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaNegocio;
using CapaEntidad;
namespace Presentacion.Controllers
{
    public class CursoController : Controller
    {
        CursoBL cursoBL = new CursoBL();

        // GET: Curso
        public ActionResult ListadoCursos()
        {
            return View(cursoBL.ListarCurso());
        }

        public ActionResult InsertarCurso()
        {
            List<ProfesorBE> lstProfesores = new List<ProfesorBE>();
            ProfesorBL profesorBL = new ProfesorBL();

            lstProfesores = profesorBL.ListaProfesor();
            ViewBag.ListadoProfesores = lstProfesores;
            return View();
        }

        public ActionResult AgregarCurso(string txtCurso, int cboProfesor)
        {
            CursoBE cursoBE = new CursoBE();
            cursoBE.curso = txtCurso;
            cursoBE.profesorBE.idProfesor = cboProfesor;

            string mensaje = "";
            if (cursoBL.InsertarCurso(cursoBE) == true)
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('CURSO FUE AGREGADO');window.location.href=" +
                    "'/Curso/ListadoCursos';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('..ERROR CURSO NO AGREGADO');window.location.href=" +
                    "'/Curso/InsertarCurso';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EditarCurso(int idCurso)
        {
            List<ProfesorBE> lstProfesores = new List<ProfesorBE>();
            ProfesorBL profesorBL = new ProfesorBL();

            lstProfesores = profesorBL.ListaProfesor();
            ViewBag.ListadoProfesores = lstProfesores;

            return View(cursoBL.BuscarPorId(idCurso));
        }

        public ActionResult ActualizarCurso(int txtIdCurso, string txtCurso, int cboProfesor)
        {
            CursoBE cursoBE = new CursoBE();
            cursoBE.idCurso = txtIdCurso;
            cursoBE.curso = txtCurso;
            cursoBE.profesorBE.idProfesor = cboProfesor;

            string mensaje = "";

            if (cursoBL.AcutalizarCurso(cursoBE) == true)
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('..CURSO FUE ACTUALIZO');window.location.href=" +
                    "'/Curso/ListadoCursos';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('..ERROR CURSO NO SE ACTUALIZO');window.location.href=" +
                    "'/Curso/EditarCurso';</script>";

            }
            return Content(mensaje);
        }

        public ActionResult EliminarCurso(int  idCurso)
        {
            string mensaje = "";

            if (cursoBL.EliminarCurso(idCurso) ==true)
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('..CURSO FUE Eliminado');window.location.href=" +
                    "'/Curso/ListadoCursos';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('..ERROR CURSO NO SE Elimino');window.location.href=" +
                    "'/Curso/ListadoCursos';</script>";
            }

            return Content(mensaje);
        }
    }
}