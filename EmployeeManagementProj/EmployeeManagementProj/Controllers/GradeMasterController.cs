using Business.Services;
using EmployeeEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeMasterController : ControllerBase
    {
        private readonly GradeMasterService _gradeMasterService;

        public GradeMasterController(GradeMasterService gradeMasterService)
        {
            _gradeMasterService = gradeMasterService;
        }
        [HttpPost] // Method attribute
        public IActionResult AddGrades(GradeMaster grades) // IActionResult will accept any return type like JSON, object, XML
        {
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
                bool status = _gradeMasterService.AddGrades(grades);
                if (!status)
                {
                    // If adding employee failed, return 400 Bad Request with an error message
                    return BadRequest("Failed to insert new Grade");
                }

                // Return 200 OK with success message
                return Ok(obj);
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error 
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpGet("GetAllGrades")]
        public IActionResult GetAllGrades()
        {
            try
            {
                // Attempt to retrieve all employees
                var result = _gradeMasterService.GetAllGrades();

                // If employees are found, return them with 200 OK status
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    // If no employees are found, return 404 Not Found status
                    return NotFound("No record found");
                }
            }
            catch (Exception ex)
            {
                // If an unexpected error occurs, return 500 Internal Server Error status
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpGet("GetGradesById")]
        public IActionResult GetGradesById(string gradecode)
        {
            try
            {
                // Attempt to retrieve the grade by ID
                GradeMaster grade = _gradeMasterService.GetGradesById(gradecode);
                    

                // If employee is found, return it with 200 OK status
                if (grade != null)
                {
                    return Ok(grade);
                }
                else
                {
                    // If employee is not found, return 404 Not Found status
                    return NotFound("Grade record not found");
                }
            }
            catch (Exception ex)
            {
                // If an unexpected error occurs, return 500 Internal Server Error status
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpPut]
        public IActionResult UpdateGrade(GradeMaster grade)
        {
            try
            {
                var obj = new { status = "Updated" };
                bool status = _gradeMasterService.UpdateGrades(grade);
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
        public IActionResult DeleteEmployee(string gradecode)
        {
            try
            {
                var obj = new { status = "Deleted" };
                bool status = _gradeMasterService.DeleteGrades(gradecode);  
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

    }
}
