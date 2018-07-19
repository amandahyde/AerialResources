using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AerialResources.Data;
using AerialResources.Models;
using AerialResources.DTO;
using AerialResources.Operations;

namespace AerialResources.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly AerialResourcesContext _context;

        public StudentCoursesController(AerialResourcesContext context)
        {
            _context = context;
        }

        // GET: StudentCourses
        public async Task<IActionResult> Index()
        {

            return View(await _context.StudentCourse.ToListAsync());
        }

        // GET: StudentCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student  = await _context.Student
                .SingleOrDefaultAsync(m => m.StudentID == id);

            var course = await _context.Course
               .SingleOrDefaultAsync(m => m.CourseID == id);

            GetAllCourses mygetallcourses = new GetAllCourses();
            myCourses myCourses = new myCourses();
            myStudents myStudents = new myStudents();



            DatabaseManager.StudentID = student.StudentID;
            DatabaseManager.CourseID = course.CourseID;

            myStudents.StudentID = student.StudentID;
            myCourses.CourseID = course.CourseID;

            var allStudents = _context.Student.ToList();
            mygetallcourses.students = allStudents;

            var allCourses = _context.Course.ToList();
            mygetallcourses.courses = allCourses;

            return View(mygetallcourses);

           
        }

        // GET: StudentCourses/Create
        public IActionResult Create()
        {


            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentCourseID,CourseID,StudentID")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse.SingleOrDefaultAsync(m => m.StudentCourseID == id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentCourseID,CourseID,StudentID")] StudentCourse studentCourse)
        {
            if (id != studentCourse.StudentCourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseExists(studentCourse.StudentCourseID))
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
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourse
                .SingleOrDefaultAsync(m => m.StudentCourseID == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourse = await _context.StudentCourse.SingleOrDefaultAsync(m => m.StudentCourseID == id);
            _context.StudentCourse.Remove(studentCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
            return _context.StudentCourse.Any(e => e.StudentCourseID == id);
        }
    }
}
