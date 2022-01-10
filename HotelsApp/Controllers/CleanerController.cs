using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelsApp.Controllers
{
    public class CleanerController : Controller
    {
        // GET: CleanerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CleanerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CleanerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CleanerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CleanerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CleanerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CleanerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CleanerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
