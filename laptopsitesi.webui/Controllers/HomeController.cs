using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using laptopsitesi.webui.Data;
using laptopsitesi.webui.Models;

namespace laptopsitesi.webui.Controllers
{
    // localhost:5000/home
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var productViewModel = new ProductViewModel()
            {
                Products = ProductRepository.Products
            };

            return View(productViewModel);
        }

    }
}