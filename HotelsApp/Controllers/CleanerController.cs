using HotelsApp.Dtos;
using HotelsApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelsApp.Controllers
{
    public class CleanerController : Controller
    {
        private readonly CleanerService _cleanerService;
        private readonly CityService _cityService;

        public CleanerController(CleanerService cleanerService, CityService cityService)
        {
            _cleanerService = cleanerService;
            _cityService = cityService;
        }
        // GET: CleanerController
        public ActionResult Index()
        {
            return View(_cleanerService.GetAll());
        }

        // GET: CleanerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CleanerController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";

            var cleaner = new CleanerDto();
            cleaner.AvailableCities = _cityService.GetAll();

            return View(cleaner);
        }

        // POST: CleanerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CleanerDto cleaner)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                cleaner = new CleanerDto();
                cleaner.AvailableCities = _cityService.GetAll();

                return View(cleaner);
            }

            try
            {
                _cleanerService.Create(cleaner);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                cleaner = new CleanerDto();
                cleaner.AvailableCities = _cityService.GetAll();

                return View(cleaner);
            }
        }

        // GET: CleanerController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Error = "";

            var cleaner = _cleanerService.GetSingle(id);

            cleaner.AvailableCities = _cityService.GetAll();

            return View(cleaner);
        }

        // POST: CleanerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CleanerDto cleaner)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                cleaner = _cleanerService.GetSingle(cleaner.Id);

                cleaner.AvailableCities = _cityService.GetAll();

                return View(cleaner);
            }

            try
            {
                _cleanerService.Edit(cleaner);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                cleaner = _cleanerService.GetSingle(cleaner.Id);

                cleaner.AvailableCities = _cityService.GetAll();

                return View(cleaner);
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
