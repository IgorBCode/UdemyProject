using Udemy.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Udemy.DataAccess.Data;
using Udemy.Models;

namespace UdemyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ********** VIEW LIST OF PRODUCTS **********
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        // ********** CREATE POST **********
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        // ********** EDIT POST **********
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // video 46 covers how to query different fields to find records not just
            // the primary key which is id in this case 7:31
            Product? productfromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productfromDb == null)
            {
                return NotFound();
            }
            return View(productfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            // SERVER SIDE validation
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        // ********** DELETE POST **********
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? productfromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productfromDb == null)
            {
                return NotFound();
            }
            return View(productfromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
