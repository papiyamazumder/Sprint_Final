using Azure.Storage.Blobs;
using CsvHelper;
using Data.REPOSITORY;
using EmployeeEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public bool AddEmployee(Employee employee)
        {
            bool status = _employeeRepo.AddEmployee(employee);
            return status;
        }

        public List<Employee> GetAllEmployees() 
        {
            return _employeeRepo.GetAllEmployees();
        }
        
        public Employee GetEmployeeById(int id)
        {
            Employee employee = _employeeRepo.GetEmployeeById(id);
            return employee;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool status = _employeeRepo.UpdateEmployee(employee);
            return status;
        }

        public bool DeleteEmployee(int id)
        {
            bool status = _employeeRepo.DeleteEmployee(id);
            return status;
        }

        public List<Employee> SearchEmployees(string field, string value)
        {
            var searchedresult = _employeeRepo.SearchEmployees(field, value);
            return searchedresult;
        }

        //For uploading to Blob
        public string UploadEmployeeDetails(Employee employee)
        {
            try
            {
                // Serialize the Employee object to JSON
                string jsonEmployeeDetails = JsonConvert.SerializeObject(employee);

                // Connect to blob storage
                string blobConnectionString = "YourBlobConnectionStringHere";
                var blobServiceClient = new BlobServiceClient(blobConnectionString);

                // Get a reference to the container
                var containerClient = blobServiceClient.GetBlobContainerClient("tempcontainer");

                // Get a reference to the blob
                var blobClient = containerClient.GetBlobClient("EmployeeData.txt");

                // Convert employee details to byte array
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonEmployeeDetails);

                // Upload the byte array to the blob
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    blobClient.Upload(stream, overwrite: true);
                }

                return "Employee details uploaded to blob storage successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to upload employee details to blob storage", ex);
            }
        }


    }
}

 

    

