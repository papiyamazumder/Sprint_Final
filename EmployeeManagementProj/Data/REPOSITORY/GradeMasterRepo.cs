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
    public class GradeMasterRepo : IGradeMasterRepo
    {
        public readonly EMSDbContext _dbContext;  //_dbContext is an instance of EMSDbContext

        public GradeMasterRepo(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddNewGrades(GradeMaster grade)
        {
            _dbContext.GradeMaster.Add(grade);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteGrades(string gradecode)
        {
            GradeMaster grade = _dbContext.GradeMaster.Find(gradecode);
            _dbContext.GradeMaster.Remove(grade);
            _dbContext.SaveChanges();
            return true;
        }

        public List<GradeMaster> GetAllGrades()
        {
            try
            {
                return _dbContext.GradeMaster.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching Grades: {ex.Message}");
                throw ex;
            }
        }

        public GradeMaster GetGradesById(string gradecode)
        {
            // Retrieve the grade from the database based on the provided userId
            GradeMaster grade = _dbContext.GradeMaster.Find(gradecode);
            return grade;
        }

        public bool UpdateGrades(GradeMaster grade)
        {
            _dbContext.Entry(grade).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
