using Rh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class CourseController : Controller
    {
        public List<Instructor> Instructores { get; set; }

        [HttpGet]
        public ActionResult CrearCurso()
        {
            return View(Instructores);
        }

        [HttpPost]
        public ActionResult CrearCurso(
            string nombre,
            int duracion,
            int calificacion,
            string tipo,
            string clasificacion,
            string areaTematica,
            string areaAplicacion,
            string objetivo,
            string modalidad,
            string comentarios,
            int instructor
        )
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Course cur = new Course();
                cur.NOMBRE = nombre;
                cur.DURACION = duracion;
                cur.CALIFICACION_MIN = calificacion;
                cur.TIPO_CURSO = tipo;
                cur.CLASIFICACION = clasificacion;
                cur.AREA_TEMATICA = areaTematica;
                cur.AREA_APLICACION = areaAplicacion;
                cur.OBJETIVO = objetivo;
                cur.MODALIDAD = modalidad;
                cur.COMENTARIOS = comentarios;
                cur.ID_INSTRUCTOR = instructor;
                db.Course.Add(cur);
                db.SaveChanges();
                return RedirectToAction("VerCursos");
            }
        }

        [HttpGet]
        public ActionResult VerCursos()
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                var Cursos = db.Course.OrderBy(x => x.ID_CURSO).ToList();
                return View(Cursos);
            }
        }

        [HttpGet]
        public ActionResult EliminarCurso(int id)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Course cur = db.Course.Find(id);
                db.Course.Remove(cur);
                db.SaveChanges();
                return RedirectToAction("VerCursos");
            }
        }

        [HttpGet]
        public ActionResult EditarCurso(int id)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Course cur = db.Course.Find(id);
                return View(cur);
            }
        }

        [HttpPost]
        public ActionResult EditarCurso(
            int ID_CURSO,
            string nombre,
            int duracion,
            int calificacion,
            string tipo,
            string clasificacion,
            string areaTematica,
            string areaAplicacion,
            string objetivo,
            string modalidad,
            string comentarios,
            int instructor
        )
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Course cur = db.Course.Find(ID_CURSO);
                cur.NOMBRE = nombre;
                cur.DURACION = duracion;
                cur.CALIFICACION_MIN = calificacion;
                cur.TIPO_CURSO = tipo;
                cur.CLASIFICACION = clasificacion;
                cur.AREA_TEMATICA = areaTematica;
                cur.AREA_APLICACION = areaAplicacion;
                cur.OBJETIVO = objetivo;
                cur.MODALIDAD = modalidad;
                cur.COMENTARIOS = comentarios;
                cur.ID_INSTRUCTOR = instructor;
                db.SaveChanges();
                return RedirectToAction("VerCursos");
            }
        }
    }
}
