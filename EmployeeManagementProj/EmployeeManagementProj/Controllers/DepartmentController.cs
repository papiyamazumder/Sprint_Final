using Business.Services;
using EmployeeEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpPost] // Method attribute
        public IActionResult AddDepartment(Department department) // IActionResult will accept any return type like JSON, object, XML
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

                // Add department
                bool status = _departmentService.AddDepartment(department);
                if (!status)
                {
                    // If adding department failed, return 400 Bad Request with an error message
                    return BadRequest("Failed to insert department records");
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

        [HttpGet("GetAllDepartments")]
        public IActionResult GetAllDepartments()
        {
            try
            {
                // Attempt to retrieve all departments
                var result = _departmentService.GetAllDepartments();

                // If departments are found, return them with 200 OK status
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    // If no departments are found, return 404 Not Found status
                    return NotFound("No departments found");
                }
            }
            catch (Exception ex)
            {
                // If an unexpected error occurs, return 500 Internal Server Error status
                return StatusCode(500, "An error occurred while processing the request");
            }
        }


        [HttpGet("GetDepartmentById")]
        public IActionResult GetDepartment(int id)
        {
            try
            {
                // Attempt to retrieve the department by ID
                Department department = _departmentService.GetDepartmentById(id);

                // If department is found, return it with 200 OK status
                if (department != null)
                {
                    return Ok(department);
                }
                else
                {
                    // If department is not found, return 404 Not Found status
                    return NotFound("Department not found");
                }
            }
            catch (Exception ex)
            {
                // If an unexpected error occurs, return 500 Internal Server Error status
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpPut]
        public IActionResult UpdateDepartment(Department department)
        {
            try
            {
                var obj = new { status = "Updated" };
                bool status = _departmentService.UpdateDepartment(department);
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
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var obj = new { status = "Deleted" };
                bool status = _departmentService.DeleteDepartment(id);
                if (status)
                {
                    // Return 200 OK with a success message
                    return Ok(obj);
                }
                else
                {
                    // If the dept was not found, return 404 Not Found
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
