using Business.Services;
using CsvHelper;
using EmployeeEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Azure.Storage.Blobs;

namespace EmployeeManagementProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost] // Method attribute
        public IActionResult AddEmployee(Employee employee) // IActionResult will accept any return type like JSON, object, XML
        {
            //    try
            //    {

            //        //// Check if model state is valid
            //        //if (!ModelState.IsValid)
            //        //{
            //        //    // Model validation failed, return ModelState errors
            //        //    return BadRequest(ModelState);
            //        //}

            //        //// Add employee
            //        //bool status = _employeeService.AddEmployee(employee);
            //        //if (!status)
            //        //{
            //        //    // If adding employee failed, return 400 Bad Request with an error message
            //        //    return BadRequest("Failed to insert employee records");
            //        //}

            //        // For uploading to Blob

            //        string attendJsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
            //        //Connection String to Azure blob storage. Ideally, this connection string should be stored securely and retrieved from a configuration source
            //        string conStr = "DefaultEndpointsProtocol=https;AccountName=employeetemp;AccountKey=uYhV4dE3BbIds6172ycD60sam4YxR+lmOBmbFwNSBCKaTrkT31fBSakfGAm8nNZNlkaZuL62J8RI+AStGRrXIw==;EndpointSuffix=core.windows.net";
            //        try
            //        {
            //            UploadBlob(conStr, attendJsonStr, "tempcontainer", true);                   //This method takes the connection
            //                                                                                        //string, file content(reservation data), container name, and a boolean flag
            //                                                                                        //indicating whether to append the content or not.
            //            ViewBag.MessageToScreen = "EmployeeDetails Updated to Blob :" + attendJsonStr;
            //        }
            //        catch (Exception ex)
            //        {
            //            return StatusCode(500, "Failed to update blob: " + ex.Message);
            //        }

            //        return Ok("Uploaded to Blob");
            //    }
            //    catch
            //    {
            //        return Ok("Created");
            //    }
            //}
            //private static string UploadBlob(string conStr, string fileContent, string containerName, bool isAppend = false)
            //{
            //    /// <summary>
            //    /// This method is to upload to the blob
            //    /// </summary>
            //    /// 

            //    string result = "Success";
            //    try
            //    {
            //        //string containerName = "sample1";
            //        string fileName, existingContent;
            //        BlobClient blobClient;
            //        SetVariables(conStr, containerName, out fileName, out existingContent, out blobClient);

            //        if (isAppend)
            //        {
            //            string fillerStart = "";
            //            string fillerEnd = "]";
            //            existingContent = GetContentFromBlob(conStr, fileName, containerName);

            //            if (string.IsNullOrEmpty(existingContent.Trim()))
            //            {
            //                fillerStart = "[";
            //                fileContent = fillerStart + existingContent + fileContent + fillerEnd;

            //            }
            //            else
            //            {
            //                existingContent = existingContent.Substring(0, existingContent.Length - 3);
            //                fileContent = fillerStart + existingContent + "," + fileContent + fillerEnd;
            //            }
            //        }

            //        var ms = new MemoryStream();
            //        TextWriter tw = new StreamWriter(ms);
            //        tw.Write(fileContent);
            //        tw.Flush();
            //        ms.Position = 0;

            //        try
            //        {
            //            blobClient.UploadAsync(ms, true);

            //        }
            //        catch (Exception ex)
            //        {

            //            throw ex;
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        result = "Failed";
            //        throw ex;
            //    }
            //    return result;
            //}

            //private static void SetVariables(string conStr, string containerName, out string fileName, out string existingContent, out BlobClient blobClient)
            //{
            //    ///<summary>
            //    ///  Setting the file name
            //    ///</summary>

            //    var serviceClient = new BlobServiceClient(conStr);
            //    var containerClient = serviceClient.GetBlobContainerClient(containerName);

            //    fileName = "EmployeeData.txt";
            //    existingContent = "";
            //    blobClient = containerClient.GetBlobClient(fileName);
            //}

            //private static string GetContentFromBlob(string conStr, string fileName, string containerName)
            //{
            //    ///<summary>
            //    ///Reading Data from blob
            //    ///</summary> 

            //    BlobServiceClient blobServiceClient = new BlobServiceClient(conStr);
            //    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            //    BlobClient blobClient = containerClient.GetBlobClient(fileName);
            //    string line = string.Empty;
            //    if (blobClient.Exists())
            //    {
            //        var response = blobClient.Download();
            //        using (var streamReader = new StreamReader(response.Value.Content))
            //        {
            //            while (!streamReader.EndOfStream)
            //            {
            //                line += streamReader.ReadLine() + Environment.NewLine;
            //            }
            //        }
            //    }
            //    return line;
            //}



            //try
            //{
            //    string result = _employeeService.UploadEmployeeDetails(employee);
            //    return Ok(result);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, $"Failed to upload employee details: {ex.Message}");
            //}

            try
            {
                var obj = new { status = "Inserted" };

                // Check if model state is valid
                if (!ModelState.IsValid)
                {
                    // Model validation failed, return ModelState errors
                    return BadRequest(ModelState);
                }

                // Add employee
                bool status = _employeeService.AddEmployee(employee);
                if (!status)
                {
                    // If adding employee failed, return 400 Bad Request with an error message
                    return BadRequest("Failed to insert employee records");
                }

                // Return 200 OK with success message
                return Ok(obj);
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error 
                return StatusCode(500, "An error occurred while processing the request. EmpId already exists.");
            }
        
    }


        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                // Attempt to retrieve all employees
                var result = _employeeService.GetAllEmployees();

                // If employees are found, return them with 200 OK status
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    // If no employees are found, return 404 Not Found status
                    return NotFound("No employees found");
                }
            }
            catch (Exception ex)
            {
                // If an unexpected error occurs, return 500 Internal Server Error status
                return StatusCode(500, "An error occurred while processing the request");
            }
        }


        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                // Attempt to retrieve the employee by ID
                Employee employee = _employeeService.GetEmployeeById(id);

                // If employee is found, return it with 200 OK status
                if (employee != null)
                {
                    return Ok(employee);
                }
                else
                {
                    // If employee is not found, return 404 Not Found status
                    return NotFound("Employee not found");
                }
            }
            catch (Exception ex)
            {
                // If an unexpected error occurs, return 500 Internal Server Error status
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                var obj = new { status = "Updated" };
                bool status = _employeeService.UpdateEmployee(employee);
                // Check if the update was successful
                if (status)
                {
                    // Return 200 OK with a success message
                    return Ok(obj);
                }
                else
                {
                    // If the update failed, return 400 Bad Request
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with a generic error message
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var obj = new { status = "Deleted" };
                bool status = _employeeService.DeleteEmployee(id);
                if (status)
                {
                    // Return 200 OK with a success message
                    return Ok(obj);
                }
                else
                {
                    // If the event was not found, return 404 Not Found
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with a generic error message
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpGet("Search")]
        public IActionResult GetSearchResults(string field, string value)
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(value))
            {
                return BadRequest("Search Field and value cannot be empty");
            }
            var searchoutput = _employeeService.SearchEmployees(field, value);
            if (searchoutput.Count == 0)
            {
                return NotFound();
            }

            return Ok(searchoutput);
        }

        //[HttpGet("export-csv")]
        //public IActionResult ExportToCsv(string field, string value)
        //{
        //    // Search for employees based on the specified field and value
        //    var results = _employeeService.SearchEmployees(field, value);

        //    // Create a memory stream to write CSV data
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var streamWriter = new StreamWriter(memoryStream))
        //        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        //        {
        //            // Write CSV header
        //            csvWriter.WriteHeader<Employee>();
        //            csvWriter.NextRecord();

        //            // Write each employee to the CSV file
        //            csvWriter.WriteRecords(results);
        //        }

        //        // Set the position of the memory stream to the beginning
        //        memoryStream.Position = 0;

        //        // Return the CSV file as a FileStreamResult
        //        return File(memoryStream, "text/csv", "search_results.csv");
        //    }
        //}

    }
}
