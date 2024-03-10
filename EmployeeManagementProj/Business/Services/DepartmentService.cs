using Data.REPOSITORY;
using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;


        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public bool AddDepartment(Department department)
        {
            bool status = _departmentRepo.AddDepartment(department);
            return status;
        }

        public List<Department> GetAllDepartments()
        {
            return _departmentRepo.GetAllDepartments();
        }

        public Department GetDepartmentById(int id)
        {
            Department department = _departmentRepo.GetDepartmentById(id);
            return department;
        }

        public bool UpdateDepartment(Department department)
        {
            bool status = _departmentRepo.UpdateDepartment(department);
            return status;
        }

        public bool DeleteDepartment(int id)
        {
            bool status = _departmentRepo.DeleteDepartment(id);
            return status;
        }
    }
}
