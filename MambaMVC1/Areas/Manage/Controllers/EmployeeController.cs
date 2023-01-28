using AutoMapper;
using MambaMVC1.Abstractions.Services;
using MambaMVC1.Areas.ViewModel.Employee;
using MambaMVC1.DAL;
using MambaMVC1.Models;
using MambaMVC1.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MambaMVC1.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize]
    public class EmployeeController : Controller
    {
        IPositionService _pos;
        IWebHostEnvironment _env;
        
        IEmployeeService _db;

        public EmployeeController(IWebHostEnvironment env, IEmployeeService db, IPositionService pos)
        {
            _env = env;
            _db = db;
            _pos = pos;
        }


        public IActionResult Index()
        {
            

            return View(_db.getAllWithPosition());
        }

        public IActionResult Create() 
        {
            ViewBag.Positions = new SelectList(_pos.GetAll().ToList(), nameof(Position.Id), nameof(Position.PositionName));
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeVM employeeVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Positions = new SelectList(_pos.GetAll().ToList(), nameof(Position.Id), nameof(Position.PositionName));
                return View();
            }

            if (employeeVM.Img.CheckSize())
            {
                ViewBag.Positions = new SelectList(_pos.GetAll().ToList(), nameof(Position.Id), nameof(Position.PositionName));
                ModelState.AddModelError("Img", "Incorrect Size");
                return View();
            }
            if (employeeVM.Img.CheckFileType())
            {
                ViewBag.Positions = new SelectList(_pos.GetAll().ToList(), nameof(Position.Id), nameof(Position.PositionName));
                ModelState.AddModelError("Img", "Incorrect Type of File");
            }

            _db.Create(employeeVM);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            var res = _db.EmployeeGetById((int)Id);
            if (res == null)
            {
                return BadRequest();
            }

            FileExtention.Delete(Path.Combine(_env.WebRootPath, "assets", "img", "team", res.ImgName));
            _db.Delete((int)Id);
            
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            ViewBag.Positions = new SelectList(_pos.GetAll().ToList(), nameof(Position.Id), nameof(Position.PositionName));
            return View();
        }

        [HttpPost]
        public IActionResult Update(int? Id, EmployeeUpdateVM updateVM) 
        {

            if (Id == null)
            {
                return BadRequest();
            }
            var res = _db.EmployeeGetById((int)Id);
            if (res == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Positions = new SelectList(_pos.GetAll().ToList(), nameof(Position.Id), nameof(Position.PositionName));
                return View();
            }

            if (updateVM.Img.CheckSize())
            {
                ViewBag.Positions = new SelectList(_pos.GetAll().ToList(), nameof(Position.Id), nameof(Position.PositionName));
                ModelState.AddModelError("Img", "Incorrect Size");
                return View();
            }
            if (updateVM.Img.CheckFileType())
            {
                ViewBag.Positions = new SelectList(_pos.GetAll().ToList(), nameof(Position.Id), nameof(Position.PositionName));
                ModelState.AddModelError("Img", "Incorrect Type of File");
            }

            _db.Update(updateVM);

            return RedirectToAction(nameof(Index));
        }

    }
}
