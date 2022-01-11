using HotelsApp.Dtos;
using HotelsApp.Services;
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

        // GET: CityController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";

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
            ViewBag.Error = "";

            return View(_cityService.GetSingle(id));
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityDto city)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                return View(_cityService.GetSingle(city.Id));
            }

            try
            {
                _cityService.Edit(city);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View(_cityService.GetSingle(city.Id));
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            _cityService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
