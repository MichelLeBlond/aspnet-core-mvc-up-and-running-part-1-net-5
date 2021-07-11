using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCourse1.Data;
using ASPCourse1.Models;

namespace ASPCourse1.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
             
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objLIst = _db.ApplicationType;
            return View(objLIst);
        }
        // Get - Create
        public IActionResult Create()
        {
            return View();
        }
        // Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
