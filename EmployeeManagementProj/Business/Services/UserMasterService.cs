using Data.REPOSITORY;
using EmployeeEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserMasterService
    {
        private readonly IUserMasterRepo _usermasterrepo;

        public UserMasterService(IUserMasterRepo userMasterRepo) 
        {
            _usermasterrepo = userMasterRepo;
        }
        public bool CreateUser(UserMaster newUser)
        {
            // Create the regular user in the database
            _usermasterrepo.AddUserCredentials(newUser);
            return true;
        }

        public UserMaster AuthenticateUser(string userId, string password, string usertype)
        {
            // Retrieve the user from the database based on the provided userId
            var user = _usermasterrepo.GetUserCredentialsById(userId);

            // Check if the user exists and if the provided password matches
            if (user != null && user.UserPassword == password && user.UserType == usertype)
            {
                return user; // Return the authenticated user
            }
            return null; // Return null if authentication fails
        }

        public List<UserMaster> GetAllUserCredentials()
        {
            return _usermasterrepo.GetAllUserCredentials();
        }
        public bool UpdateUserCredentials(UserMaster user)
        {
            bool status = _usermasterrepo.UpdateUserCredentials(user);
            return status;
        }
        public bool DeleteUserCredentials(string id)
        {
            bool status = _usermasterrepo.DeleteUserCredentials(id);
            return status;
        }
        public UserMaster GetUserCredentialsById(string userId)
        {
            // Retrieve the user from the database based on the provided userId
            UserMaster user = _usermasterrepo.GetUserCredentialsById(userId);
            return user;
        }
    }
}
