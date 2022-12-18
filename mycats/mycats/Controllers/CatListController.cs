using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mycats.Controllers
{
    public class CatListController : Controller
    {
        catsContext dc = new catsContext(); //database connection
        // GET: CatList
        public ActionResult Index() //Show tables in index pages
        {
            var catlist = dc.listofcats.ToList();
            return View(catlist);
        }

        // GET: CatList/Details/5
        public ActionResult Details(int id) //Show Details of Data
        {
            var det_catlist = dc.listofcats.Where(cat => cat.id == id).FirstOrDefault();
            return View(det_catlist);
        }

        // GET: CatList/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatList/Create
        [HttpPost]
        public ActionResult Create(listofcat cats) //Inset into Database
        {
            dc.listofcats.Add(cats);
            dc.SaveChanges();
            ViewBag.Message = "Succsess!";
            return View();
        }

        // GET: CatList/Edit/5
        [HttpGet]
        public ActionResult Edit(int id) //Edit Get and Showing Data from Database
        {
            var edit_catlist = dc.listofcats.Where(cat => cat.id == id).FirstOrDefault();
            return View(edit_catlist);
        }

        // POST: CatList/Edit/5
        [HttpPost]
        public ActionResult Edit(listofcat cats) //Edit Data base on selected ID
        {
            var edit_catlist = dc.listofcats.Where(cat => cat.id == cats.id).FirstOrDefault();
            if (edit_catlist != null)
            {
                edit_catlist.id = cats.id;
                edit_catlist.Name = cats.Name;
                edit_catlist.Gender = cats.Gender;
                edit_catlist.Type = cats.Type;
                edit_catlist.Colour = cats.Colour;
                edit_catlist.Food = cats.Food;
                dc.SaveChanges();
            }
            return RedirectToAction("index");
        }

        // GET: CatList/Delete/5

        // POST: CatList/Delete/5
        public ActionResult Delete(int id) //Remove data base on ID
        {
            var del_catlist = dc.listofcats.Where(cat => cat.id == id).FirstOrDefault();
            dc.listofcats.Remove(del_catlist);
            dc.SaveChanges();
            ViewBag.Message = "Succsess!";
            return RedirectToAction("index");
        }
    }
}
