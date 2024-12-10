using DIPatternDemo_Layered .Models;
using DIPatternDemo_Layered .Services;
using Microsoft .AspNetCore .Http;
using Microsoft .AspNetCore .Mvc;

namespace DIPatternDemo_Layered .Controllers
    {

    public class CategoryController : Controller
        {

        private readonly ICategoryService service;
        public CategoryController ( ICategoryService service )
            {
            this .service = service;
            }
        public ActionResult Index ()
            {
          //  var res = service .GetAllCategories();
            return View(service .GetCategories());
            }

        // GET: CategoryController/Details/5
        public ActionResult Details ( int id )
            {
            return View(service .GetCategoryById(id));
            }

        // GET: CategoryController/Create
        public ActionResult Create ()
            {
            return View();
            }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create ( Category cat )
            {
            try
                {
                var result = service .AddCategory(cat);
                if ( result >= 1 )
                    {
                    return RedirectToAction(nameof(Index));
                    }
                else
                    {
                    ViewBag .Error = "Error";
                    return View();
                    }
                }
            catch ( Exception ex )
                {
                ViewBag .Error = ex .Message;
                return View();
                }
            }

        // GET: CategoryController/Edit/5
        public ActionResult Edit ( int id )
            {
            return View(service .GetCategoryById(id));
            }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ( Category cat )
            {
            try
                {
                var result = service .UpdateCategory(cat);
                if ( result >= 1 )
                    {
                    return RedirectToAction(nameof(Index));
                    }
                else
                    {
                    ViewBag .Error = "Error";
                    return View();
                    }
                }
            catch ( Exception ex )
                {
                ViewBag .Error = ex .Message;
                return View();
                }
            }

        // GET: CategoryController/Delete/5
        public ActionResult Delete ( int id )
            {
            return View(service .GetCategoryById(id));
            }

        // POST: CategoryController/Delete/5
        [HttpPost]
      [ActionName("Delete")]
        public ActionResult DeleteConfirm ( int id )
            {
            try
                {
                var result = service .DeleteCategory(id);
                if ( result >= 1 )
                    {
                    return RedirectToAction(nameof(Index));
                    }
                else
                    {
                    ViewBag .Error = "Error";
                    return View();
                    }
                }
            catch ( Exception ex )
                {
                ViewBag .Error = ex .Message;
                return View();
                }
            }
        }
    }
