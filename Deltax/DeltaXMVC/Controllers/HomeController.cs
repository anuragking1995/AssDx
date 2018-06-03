using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeltaXMVC.Repository;
using Deltax;
using AutoMapper;

namespace DeltaXMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var dal = new Deltax.DeltaXRepository();
            var list = dal.GetMoviesUsingLinq();
            var modelList = new List<Models.Movie>();
            foreach(var i in list)
            {
                modelList.Add(Mapper.Map<Models.Movie>(i));
            }
            

            return View(modelList);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Edit(Models.Movie obj)
        {
            return View("Edit",obj);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult EditPost(Models.Movie obj)
        {
            try
            {
                // TODO: Add update logic here
                var dal = new Deltax.DeltaXRepository();
                var dalObj = Mapper.Map<Movie>(obj);
                if (dal.updateMovies(dalObj))
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    return View("Error");
                }
            }

            catch
            {
                return View("Error");
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult AjaxMethodGetProducers()
        {
            DeltaXRepository obj = new DeltaXRepository();
            List<string> names = new List<string>();
            try
            {
                names = obj.GetProducerNames();
            }
            catch
            {
                names = null;
            }
            return Json(names,JsonRequestBehavior.AllowGet);
        }
        public JsonResult AjaxMethodGetActors()
        {
            DeltaXRepository obj = new DeltaXRepository();
            List<string> names = new List<string>();
            try
            {
                names = obj.GetActorNames();
            }
            catch
            {
                names = null;
            }
            return Json(names, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AjaxMethodAddProducers(string name,string sex,string dob,string bio)
        {
            DeltaXRepository obj = new DeltaXRepository();
            try
            {
                if (obj.AddProducer(name, sex, dob, bio))
                {
                    return Json("Data is successfully added");
                }
                else
                {
                    return Json("Errror in adding Data");
                }

            }
            catch
            {
                return Json("Errror in adding Data");
            }

        }
        public JsonResult AjaxMethodAddActors(string name, string sex, string dob, string bio)
        {
            DeltaXRepository obj = new DeltaXRepository();
            try
            {
                if (obj.AddActor(name, sex, dob, bio))
                {
                    return Json("Data is successfully added");
                }
                else
                {
                    return Json("Errror in adding Data");
                }

            }
            catch
            {
                return Json("Errror in adding Data");
            }

        }
        public JsonResult AjaxMethodAddMovies(string name, string yearOfRelease, string Plot, string producer, string[] actors)
        {
            DeltaXRepository obj = new DeltaXRepository();
            try
            {
                if (obj.AddMovie(name, yearOfRelease, Plot, producer, actors))
                {
                    return Json("Movie Added succesfully");
                }
                else
                {
                    return Json("Errror in adding Data");
                }

            }
            catch
            {
                return Json("Errror in adding Data");
            }

        }

    }
}
