using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBApplication.Controllers
{
    public class QuanLyDanhSachChuyenBayController : BaseController
    {
        public IActionResult Index()
        {
           //await service.GetVerificationRecordAsync("UserToken");
            ViewBag.FullName = FullName();
            return View();
        }
    }
}
