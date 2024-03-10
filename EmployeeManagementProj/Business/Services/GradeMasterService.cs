using Data.REPOSITORY;
using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GradeMasterService
    {
        private readonly IGradeMasterRepo _gradeMasterRepo;

        public GradeMasterService(IGradeMasterRepo gradeMasterRepo) 
        {
            _gradeMasterRepo = gradeMasterRepo;
        }

        public bool AddGrades(GradeMaster grade)
        {
            bool status = _gradeMasterRepo.AddNewGrades(grade);
            return status;
        }
        public bool DeleteGrades(string gradecode)
        {
            bool status = _gradeMasterRepo.DeleteGrades(gradecode);
            return status;
        }
        public List<GradeMaster> GetAllGrades()
        {
            return _gradeMasterRepo.GetAllGrades();
        }
        public GradeMaster GetGradesById(string gradecode)
        {
            GradeMaster grade = _gradeMasterRepo.GetGradesById(gradecode);
            return grade;
        }
        public bool UpdateGrades(GradeMaster grade)
        {
            bool status = _gradeMasterRepo.UpdateGrades(grade);
            return status;
        }
    }
}
