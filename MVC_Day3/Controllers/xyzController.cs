using Microsoft.AspNetCore.Mvc;
using MVC_Day3.Services;

namespace MVC_Day3.Controllers
{
    public class xyzController : Controller
    {
        IDepartmentRepo _departmentRepo;
        public xyzController(IDepartmentRepo _Dept)
        {
            _departmentRepo = _Dept;
        }
        public IActionResult Index([FromServices]IDepartmentRepo dept)
        {
            return Content($" Action paramter {dept.GetHashCode().ToString() } -Constructor injection{_departmentRepo.GetHashCode()}");
        }
    }
}
