using MVC_Day3.Models;
using MVC_Day3.Services;

namespace MVC_Day3.TestRepo
{
    public class StudentTestRepo : IStudentRepo
    {
        void IStudentRepo.Add(Student student)
        {
            throw new NotImplementedException();
        }

        void IStudentRepo.Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<Student> IStudentRepo.GetAll()
        {
            throw new NotImplementedException();
        }

        Student IStudentRepo.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Student IStudentRepo.GetDeptByName(string name)
        {
            throw new NotImplementedException();
        }

        void IStudentRepo.Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
