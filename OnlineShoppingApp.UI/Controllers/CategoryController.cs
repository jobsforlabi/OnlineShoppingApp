using OnlineShoppingApp.UI.Alerts;
using OnlineShoppingApp.UI.ControllerUtilities;
using OnlineShoppingApp.UI.DataAccess;
using OnlineShoppingApp.UI.Models;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Controllers
{
    [AuthorizeUser("SuperAdmin")]
    public class CategoryController : OnlineShoppingBaseController
    {
        private IGenericRepository<Category> categoryRepository;
        public CategoryController()
        {
            categoryRepository = new GenericRepository<Category>();
        }
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View(categoryRepository.GetAll(null, null));
        }

        // GET: ProductCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<CategoryController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Category category = categoryRepository.GetById(id.Value);

            if (category == null)
            {
                return RedirectToAction<CategoryController>(x => x.Index()).WithError("Category does not exist!");
            }

            return View(category);
        }

        // GET: ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategory/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")]Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Insert(category);
                return RedirectToAction<CategoryController>(x => x.Index()).WithSuccess("Category updated successfully!");
            }
            else
            {
                return View();
            }
        }

        // GET: ProductCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<CategoryController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Category category = categoryRepository.GetById(id.Value);

            if (category == null)
            {
                return RedirectToAction<CategoryController>(x => x.Index()).WithError("Category does not exist!");
            }

            return View(category);
        }

        // POST: ProductCategory/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Exclude = "Products")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(category);
                return RedirectToAction<CategoryController>(x => x.Index()).WithSuccess("Category updated successfully!");
            }
            else
            {
                Category oldCategory = categoryRepository.GetById(id);

                if (oldCategory == null)
                {
                    return RedirectToAction<CategoryController>(x => x.Index()).WithError("Category does not exist!");
                }

                return View(oldCategory);
            }
        }

        // GET: ProductCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<CategoryController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Category category = categoryRepository.GetById(id.Value);

            if (category == null)
            {
                return RedirectToAction<CategoryController>(x => x.Index()).WithError("Category does not exist!");
            }

            return View(category);
        }

        // POST: ProductCategory/Delete/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction<CategoryController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            categoryRepository.Delete(id);
            return RedirectToAction<CategoryController>(x => x.Index()).WithSuccess("Category deleted successfully!");
        }
    }
}
