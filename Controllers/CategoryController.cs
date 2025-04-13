using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FarmIt.Models.Domain;
using FarmIt.Respositories.Abstract;

namespace FarmIt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _categoryService.Add(model);
            if (result)
            {
                TempData["msg"] = "Sucesfully added";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on adding";
                return View();
            }





        }
        
        public IActionResult Edit(int id)
        {
            var data = _categoryService.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _categoryService.Update(model);
            if (result)
            {
                TempData["msg"] = "Sucesfully added";
                return RedirectToAction(nameof(CategoryList));
            }
            else
            {
                TempData["msg"] = "Error on adding";
                return View(model);
            }
        }

        public IActionResult CategoryList() 
        {
            var data = this._categoryService.List();
            return View(data);
           
        }

        public IActionResult Delete(int id)
        {
           
            var result = _categoryService.Delete(id);
            return RedirectToAction(nameof(CategoryList));
            
          
        }
    }
}
