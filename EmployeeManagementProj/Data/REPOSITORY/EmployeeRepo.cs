using Data.DataContext;
using EmployeeEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPOSITORY
{
    public class EmployeeRepo : IEmployeeRepo
    {
        //EmployeeRepo is a repository class responsible for handling database operations
        //related to the Employee entity.It takes EMSDbContext as a dependency in its
        //constructor.Using _dbContext, CRUD operations can be performed.

        public readonly EMSDbContext _dbContext;  //_dbContext is an instance of EMSDbContext

        public EmployeeRepo(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// This method will fetch all the employees from the db.
        /// </summary>

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return _dbContext.Employee.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching employees: {ex.Message}");
                throw ex;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee = _dbContext.Employee.Find(id);
            return employee;
        }
        public bool AddEmployee(Employee employee)
        {
            _dbContext.Employee.Add(employee);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateEmployee(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        public bool DeleteEmployee(int id)
        {
            Employee employee = _dbContext.Employee.Find(id);
            _dbContext.Employee.Remove(employee);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Employee> SearchEmployees(string field, string value)
        {
            switch (field)
            {
                case "EmpID":
                    {
                        var r1 = _dbContext.Employee.Where(e => e.EmpID == value).ToList()[0];
                        var r2 = _dbContext.Employee.Find(value);
                        var r3 = _dbContext.Employee.Where(e => e.EmpID.Equals(value)).ToList()[0];
                        var r4 = _dbContext.Employee.Select(e => e.EmpID== value).ToList()[0];

                        var result = _dbContext.Employee.Where(e => e.EmpID == value).ToList();
                        return result;
                    }
                   
                case "EmpFirstName":
                    return _dbContext.Employee.Where(e => e.EmpFirstName.Contains(value)).ToList();
                case "EmpLastName":
                    return _dbContext.Employee.Where(e => e.EmpLastName.Contains(value)).ToList();
                case "DateOfJoining":
                    var searchDate = DateTime.Parse(value);
                    // Assuming you want to search for employees who joined on the specific date
                    return _dbContext.Employee.Where(e => e.DateOfJoining.Date == searchDate.Date).ToList();
                case "EmpDeptID":
                    return _dbContext.Employee.Where(e => e.EmpDeptID.ToString() == value).ToList();

                case "EmpGrade":
                    return _dbContext.Employee.Where(e => e.EmpGrade.Contains(value)).ToList();

                case "EmpDesignation":
                    return _dbContext.Employee.Where(e => e.EmpDesignation.Contains(value)).ToList();

                case "EmpBasic":
                    return _dbContext.Employee.Where(e => e.EmpBasic.ToString() == value).ToList();

                case "EmpGender":
                    return _dbContext.Employee.Where(e => e.EmpGender.Contains(value)).ToList();

                case "EmpMaritalStatus":
                    return _dbContext.Employee.Where(e => e.EmpMaritalStatus.Contains(value)).ToList();

                case "EmpContactNum":
                    return _dbContext.Employee.Where(e => e.EmpContactNum.Contains(value)).ToList();

                // Add more cases for other properties as needed
                default:
                    throw new ArgumentException("Invalid field", nameof(field));
            }
        }
    }
}
