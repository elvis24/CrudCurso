using CapaEntidad;
using LogicaNegocio;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        ProfesorBL profesorBL = new ProfesorBL();

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult ListadoProfesores()
        {
            return View(profesorBL.ListaProfesor());
        }

        public ActionResult AgregarProfesor()
        {
            return View();
        }

        public ActionResult InsertarProfesor(string txtNombres, string txtApellidoP, string txtApellidoM)
        {
            ProfesorBE profesorBE = new ProfesorBE();
            profesorBE.nombres = txtNombres;
            profesorBE.apellidosPat = txtApellidoP;
            profesorBE.apellidoMat = txtApellidoM;

            string mensaje = "";

            if (profesorBL.InsertarProfesor(profesorBE) ==true)
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('PROFESOR AGREGADO');window.location.href=" +
                    "'/Profesor/ListadoProfesores';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('..ERROR PROFESOR NO AGREGADO');window.location.href=" +
                    "'/Profesor/AgregarProfesor';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EditarProfesor(int idProfesor)
        {
            return View(profesorBL.BuscarPorID(idProfesor));
        }

        public ActionResult ActualizarProfesor(int txtId,string txtNombres, string txtApellidoP, string txtApellidoM)
        {
            ProfesorBE profesorBE = new ProfesorBE();
            profesorBE.idProfesor = txtId;
            profesorBE.nombres = txtNombres;
            profesorBE.apellidosPat = txtApellidoP;
            profesorBE.apellidoMat = txtApellidoM;

            string mensaje = "";

            if (profesorBL.ActualizarProfesor(profesorBE) == true)
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('PROFESOR ACTUALIZADO');window.location.href=" +
                    "'/Profesor/ListadoProfesores';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('..ERROR PROFESOR NO ACTUALIZADO');window.location.href=" +
                    "'/Profesor/EditarProfesor';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EliminarProfesor(int idProfesor)
        {
            string mensaje = "";
            if (profesorBL.EliminarProfesor(idProfesor)==true)
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('PROFESOR Eliminado');window.location.href=" +
                    "'/Profesor/ListadoProfesores';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type ='text/javascript'>"
                    + "alert('..ERROR PROFESOR NO SE ELIMINO');window.location.href=" +
                    "'/Profesor/EditarProfesor';</script>";
            }
            return Content(mensaje);
        }
    }
}