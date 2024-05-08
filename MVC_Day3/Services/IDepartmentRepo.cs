using MVC_Day3.Models;

namespace MVC_Day3.Services
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        Department GetById(int id);

        Department GetDeptByName(string name);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
    }
}
