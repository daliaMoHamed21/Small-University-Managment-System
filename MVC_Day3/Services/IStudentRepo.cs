using MVC_Day3.Models;

namespace MVC_Day3.Services
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);

        Student GetDeptByName(string name);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
