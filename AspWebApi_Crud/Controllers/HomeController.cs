using AspWebApi_Crud.Models;
using AspWebApi_Crud.Web_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspWebApi_Crud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            web_api_crud_dbEntities obj = new web_api_crud_dbEntities();
            List<ModelClass> Mobj = new List<ModelClass>();
            var x = obj.Employees.ToList();
            foreach (var item in x)
            {
                Mobj.Add(new ModelClass
                {
                    Id =item.Id,
                    Name = item.Name,
                    Age= item.Age,
                    Salary = item.Salary,
                    Designation = item.Designation,
                    Gender= item.Gender
                });
            }
            return View(Mobj);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        } 
        [HttpPost]
        public ActionResult AddEmployee(ModelClass Mobj)
        {
            web_api_crud_dbEntities obj = new web_api_crud_dbEntities();
            Employee tbl = new Employee();
            tbl.Id = Mobj.Id;
            tbl.Age = Mobj.Age;
            tbl.Name = Mobj.Name;
            tbl.Salary = Mobj.Salary;
            tbl.Gender = Mobj.Gender;
            tbl.Designation = Mobj.Designation;
            if (Mobj.Id == 0)
            {
                obj.Employees.Add(tbl);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
            }
            //return View(tblobj);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int Id)
        {
            web_api_crud_dbEntities obj = new web_api_crud_dbEntities();
            ModelClass Mobj = new ModelClass();
            var Edititem = obj.Employees.Where(b => b.Id == Id).First();
            Mobj.Id = Edititem.Id;
            Mobj.Age = Edititem.Age;
            Mobj.Name= Edititem.Name;
            Mobj.Salary = Edititem.Salary;
            Mobj.Designation = Edititem.Designation;
            Mobj.Gender = Edititem.Gender;
            ViewBag.Id = Edititem.Id;

            return View("AddEmployee", Mobj);
        }
        public ActionResult Delete(int Id)
        {
            web_api_crud_dbEntities obj = new web_api_crud_dbEntities();
            var del = obj.Employees.Where(m => m.Id == Id).First();
            obj.Employees.Remove(del);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}