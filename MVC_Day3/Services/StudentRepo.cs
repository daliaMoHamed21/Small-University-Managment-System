using Microsoft.EntityFrameworkCore;
using MVC_Day3.Models;

namespace MVC_Day3.Services
{
    //CRUD operations
    public class StudentRepo: IStudentRepo
    {

        public StudentRepo(Lab3DBContext _db )
        {
            dBContext = _db;
        }
        //Get all
        Lab3DBContext dBContext; //= new Lab3DBContext();
        public List<Student> GetAll()
        {
            return dBContext.students.Include(d => d.Department).ToList();//.Where(d => d.Department.Status == true)
        }

        public Student GetById(int id)
        {
            return dBContext.students.SingleOrDefault(d => d.Id == id);
        }
        //Add
        public void Add(Student student)
        {
            dBContext.students.Add(student);
            dBContext.SaveChanges();
        }
        //Update
        public void Update(Student student)
        {
            dBContext.students.Update(student);
            dBContext.SaveChanges();
        }

        //Delete
        public void Delete(int id)
        {
            var d = dBContext.students.SingleOrDefault(d => d.Id == id);
            dBContext.students.Remove(d);
            dBContext.SaveChanges();
        }

        Student IStudentRepo.GetDeptByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
