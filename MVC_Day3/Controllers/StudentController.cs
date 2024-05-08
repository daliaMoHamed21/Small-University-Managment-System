using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Day3.Models;
using MVC_Day3.Services;

namespace MVC_Day3.Controllers
{
    [Authorize(Roles = "Admin")]

    //dependent
    public class StudentController : Controller
    {
        //depandancy 
        IStudentRepo studentRepo; //= new StudentRepo();
        //depandancy 
        IDepartmentRepo departmentRepo;//= new DepartmentRepo();

        public StudentController(IDepartmentRepo _departmentRepo ,IStudentRepo _studentRepo)
        {
            departmentRepo = _departmentRepo;
            studentRepo = _studentRepo;
        }
        public IActionResult Index()
        {

            var model = studentRepo.GetAll();
            return View(model);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.depts = departmentRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            //add in dbContext
            if (!ModelState.IsValid)
            {
                studentRepo.Add(std);
               

                return RedirectToAction("Index");
            }
            else
            {
                // ModelState.AddModelError("", "username or password incorrect");
                ViewBag.depts =departmentRepo.GetAll();

                return View(std);
            }
        }
        
        [HttpGet]
         public IActionResult Edit(int? id)
        {
            if(id == null)
                return BadRequest();

            Student model = studentRepo.GetById(id.Value);
            if (model == null)
                return NotFound();

            ViewBag.depts = departmentRepo.GetAll();
            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            studentRepo.Update(std);
            return RedirectToAction("Index");
        }
        //Add
        //public IActionResult Add(int Id,List<string> Names, Dictionary<int, int> Degree)
        //{
        //    return Content($"Id = {Id}" +
        //                   $"Names Lenghth => {Names.Count}" +
        //                   $"Degree[2] = >{Degree[2]}");
        //}
        //Add file
        //public IActionResult AddFile()
        //{
        //    return View();
        //}

        ////HttpPost / Add file
        //[HttpPost]
        //public IActionResult AddFile(int id, IFormFile formFile)
        //{
        //    string fileName = id.ToString() + "." + formFile.FileName.Split('.').Last();
        //    using (FileStream fileStream = new FileStream("wwwroot/Images/" + fileName, FileMode.Create))
        //    {
        //        formFile.CopyTo(fileStream);
        //    }
        //    return Content("File Added");
        //}
    }
}
