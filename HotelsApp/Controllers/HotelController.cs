using HotelsApp.Dtos;
using HotelsApp.Models;
using HotelsApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelsApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelService _hotelService;
        private readonly CityService _cityService;

        public HotelController(HotelService hotelService, CityService cityService)
        {
            _hotelService = hotelService;
            _cityService = cityService;
        }

        // GET: HotelController
        public ActionResult Index()
        {
            return View(_hotelService.GetAll());
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            Hotel hotel = _hotelService.GetSingle(id);
            return View(hotel);
        }

        // GET: HotelController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";

            var hotel = new HotelDto();
            hotel.AvailableCities = _cityService.GetAll();

            return View(hotel);
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            ViewBag.Error = "";
            HotelDto hotelDto;

            if (!ModelState.IsValid)
            {
                hotelDto = new HotelDto();
                hotelDto.AvailableCities = _cityService.GetAll();

                return View(hotel);
            }

            try
            {
                _hotelService.Create(hotel);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                hotelDto = new HotelDto();
                hotelDto.AvailableCities = _cityService.GetAll();

                return View(hotel);
            }
        }

        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HotelController/Edit/5
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

        // GET: HotelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HotelController/Delete/5
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
