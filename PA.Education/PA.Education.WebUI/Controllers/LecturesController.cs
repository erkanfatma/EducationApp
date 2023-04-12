using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA.Education.Bll.Services;
using PA.Education.Dal.Models;

namespace PA.Education.WebUI.Controllers
{
    public class LecturesController : Controller
    {
        private readonly LectureService _service;
        public LecturesController(LectureService service)
        {
            _service = service;
        }

        // GET: Lectures
        public async Task<IActionResult> Index()
        {
            return View(_service.GetAllLectures());
        }

        // GET: Lectures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lecture = _service.GetById(id.Value);
        
            return View(lecture);
        }

        // GET: Lectures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
               _service.CreateLecture(lecture);
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }

        // GET: Lectures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lecture = _service.GetById(id.Value);

            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status,CreatedDate")] Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _service.UpdateLecture(lecture);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = _service.GetById(id.Value);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecture = _service.GetById(id);
            if (lecture == null)
            {
                return NotFound();
            }
            if (lecture != null)
            {
                _service.DeleteLecture(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
