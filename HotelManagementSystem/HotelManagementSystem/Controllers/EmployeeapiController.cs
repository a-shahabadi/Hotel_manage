using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class EmployeeapiController : ControllerBase
    {
        public EmployeeService eservice;
        private IConfiguration _config;

        public EmployeeapiController(IConfiguration cs,EmployeeService e)
        {
            _config = cs;
            eservice = e;
        }
        private string GenerateToken(Employee1 user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.EmpName.ToString()),
                new Claim(ClaimTypes.Email,user.Emppass.ToString()),
                new Claim(ClaimTypes.SerialNumber,user.EmpId.ToString())

            };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
      
        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee()
        {
            IEnumerable<Employee1>? elist;
            try
            {
                elist = eservice.GetEmployee();
                return Ok(elist);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] Employee1 e)
        {
            /*Employee1 e;
            try
            {
                e = eservice.GetEmployeeById(EmpId);
                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }*/
            try
            {
                List<Employee1> _emplist = eservice.GetEmployee().ToList();
                foreach (Employee1 l in _emplist)
                {
                    if (l.EmpName.Equals(e.EmpName) && l.Emppass.Equals(e.Emppass))
                    {
                        var token = GenerateToken(e);
                        return Ok(token);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Invalid Request");
        }
        [HttpPut]
        [Route("UpdateRoom")]
        public IActionResult UpdateEmployee(Employee1? UpdEmployee)
        {
            Employee1? UpdEmployees;
            try
            {
                UpdEmployee = eservice.UpdateEmployee(UpdEmployee);
                return Ok(UpdEmployee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> addEmployee([FromQuery] Employee1 e)
        {
            try
            { 
            var emp = await eservice.AddEmployee(e);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = e.EmpId, controller = "Employee" }, e);
             }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("Delete/{EmpId}")]
        public async Task<IActionResult> Delete([FromRoute] int EmpId)
        {
            try
            {
                var empid = eservice.RemoveEmployee(EmpId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
