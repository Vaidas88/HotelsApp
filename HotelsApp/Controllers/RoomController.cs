using HotelsApp.Dtos;
using HotelsApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelsApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly RoomService _roomService;
        private readonly HotelService _hotelService;

        public RoomController(RoomService roomService, HotelService hotelService)
        {
            _roomService = roomService;
            _hotelService = hotelService;
        }

        // GET: RoomController
        public ActionResult Index()
        {
            return View(_roomService.GetAll());
        }

        public ActionResult Book(int roomId, int hotelId)
        {
            _roomService.Book(roomId);

            return RedirectToAction("Index", "Hotel", new { id = hotelId });
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";

            var room = new RoomDto();

            room.AvailableHotels = _hotelService.GetAvailable();

            return View(room);
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomDto room)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                room = new RoomDto();
                room.AvailableHotels = _hotelService.GetAvailable();

                return View(room);
            }

            try
            {
                _roomService.Create(room);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                room = new RoomDto();
                room.AvailableHotels = _hotelService.GetAvailable();

                return View(room);
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Error = "";

            var room = _roomService.GetSingle(id);

            room.AvailableHotels = _hotelService.GetAvailable();

            return View(room);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomDto room)
        {
            ViewBag.Error = "";

            if (!ModelState.IsValid)
            {
                room = _roomService.GetSingle(room.Id);

                room.AvailableHotels = _hotelService.GetAvailable();

                return View(room);
            }

            try
            {
                _roomService.Edit(room);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                room = _roomService.GetSingle(room.Id);

                room.AvailableHotels = _hotelService.GetAvailable();

                return View(room);
            }
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
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
