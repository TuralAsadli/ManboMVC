using MambaMVC1.DAL;
using MambaMVC1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MambaMVC1.Controllers
{
    public class HomeController : Controller
    {
        ManbaDbContext _db;

        public HomeController(ManbaDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Employees.Include(x => x.Position));
        }

        
    }
}