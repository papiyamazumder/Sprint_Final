using Data.DataContext;
using EmployeeEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPOSITORY
{
    public class DepartmentRepo : IDepartmentRepo
    {
        public readonly EMSDbContext _dbContext;  //_dbContext is an instance of EMSDbContext

        public DepartmentRepo(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddDepartment(Department department)
        {
            _dbContext.Department.Add(department);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteDepartment(int id)
        {
            Department department = _dbContext.Department.Find(id);
            _dbContext.Department.Remove(department);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Department> GetAllDepartments()
        {
            try
            {
                return _dbContext.Department.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching DEpartments: {ex.Message}");
                throw ex;
            }
        }

        public Department GetDepartmentById(int id)
        {
            Department department = _dbContext.Department.Find(id);
            return department;
        }

        public bool UpdateDepartment(Department department)
        {
            _dbContext.Entry(department).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
