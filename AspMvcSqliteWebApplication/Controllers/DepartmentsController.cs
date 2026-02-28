using AspMvcSqliteWebApplication.Entities;
using AspMvcSqliteWebApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcSqliteWebApplication.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository repository;

        public DepartmentsController(IDepartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var entities = await repository.GetAll();
            return View(entities);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department entity)
        {
            ////if (ModelState.IsValid)
            ////{
            await repository.Add(entity);
            await repository.SaveChanges();
            return RedirectToAction("Index");
            ////}
            ////return View(entity);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Department entity)
        {
            var entityData = await repository.GetById(id);
            if (entityData == null)
            {
                return NotFound();
            }

            ////if (ModelState.IsValid)
            ////{
            await repository.Update(entity);
            await repository.SaveChanges();
            return RedirectToAction("Index");
            ////}
            ////return View(entity);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await repository.Delete(id);
            await repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
