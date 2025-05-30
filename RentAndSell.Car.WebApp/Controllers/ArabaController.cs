﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAndSell.Car.WebApp.Models;
using System.Net.Http.Headers;

namespace RentAndSell.Car.WebApp.Controllers
{
    [Authorize]
    public class ArabaController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpcontextAccessor;
        private const string _endPoint = "Cars";
        private readonly string _token;
        public ArabaController(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7027/api/");
            _httpcontextAccessor = contextAccessor;

            string token = _httpcontextAccessor.HttpContext.Session.GetString("Token");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            

        }


        // GET: ArabaController
        public ActionResult Index()
        {
            List<ArabaViewModel> model = _httpClient.GetFromJsonAsync<List<ArabaViewModel>>(_endPoint).Result;

            return View(model);
        }

        // GET: ArabaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArabaController/Create
        public ActionResult Create()
        {
            ArabaViewModel model = new ArabaViewModel();
            ViewBag.Token = _token;
            return View();
        }

        // POST: ArabaController/Create
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

        // GET: ArabaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArabaController/Edit/5
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

        // GET: ArabaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArabaController/Delete/5
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
