using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practical_13.Data;
using Practical_13.Models;

namespace Practical_13.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AuthDbContext _context;

        public EmployeeController(AuthDbContext context)
        {
            _context = context;
        }
        public IActionResult GetEmployeeCountByDesignation()
        {
            try
            {
                var employeeCountByDesignation = _context.Employees;
                return Json(employeeCountByDesignation);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            try
            {
                var authDbContext = _context.Employees.Include(e => e.DesignationDetail);
                return View(await authDbContext.ToListAsync());
            }
            catch(Exception ex)
            {                
                return Content(ex.Message);
            }
        }
        public IActionResult GetCount()
        {
            try
            {
                var result = from dept in _context.Designations
                             join emp in _context.Employees on dept.Id equals emp.DesignationId into empGroup
                             select new
                             {
                                 DepartmentName = dept.Designation,
                                 TotalEmployees = empGroup.Count()
                             };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var employee = await _context.Employees.Include(e => e.DesignationDetail).FirstOrDefaultAsync(m => m.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Designation");
                return View();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: Employee/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,DOB,MobileNumber,Address,Salary,DesignationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Designation");
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception ex)
                {
                return Content(ex.Message);
            }
        }

        // POST: Employee/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,DOB,MobileNumber,Address,Salary,DesignationId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }       
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
