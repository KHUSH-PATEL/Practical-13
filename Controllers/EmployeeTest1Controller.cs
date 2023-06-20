using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical_13.Models;
using Practical_13.Services.Interface;

namespace Practical_13.Controllers
{
    public class EmployeeTest1Controller : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeTest1Controller(IEmployee employee)
        {
            this._employee = employee;
        }
        // GET: EmployeeTest1Controller
        public ActionResult Index()
        {
            try
            {
                var data = _employee.GetEmployees().ToList();
                return View(data);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }            
        }

        // GET: EmployeeTest1Controller/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var data = _employee.GetSingleEmployee(id);
                return View(data);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: EmployeeTest1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTest1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, EmployeeTest1 employeeData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employee.AddOrUpdateEmployee(id, employeeData);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            return View();
        }

        // GET: EmployeeTest1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            var data = _employee.GetSingleEmployee(id);
            return View(data);
        }

        // POST: EmployeeTest1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeTest1 employeeData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employee.AddOrUpdateEmployee(id, employeeData);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            return View();
        }        

        // GET: EmployeeTest1Controller/Delete/5        
        public ActionResult Delete(int id)
        {
            try
            {
                var employee = _employee.GetSingleEmployee(id);
                if (employee != null)
                {
                    _employee.RemoveEmployee(employee.Id);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
