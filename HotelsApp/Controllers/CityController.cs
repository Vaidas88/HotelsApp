using HotelsApp.Dtos;
using HotelsApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelsApp.Controllers
{
    public class CityController : Controller
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        // GET: CityController
        public ActionResult Index()
        {
            return View(_cityService.GetAll());
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            var city = new CityDto();

            return View(city);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityDto city)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                city = new CityDto();

                return View(city);
            }

            try
            {
                _cityService.Create(city);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                city = new CityDto();

                return View(city);
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_cityService.GetSingle(id));
        }

        // POST: CityController/Edit/5
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

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CityController/Delete/5
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
