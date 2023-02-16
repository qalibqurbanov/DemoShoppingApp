using Microsoft.AspNetCore.Mvc;
using DemoShoppingApp.DataAccess.Models;
using DemoShoppingApp.DataAccess.Models.ViewModels;
using DemoShoppingApp.DataAccess.UnitOfWork.Abstract;

namespace DemoShoppingApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CategoryViewModel categoryVM = new CategoryViewModel();
            categoryVM.Categories = this.unitOfWork.Category.GetAll();

            return View(categoryVM);
        }

        [HttpGet]
        public IActionResult CreateOrUpdate(int? ID)
        {
            CategoryViewModel categoryVM = new CategoryViewModel();

            if(ID == null || ID == 0)
            {
                return View(categoryVM);
            }
            else
            {
                categoryVM.Category = unitOfWork.Category.GetEntity(c => c.ID == ID);

                if (categoryVM.Category == null) return NotFound();
                else return View(categoryVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrUpdate(CategoryViewModel categoryVM)
        {
            if (ModelState.IsValid)
            {
                if (categoryVM.Category.ID == 0)
                {
                    unitOfWork.Category.Add(categoryVM.Category);
                    TempData["SUCCESS"] = "Category Created Successfully!";
                }
                else
                {
                    unitOfWork.Category.Update(categoryVM.Category);
                    TempData["SUCCESS"] = "Category Updated Successfully!";
                }

                unitOfWork.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? ID)
        {
            if(ID == null || ID == 0)
                return NotFound();

            Category category = unitOfWork.Category.GetEntity(c => c.ID == ID);

            if (category is null)
                return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? ID)
        {
            Category category = unitOfWork.Category.GetEntity(c => c.ID == ID);

            if (category is null)
                return NotFound();

            unitOfWork.Category.Delete(category);
            unitOfWork.SaveChanges();

            TempData["SUCCESS"] = "Category Deleted Successfully!";

            return RedirectToAction(nameof(Index));
        }
    }
}