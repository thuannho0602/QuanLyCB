using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBApplication.Controllers
{
    public class DoanhThuThangController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.FullName = FullName();
            //var result = await GetData();
            return View();
        }
    }
}
