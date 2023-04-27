using DAL;
using DAL.Models;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerapiController : ControllerBase
    {
        public CustomerService cservice;
        private IConfiguration _config;
        public CustomerapiController(IConfiguration cs,CustomerService c)
        {
            _config = cs;
            cservice = c;
        }
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            IEnumerable<Customer>? clist;
            try
            {
                clist = cservice.GetCustomer();
                return Ok(clist);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        private string GenerateToken(Customer user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.CustomerName.ToString()),
                new Claim(ClaimTypes.Email,user.CustomerEmail.ToString()),
                new Claim(ClaimTypes.StreetAddress,user.CustomerAddress.ToString()),
                new Claim(ClaimTypes.DateOfBirth,user.CustomerDob.ToString()),
               // new Claim(ClaimTypes.MobilePhone,user.CustomerContact.ToString())

            };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> GetCustomerById([FromQuery] Customer c)
        {
            /*
            Customer c;
            try
            {
                c = cservice.GetCustomerById(CustomerId);
                return Ok(c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            */
            try
            {
                List<Customer> _custlist = cservice.GetCustomer().ToList();
                foreach (Customer l in _custlist)
                {
                    if (l.CustomerName.Equals(c.CustomerName) && l.CustomerEmail.Equals(c.CustomerEmail) && l.CustomerAddress.Equals(c.CustomerAddress))//&& l.CustomerDob.Equals(c.CustomerDob))
                    {
                        var token = GenerateToken(c);
                        return Ok(token);
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return BadRequest("Invalid Request");
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer? UpdCustomer)
        {
            Customer? UpdCustomers;
            try
            {
                UpdCustomer = cservice.UpdateCustomer(UpdCustomer);
                return Ok(UpdCustomer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(Customer c)
        {
            try
            {
                var cust = await cservice.AddCustomer(c);
                return CreatedAtAction(nameof(GetCustomerById), new { id = c.CustomerId, controller = "Customer" }, c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            //return Ok(c);

        }
        [HttpDelete("Delete/{CustomerId}")]
        public async Task<IActionResult> Delete([FromRoute] int CustomerId)
        {
            try
            {
                var admid = cservice.RemoveCustomer(CustomerId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
