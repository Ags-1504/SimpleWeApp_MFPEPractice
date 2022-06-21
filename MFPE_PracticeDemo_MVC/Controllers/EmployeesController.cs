using MFPE_PracticeDemo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MFPE_PracticeDemo_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> empList;
            HttpResponseMessage response = Globals.WebApiClient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync < IEnumerable<mvcEmployeeModel>>().Result;
            return View(empList);
        }

        
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new mvcEmployeeModel());
            }
            else
            {
                HttpResponseMessage response = Globals.WebApiClient.GetAsync("Employees/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }
            
        }

        //POST: Employees
        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel emp)
        {
            if(emp.EmployeeID == 0)
            {
                HttpResponseMessage response = Globals.WebApiClient.PostAsJsonAsync("Employees", emp).Result;

                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = Globals.WebApiClient.PutAsJsonAsync("Employees/"+emp.EmployeeID, emp).Result;

                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Globals.WebApiClient.DeleteAsync("Employees/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}