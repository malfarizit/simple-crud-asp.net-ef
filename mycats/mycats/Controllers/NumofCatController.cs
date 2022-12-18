using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mycats.Controllers
{
    public class NumofCatController : Controller
    {
        catsContext dc = new catsContext(); //database connection
        CatListController fc = new CatListController();
        // GET: CatList
        public ActionResult Index() //Show tables in index pages (Method/Function)
        {
            var numcats = dc.numberofcats.ToList();
            //var tambah = fc.tambahan();
            return View(numcats);
            //fc.tambahan();
        }

        // GET: CatList/Details/5
        public ActionResult Details(int id) //Show Details of Data
        {
            var detail_numcats = dc.numberofcats.Where(x => x.id == id).FirstOrDefault();
            return View(detail_numcats);
        }

        // GET: CatList/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatList/Create
        [HttpPost]
        public ActionResult Create(numberofcat cat) //Inset into Database
        {
            dc.numberofcats.Add(cat);
            dc.SaveChanges();
            ViewBag.Message = "Succsess!";
            return View();
        }

        // GET: CatList/Edit/5
        [HttpGet]
        public ActionResult Edit(int id) //Edit Get and Showing Data from Database
        {
            var edit_numcats = dc.numberofcats.Where(cat => cat.id == id).FirstOrDefault();
            return View(edit_numcats);
        }

        // POST: CatList/Edit/5
        [HttpPost]
        public ActionResult Edit(numberofcat cat) //Edit Data base on selected ID
        {
            var edit_numcats = dc.numberofcats.Where(x => x.id == cat.id).FirstOrDefault();
            if (edit_numcats != null)
            {
                edit_numcats.id = cat.id;
                edit_numcats.Type = cat.Type;
                edit_numcats.Gender = cat.Gender;
                edit_numcats.Number_of_cats = cat.Number_of_cats;
                dc.SaveChanges();
            }
            return RedirectToAction("index");
        }

        // GET: CatList/Delete/5

        // POST: CatList/Delete/5
        public ActionResult Delete(int id)
        {
            var del_numcats = dc.numberofcats.Where(cat => cat.id == id).FirstOrDefault();
            dc.numberofcats.Remove(del_numcats);
            dc.SaveChanges();
            ViewBag.Message = "Succsess!";
            return RedirectToAction("index");
        }
    }
}
