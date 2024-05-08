using Microsoft.EntityFrameworkCore;
using MVC_Day3.Models;

namespace MVC_Day3.Services
{
    //CRUD operation 
    public class DepartmentRepo: IDepartmentRepo
    {

        //public DepartmentRepo(Lab3DBContext _db)
        //{
        //    dBContext = _db;
        //}




        //Getall
        Lab3DBContext dBContext = new Lab3DBContext();
        public List<Department> GetAll()
        {
            return dBContext.departments.ToList(); //Where(d => d.Status == true).ToList();
        }

        public Department GetById(int id)
        {
            return  dBContext.departments.SingleOrDefault(d => d.DeptId == id);
        }
        public Department GetDeptByName(string name)
        {
            return dBContext.departments.FirstOrDefault(d => d.DeptName == name);
        }
        //Add
        public void Add(Department department)
        {
            dBContext.departments.Add(department);
            dBContext.SaveChanges();
        }
        //Update
        public void Update(Department department)
        {
            dBContext.departments.Update(department);
            dBContext.SaveChanges();
        }
        //Delete
        public void Delete(int id)
        {
            var d = dBContext.departments.SingleOrDefault(d => d.DeptId == id);
            dBContext.departments.Remove(d);
         // dBContext.departments.Update(d);
          //d.Status = false;
            dBContext.SaveChanges();
        }



    }
}

