using OnlineShoppingApp.UI.Alerts;
using OnlineShoppingApp.UI.ControllerUtilities;
using OnlineShoppingApp.UI.DataAccess;
using OnlineShoppingApp.UI.Models;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI.Controllers
{
    [Authorize]
    public class RoleController : OnlineShoppingBaseController
    {
        private IGenericRepository<Role> roleRepository = null;

        public RoleController()
        {
            roleRepository = new GenericRepository<Role>();
        }

        public ActionResult Index()
        {
            return View(roleRepository.GetAll(null, null));
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<RoleController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Role role = roleRepository.GetById(id.Value);

            if(role == null)
            {
                return RedirectToAction<RoleController>(x => x.Index()).WithError("Role does not exist!");
            }

            return View(role);
        }

        [AuthorizeUser("Admin", "SuperAdmin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                roleRepository.Insert(role);
                return RedirectToAction<RoleController>(x => x.Index()).WithSuccess("Role updated successfully!");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<RoleController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Role role = roleRepository.GetById(id.Value);

            if (role == null)
            {
                return RedirectToAction<RoleController>(x => x.Index()).WithError("Role does not exist!");
            }

            return View(role);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Role role)
        {
            if (ModelState.IsValid)
            {
                roleRepository.Update(role);
                return RedirectToAction<RoleController>(x => x.Index()).WithSuccess("Role updated successfully!");
            }
            else
            {
                Role oldRole = roleRepository.GetById(id);

                if (oldRole == null)
                {
                    return RedirectToAction<RoleController>(x => x.Index()).WithError("Role does not exist!");
                }

                return View(oldRole);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return RedirectToAction<RoleController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            Role role = roleRepository.GetById(id.Value);

            if (role == null)
            {
                return RedirectToAction<RoleController>(x => x.Index()).WithError("Role does not exist!");
            }

            return View(role);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction<RoleController>(x => x.Index()).WithError("Id cannot be less than or equal to zero!");
            }

            roleRepository.Delete(id);
            return RedirectToAction<RoleController>(x => x.Index()).WithSuccess("Role deleted successfully!");
        }
    }
}
