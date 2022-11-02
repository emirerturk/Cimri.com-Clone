using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using laptopsitesi.webui.Data;

namespace laptopsitesi.webui.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["action"].ToString() == "list")
                ViewBag.SelectedCategory = RouteData?.Values["id"];
            return View(CategoryRepository.Categories);
        }
    }
}