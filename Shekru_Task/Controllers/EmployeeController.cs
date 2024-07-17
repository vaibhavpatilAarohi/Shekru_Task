using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shekru_Task.Models;

namespace Shekru_Task.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVC_ShekruContext _context;
      

        public EmployeeController(MVC_ShekruContext context)
        {
            _context = context;
           
        }

        public IActionResult Create()
        {
            ViewBag.DesignationrefList = new SelectList(_context.Designations.Where(e => e.IsActive == true), "Did", "Designationname");
            ViewBag.DesignationgradeList = new SelectList(_context.DesignationGrades.Where(e => e.IsActive == true), "Dgid", "Gradename");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            ViewBag.DesignationrefList = new SelectList(_context.Designations.Where(e => e.IsActive == true), "Did", "Designationname");
            ViewBag.DesignationgradeList = new SelectList(_context.DesignationGrades.Where(e => e.IsActive == true), "Dgid", "Gradename");
            _context.Employees.Add(e);
            _context.SaveChanges();
            TempData["success"] = "Employee Added  Successfully";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.DesignationrefList = new SelectList(_context.Designations.Where(e => e.IsActive == true), "DID", "Designationname");
            ViewBag.DesignationgradeList = new SelectList(_context.DesignationGrades.Where(e => e.IsActive == true), "DGId", "Gradename");
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Employees.FindAsync(id);
           
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Employee e)
        {
            ViewBag.DesignationrefList = new SelectList(_context.Designations.Where(e => e.IsActive == true), "DID", "Designationname");
            ViewBag.DesignationgradeList = new SelectList(_context.DesignationGrades.Where(e => e.IsActive == true), "DGId", "Gradename");

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the existing TrainerTimeTable entry
                    _context.Update(e);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
           
            return View(e);
        }

        public IActionResult Index()
        {

            var shekru = _context.Employees.ToList();
            return View(shekru);
        }
    }
}
