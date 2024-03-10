using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPOSITORY
{
    public interface IDepartmentRepo
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(int id);
    }
}
