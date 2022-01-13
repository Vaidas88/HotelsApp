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
            HotelDto hotel = _hotelService.GetSingle(id);

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
        public ActionResult Create(HotelDto hotel)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                hotel = new HotelDto();
                hotel.AvailableCities = _cityService.GetAll();

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

                hotel = new HotelDto();
                hotel.AvailableCities = _cityService.GetAll();

                return View(hotel);
            }
        }

        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Error = "";

            var hotel = _hotelService.GetSingle(id);

            hotel.AvailableCities = _cityService.GetAll();

            return View(hotel);
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelDto hotel)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                hotel = _hotelService.GetSingle(hotel.Id);

                hotel.AvailableCities = _cityService.GetAll();

                return View(hotel);
            }

            try
            {
                _hotelService.Edit(hotel);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                hotel = _hotelService.GetSingle(hotel.Id);

                hotel.AvailableCities = _cityService.GetAll();

                return View(hotel);
            }
        }

        // GET: HotelController/Delete/5
        public ActionResult Delete(int id)
        {
            _hotelService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
