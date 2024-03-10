using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPOSITORY
{
    public interface IUserMasterRepo
    {
        bool AddUserCredentials (UserMaster user);
        UserMaster GetUserCredentialsById(string userId);
        List<UserMaster> GetAllUserCredentials();
        bool UpdateUserCredentials (UserMaster user);
        bool DeleteUserCredentials(string userId);
    }
}
