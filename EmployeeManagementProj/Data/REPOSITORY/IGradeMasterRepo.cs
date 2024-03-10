using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.REPOSITORY
{
    public interface IGradeMasterRepo
    {
        bool AddNewGrades(GradeMaster grade);
        GradeMaster GetGradesById(string gradecode);
        List<GradeMaster> GetAllGrades();
        bool UpdateGrades(GradeMaster grade);
        bool DeleteGrades(string gradecode);
    }
}
