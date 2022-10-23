using CBBApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBApplication.Controllers
{
    public class LoaiMayBayController : BaseController
    {
        // GET: LoaiMayBayController
        public IActionResult Index()
        {
            ViewBag.FullName = FullName();
            //var result = await GetData();
            return View();
        }
    }
}
