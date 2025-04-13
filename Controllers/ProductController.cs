using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FarmIt.Models.Domain;
using FarmIt.Models.DTO;
using FarmIt.Repositories.Abstract;
using FarmIt.Respositories.Abstract;

namespace FarmIt.Controllers
{
    [Authorize(Roles = "Fermer,Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFileService _fileService;
        private readonly ICategoryService _catService;
        public ProductController(ICategoryService catService,IProductService ProductService, IFileService fileService)
        {
            _productService = ProductService;
            _fileService = fileService;
            _catService = catService;
        }
        public IActionResult Add()
        {
            var model = new Product();
            model.CategoryList = _catService.List().Select(a => new SelectListItem { Text = a.CategoryName, Value = a.Id.ToString() });
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Product model)
        {
            model.CategoryList = _catService.List().Select(a => new SelectListItem { Text = a.CategoryName, Value = a.Id.ToString() });
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.ProductImage = imageName;
            }
            var result = _productService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var model = _productService.GetById(id);
            var selectedCategorys = _productService.GetCategoryByProductId(model.Id);
            MultiSelectList multiCategoryList = new MultiSelectList(_catService.List(), "Id", "CategoryName", selectedCategorys);
            model.MultiCategoryList = multiCategoryList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var selectedCategorys = _productService.GetCategoryByProductId(model.Id);
            MultiSelectList multiCategoryList = new MultiSelectList(_catService.List(), "Id", "CategoryName", selectedCategorys);
            model.MultiCategoryList = multiCategoryList;
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.ProductImage = imageName;
            }
            var result = _productService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(ProductList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult ProductList()
        {


            var data = this._productService.List(); 
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            return RedirectToAction(nameof(ProductList));
        }



    }
}
