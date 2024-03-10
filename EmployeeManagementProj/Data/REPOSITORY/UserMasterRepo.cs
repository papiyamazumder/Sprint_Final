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
    public class UserMasterRepo:IUserMasterRepo
    {
        public readonly EMSDbContext _dbContext;  //_dbContext is an instance of EMSDbContext

        public UserMasterRepo(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddUserCredentials(UserMaster user)
        {
            _dbContext.UserMaster.Add(user);
            _dbContext.SaveChanges();
            return true;
        }
        public UserMaster GetUserCredentialsById(string userId)
        {
            // Retrieve the user from the database based on the provided userId
            UserMaster user = _dbContext.UserMaster.Find(userId);
            return user;
        }
        public List<UserMaster> GetAllUserCredentials()
        {
            try
            {
                return _dbContext.UserMaster.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching UserCredentials: {ex.Message}");
                throw ex;
            }
        }
        
        public bool DeleteUserCredentials(string id)
        {
            UserMaster user = _dbContext.UserMaster.Find(id);
            _dbContext.UserMaster.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateUserCredentials(UserMaster user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
