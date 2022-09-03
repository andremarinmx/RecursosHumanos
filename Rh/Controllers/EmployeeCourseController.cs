using Rh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class EmployeeCourseController : Controller
    {
        List<Employee_Course> Induccion = new List<Employee_Course>
    {
            new Employee_Course{ ID_CURSO = 3, CALIFICACION = 100},
            new Employee_Course{ ID_CURSO = 4, CALIFICACION = 100},
            new Employee_Course{ ID_CURSO = 5, CALIFICACION = 100},
            new Employee_Course{ ID_CURSO = 6, CALIFICACION = 100},
    };

        List<Employee_Course> Calidad = new List<Employee_Course>
    {
            new Employee_Course{ ID_CURSO = 1, CALIFICACION = 100},
            new Employee_Course{ ID_CURSO = 2, CALIFICACION = 100},
            new Employee_Course{ ID_CURSO = 8, CALIFICACION = 100},
            new Employee_Course{ ID_CURSO = 9, CALIFICACION = 100},
    };

        [HttpGet]
        public ActionResult AsignarCursos()
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AsignarCursos(int? idCurso, int numReloj, string nombrePaquete)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Employee_Course empCur = new Employee_Course();
                var empleado = db.Employee.Where(x => x.EmployeeID == numReloj).ToList();
                DateTime now = DateTime.Now;

                if (idCurso == null)
                {
                    switch (nombrePaquete)
                    {
                        case "Induccion":
                            foreach (var item in Induccion)
                            {
                                empCur.ID_CURSO = item.ID_CURSO;
                                empCur.CALIFICACION = item.CALIFICACION;
                                empCur.ID_EMPLEADO = empleado[0].ID;
                                empCur.FECHA = now;
                                db.Employee_Course.Add(empCur);
                                db.SaveChanges();
                            }
                            break;
                        case "Calidad":
                            foreach (var item in Calidad)
                            {
                                empCur.ID_CURSO = item.ID_CURSO;
                                empCur.CALIFICACION = item.CALIFICACION;
                                empCur.ID_EMPLEADO = empleado[0].ID;
                                empCur.FECHA = now;
                                db.Employee_Course.Add(empCur);
                                db.SaveChanges();
                            }
                            break;
                        default:
                            //curso inexistente
                            break;
                    }
                }
                else
                {
                    empCur.ID_CURSO = idCurso;
                    empCur.ID_EMPLEADO = empleado[0].ID;
                    empCur.FECHA = now;
                    db.Employee_Course.Add(empCur);
                    db.SaveChanges();
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult BuscarCursosEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerCursosEmpleado(int numReloj)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                var empleado = db.Employee.Where(x => x.EmployeeID == numReloj).ToList();
                var idEmpleado = empleado[0].ID;
                var empleado_curso = db.Employee_Course.Where(x => x.ID_EMPLEADO == idEmpleado).ToList();
                return View(empleado_curso);
            }
        }

        [HttpGet]
        public ActionResult EliminarCursoEmpleado(int id)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Employee_Course empCur = db.Employee_Course.Find(id);
                db.Employee_Course.Remove(empCur);
                db.SaveChanges();
                return RedirectToAction("BuscarCursosEmpleado");
            }
        }

        [HttpGet]
        public ActionResult Calificaciones()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AsignarCalificacion(int id)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Employee_Course empCur = db.Employee_Course.Find(id);
                db.SaveChanges();
                return View(empCur);
            }
        }

        [HttpPost]
        public ActionResult AsignarCalificacion(Employee_Course x)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Employee_Course empCurso = db.Employee_Course.Find(x.ID_EMPLEADO_CURSO);
                empCurso.CALIFICACION = x.CALIFICACION;
                db.SaveChanges();
                return RedirectToAction("BuscarCursosEmpleado");
            }
        }
    }
}