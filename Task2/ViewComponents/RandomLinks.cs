
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication16.Models;

namespace WebApplication16.ViewComponents
{
    public class RandomLinksViewComponent : ViewComponent
    {
        private readonly INavRepository db;

        public RandomLinksViewComponent(INavRepository context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var res = await Task<IEnumerable<NavLink>>.Run(()=>db.GetAll().OrderBy(a=>Guid.NewGuid()).Take(3));
            return View(res);
        }

    }


}