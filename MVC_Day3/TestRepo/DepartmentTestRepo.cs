using MVC_Day3.Models;
using MVC_Day3.Services;

namespace MVC_Day3.TestRepo
{
    public class DepartmentTestRepo: IDepartmentRepo
    {
         List<Department> DeptList =
           [new Department()
           {
               DeptId=1,
               DeptName="CSS"
           },
           ];
        public List<Department> GetAll()
        {
            return DeptList;
        }
        public Department GetById(int id)
        {
            return DeptList.FirstOrDefault(d=>d.DeptId == id);
        }
        public void Update(Department department)
        {
            var m = GetById(department.DeptId);
            m.DeptName = department.DeptName;
           // m.Status = department.Status;
        }

        public void Delete (int id)
        {
            var m = GetById(id);
            DeptList.Remove(m);

        }
        public Department GetDeptByName(string name)
        {
            return DeptList.FirstOrDefault(d => d.DeptName == name);


        }

        List<Department> IDepartmentRepo.GetAll()
        {
            throw new NotImplementedException();
        }

        Department IDepartmentRepo.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Department IDepartmentRepo.GetDeptByName(string name)
        {
            throw new NotImplementedException();
        }

        void IDepartmentRepo.Add(Department department)
        {
            throw new NotImplementedException();
        }

        void IDepartmentRepo.Update(Department department)
        {
            throw new NotImplementedException();
        }

        void IDepartmentRepo.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
