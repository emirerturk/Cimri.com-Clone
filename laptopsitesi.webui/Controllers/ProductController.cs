using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using laptopsitesi.webui.Data;
using laptopsitesi.webui.Models;

namespace laptopsitesi.webui.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult list(int? id, string q, double? min_price, double? max_price, string ekranboyut, string diskturu, string isletimsistemi, string bellekkapasitesi, string islemcimodel, string diskkapasite, string marka, string ekrankarti, string artanfiyat, string azalanfiyat, string puan)
        {
            var products = ProductRepository.Products;

            if (id != null)
            {
                products = products.Where(p => p.laptopid == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                q = q.ToLower();
                products = products.Where(i => i.Baslik.ToLower().Contains(q) || i.Link.ToLower().Contains(q.ToLower()) || i.EkranBoyutu.ToLower().Contains(q.ToLower()) || i.DiskTuru.ToLower().Contains(q.ToLower()) || i.IsletimSistemi.ToLower().Contains(q.ToLower()) || i.IsletimSistemi.ToLower().Contains(q.ToLower()) || i.BellekKapasitesi.ToLower().Contains(q.ToLower()) || i.IslemciModeli.ToLower().Contains(q.ToLower()) || i.DiskKapasitesi.ToLower().Contains(q.ToLower()) || i.Marka.ToLower().Contains(q.ToLower()) || i.EkranKarti.ToLower().Contains(q.ToLower()) || i.Model.ToLower().Contains(q.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(ekranboyut))
            {

                ekranboyut = ekranboyut.ToLower();
                products = products.Where(i => i.EkranBoyutu.ToLower().Contains(ekranboyut)).ToList();

            }
            if (!string.IsNullOrEmpty(artanfiyat))
            {

                products = products.OrderBy(i => Double.Parse(i.Fiyat)).ToList();
            }
            if (!string.IsNullOrEmpty(azalanfiyat))
            {

                products = products.OrderByDescending(i => Double.Parse(i.Fiyat)).ToList();
            }
            if (!string.IsNullOrEmpty(puan))
            {

                products = products.OrderByDescending(i => i.Puan).ToList();
            }

            var productViewModel = new ProductViewModel()
            {
                Products = products
            };

            return View(productViewModel);
        }

        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductById(id));
        }
    }
}