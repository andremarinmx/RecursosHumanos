using Rh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class InstructorController : Controller
    {
        [HttpGet]
        public ActionResult CrearInstructores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearInstructores(string nombreCompleto, string compania, string stp, string tipo)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Instructor inst = new Instructor();
                inst.NOMBRE_COMPLETO = nombreCompleto;
                inst.COMPANIA = compania;
                inst.REGISTRO_STP = stp;
                inst.TIPO = tipo;
                db.Instructor.Add(inst);
                db.SaveChanges();
                return RedirectToAction("VerInstructores");
            }
        }

        [HttpGet]
        public ActionResult VerInstructores()
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                var Instructores = db.Instructor.OrderBy(x => x.ID_INSTRUCTOR).ToList();
                return View(Instructores);
            }
        }

        [HttpGet]
        public ActionResult EliminarInstructor(int id)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Instructor inst = db.Instructor.Find(id);
                db.Instructor.Remove(inst);
                db.SaveChanges();
                return RedirectToAction("VerInstructores");
            }
        }

        [HttpGet]
        public ActionResult EditarInstructor(int id)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Instructor inst = db.Instructor.Find(id);
                return View(inst);
            }
        }

        [HttpPost]
        public ActionResult EditarInstructor(int ID_INSTRUCTOR, string nombreCompleto, string compania, string stp, string tipo)
        {
            using (RecursosHumanosContext db = new RecursosHumanosContext())
            {
                Instructor insta = db.Instructor.Find(ID_INSTRUCTOR);
                insta.NOMBRE_COMPLETO = nombreCompleto;
                insta.COMPANIA = compania;
                insta.REGISTRO_STP = stp;
                insta.TIPO = tipo;
                db.SaveChanges();
                return RedirectToAction("VerInstructores");
            }
        }

    }
}