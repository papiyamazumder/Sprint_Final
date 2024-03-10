using Business.Services;
using EmployeeEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmployeeManagementProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //This controller will be used only for login purpose
    public class UserMasterController : ControllerBase
    {
        private readonly UserMasterService _userMasterService;

        public UserMasterController(UserMasterService userMasterService)
        {
            _userMasterService = userMasterService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestModel credentials)
        {
            // Perform authentication
            var user = _userMasterService.AuthenticateUser(credentials.userId, credentials.password, credentials.UserType);
            if (user == null)
            {
                return Unauthorized();
            }

            // Optionally, you can return additional information about the user upon successful login
            return Ok(user);
        }

        [HttpPost("create-user")]
        
        public IActionResult CreateUser(UserMaster credentials)
        {
            // Create regular user with provided credentials
            _userMasterService.CreateUser(credentials);

            return Ok("Regular user created successfully.");
        }


        [HttpGet("GetAllUserCredentials")]
        public IActionResult GetAllUserCredentials()
        {
            try
            {
                // Attempt to retrieve all user credentials
                var result = _userMasterService.GetAllUserCredentials();

                // If users are found, return them with 200 OK status
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

        [HttpGet("GetUserCredentialsById")]
        public IActionResult GetUserCredentialsByid(string id)
        {
            try
            {
                // Attempt to retrieve the employee by ID
                UserMaster userMaster = _userMasterService.GetUserCredentialsById(id);

                // If employee is found, return it with 200 OK status
                if (userMaster != null)
                {
                    return Ok(userMaster);
                }
                else
                {
                    // If employee is not found, return 404 Not Found status
                    return NotFound("User Credentials not found");
                }
            }
            catch (Exception ex)
            {
                // If an unexpected error occurs, return 500 Internal Server Error status
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        [HttpPut]
        public IActionResult UpdateCredentials(UserMaster user)
        {
            try
            {
                var obj = new { status = "Updated" };
                bool status = _userMasterService.UpdateUserCredentials(user);
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
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCredentials(string id)
        {
            try
            {
                var obj = new { status = "Deleted" };
                bool status = _userMasterService.DeleteUserCredentials(id);
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


public class LoginRequestModel
{
    public string userId { get; set; }
    public string password { get; set; }
    public string UserType { get; set; }
}