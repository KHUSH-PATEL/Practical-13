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
    public class DesignationDetailController : Controller
    {
        private readonly AuthDbContext _context;

        public DesignationDetailController(AuthDbContext context)
        {
            _context = context;
        }

        // GET: DesignationDetail
        public async Task<IActionResult> Index()
        {
              return _context.Designations != null ? 
                          View(await _context.Designations.ToListAsync()) :
                          Problem("Entity set 'AuthDbContext.Designations'  is null.");
        }

        // GET: DesignationDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Designations == null)
            {
                return NotFound();
            }

            var designationDetail = await _context.Designations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designationDetail == null)
            {
                return NotFound();
            }

            return View(designationDetail);
        }

        // GET: DesignationDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DesignationDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Designation")] DesignationDetail designationDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designationDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(designationDetail);
        }

        // GET: DesignationDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Designations == null)
            {
                return NotFound();
            }

            var designationDetail = await _context.Designations.FindAsync(id);
            if (designationDetail == null)
            {
                return NotFound();
            }
            return View(designationDetail);
        }

        // POST: DesignationDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Designation")] DesignationDetail designationDetail)
        {
            if (id != designationDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designationDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignationDetailExists(designationDetail.Id))
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
            return View(designationDetail);
        }

        // GET: DesignationDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Designations == null)
            {
                return NotFound();
            }

            var designationDetail = await _context.Designations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designationDetail == null)
            {
                return NotFound();
            }

            return View(designationDetail);
        }

        // POST: DesignationDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Designations == null)
            {
                return Problem("Entity set 'AuthDbContext.Designations'  is null.");
            }
            var designationDetail = await _context.Designations.FindAsync(id);
            if (designationDetail != null)
            {
                _context.Designations.Remove(designationDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignationDetailExists(int id)
        {
          return (_context.Designations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
