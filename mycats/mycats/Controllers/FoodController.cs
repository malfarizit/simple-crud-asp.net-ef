using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mycats.Controllers
{
    public class FoodController : Controller
    {
        catsContext dc = new catsContext(); //database connection
        // GET: CatList
        public ActionResult Index() //Show tables in index pages
        {
            //var foodamount = dc.amountofFoods.ToList();
            //return View(foodamount);
            var foodamoun = from food in dc.amountofFoods
                            select food;
            var foodamount = dc.amountofFoods.OrderByDescending(food => food.Amount);
            return View(foodamount);

        }

        // GET: CatList/Details/5
        public ActionResult Details(int id) //Show Details of Data
        {
            var det_foodamount = dc.amountofFoods.Where(food => food.id == id).FirstOrDefault();
            return View(det_foodamount);
        }

        public ActionResult orderamount() //Order data base on highest amount foods
        {
            var order_foodamoun = from food in dc.amountofFoods
                           select food;
            var order_foodamount = dc.amountofFoods.OrderByDescending(food => food.Amount);
            return View(order_foodamount);
        }

        // GET: CatList/Create
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        // POST: CatList/Create
        [HttpPost]
        public ActionResult Create(amountofFood Foods) //Inset into Database
        {
            dc.amountofFoods.Add(Foods);
            dc.SaveChanges();
            ViewBag.Message = "Succsess!";
            return View();
        }

        // GET: CatList/Edit/5
        [HttpGet]
        public ActionResult Edit(int id) //Edit Get and Showing Data from Database
        {
            var edit_foodamount = dc.amountofFoods.Where(food => food.id == id).FirstOrDefault();
            return View(edit_foodamount);
        }

        // POST: CatList/Edit/5
        [HttpPost]
        public ActionResult Edit(amountofFood Foods) //Edit Data base on selected ID
        {
            var edit_foodamount = dc.amountofFoods.Where(food => food.id == Foods.id).FirstOrDefault();
            if (edit_foodamount != null)
            {
                edit_foodamount.id = Foods.id;
                edit_foodamount.Type = Foods.Type;
                edit_foodamount.Food = Foods.Food;
                edit_foodamount.Amount = Foods.Amount;
                dc.SaveChanges();
            }
            return RedirectToAction("index");
        }
        // POST: CatList/Delete/5
        public ActionResult Delete(int id)
        {
            var del_foodamount = dc.amountofFoods.Where(food => food.id == id).FirstOrDefault();
            dc.amountofFoods.Remove(del_foodamount);
            dc.SaveChanges();
            ViewBag.Message = "Succsess!";
            return RedirectToAction("index");
        }
    }
}
