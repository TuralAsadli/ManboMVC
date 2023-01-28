using MambaMVC1.Abstractions.Services;
using MambaMVC1.Areas.ViewModel.Position;
using MambaMVC1.DAL;
using MambaMVC1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MambaMVC1.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class PositionController : Controller
    {
        IPositionService _db;

        public PositionController(IPositionService db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePositionVM positionVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _db.Create(positionVM);

            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int? Id, CreatePositionVM positionVM) 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var res = _db.Get((int)Id);
            if (res == null) { return NotFound(); }

            _db.Update(positionVM);
            return View();
        }


        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var res = _db.Get((int)Id);

            if (res == null) { return NotFound();}

            _db.Delete((int)Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
