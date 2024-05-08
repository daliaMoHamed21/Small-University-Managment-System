using Microsoft.AspNetCore.Mvc;
using MVC_Day3.Models;
using MVC_Day3.Services;
using MVC_Day3.TestRepo;
using System;

namespace MVC_Day3.Controllers
{
    public class DepartmentController : Controller
    {
        //DepartmentRepo departmentRepo = new DepartmentRepo();
        IDepartmentRepo departmentRepo; //= new DepartmentTestRepo();
       //2- Resolve services
        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }

        //Depandancy inversion 


        //Index
        public IActionResult Index()
        {
            var model = departmentRepo.GetAll();
            return View(model);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }
     
        //HttpPost /Create
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    departmentRepo.Add(department);
                    
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", $"An error occurred: {e.Message}");
                    return View(department);
                }

                return RedirectToAction("Index");
            }

            return View(department);
        }
        //Check department ID
        public IActionResult CheckedDeptId(int DeptId)
        {
            var model = departmentRepo.GetById(DeptId);
            if (model != null)
            {
                return Json(false);
            }
            else
                return Json(true);

        }


        //Check department Name
        public IActionResult CheckDeptName(string DeptName, int DeptId)
        {
            var model = departmentRepo.GetDeptByName(DeptName);
            //db.departments.FirstOrDefault(d=> d.DeptName);
            if (model == null)
                return Json(true);
            else
                return Json("Try use " + DeptName + DeptId.ToString());
        }

        //Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("You Must Provide Id");
            }
            var model = departmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Enter Id");
            }
            departmentRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }

        //Edit 
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var model = departmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //HttpPost /Edit
        [HttpPost]
        public IActionResult Edit(Department department, int? id)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    department.DeptId = id.Value;
                    departmentRepo.Update(department);
                    return RedirectToAction("Index");

         
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", $"An error occurred: {e.Message}");
                    return View(department);
                }
            }
            return View(department);
        }

        //Update
        //public IActionResult Update(int? id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    var model = departmentRepo.GetById(id.Value);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(model);
        //}

        ////HttpPost /Update
        //[HttpPost]
        //public IActionResult Update(Department department)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            departmentRepo.Update(department);
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception e)
        //        {
        //            ModelState.AddModelError("", $"An error occurred: {e.Message}");
        //            return View(department);
        //        }
        //    }
        //    return View(department);
        //}


    }
}
