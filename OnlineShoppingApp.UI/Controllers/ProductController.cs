using OnlineShoppingApp.UI.Alerts;
using OnlineShoppingApp.UI.ControllerUtilities;
using OnlineShoppingApp.UI.DataAccess;
using OnlineShoppingApp.UI.Models;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Controllers
{
    [AuthorizeUser("SuperAdmin")]
    public class ProductController : OnlineShoppingBaseController
    {
        private IGenericRepository<Product> productRepository;
        public ProductController()
        {
            productRepository = new GenericRepository<Product>();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(productRepository.GetAll(null, null));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<ProductController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Product product = productRepository.GetById(id.Value);

            if (product == null)
            {
                return RedirectToAction<ProductController>(x => x.Index()).WithError("Product does not exist!");
            }

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")]Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Insert(product);
                return RedirectToAction<ProductController>(x => x.Index()).WithSuccess("Product updated successfully!");
            }
            else
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<ProductController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Product product = productRepository.GetById(id.Value);

            if (product == null)
            {
                return RedirectToAction<ProductController>(x => x.Index()).WithError("Product does not exist!");
            }

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Exclude = "ProductCategory, ShoppingCarts")] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Update(product);
                return RedirectToAction<ProductController>(x => x.Index()).WithSuccess("Product updated successfully!");
            }
            else
            {
                Product oldProduct = productRepository.GetById(id);

                if (oldProduct == null)
                {
                    return RedirectToAction<ProductController>(x => x.Index()).WithError("Product does not exist!");
                }

                return View(oldProduct);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<ProductController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Product product = productRepository.GetById(id.Value);

            if (product == null)
            {
                return RedirectToAction<ProductController>(x => x.Index()).WithError("Product does not exist!");
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction<ProductController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            productRepository.Delete(id);
            return RedirectToAction<ProductController>(x => x.Index()).WithSuccess("Product deleted successfully!");
        }
    }
}
