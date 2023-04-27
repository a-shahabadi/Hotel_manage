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
    public class AdminapiController : ControllerBase
    {
        public AdminService aservice;
        private IConfiguration _config;
        public AdminapiController(IConfiguration cs, AdminService a)
        {
            _config = cs;
            aservice = a;
        }
        [HttpGet("GetAdmin")]  
        public async Task<IActionResult>GetAdmin()
        {
            IEnumerable<Admin>?  alist;
            try
            {
                alist = aservice.GetAdmin();
                return Ok(alist);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        private string GenerateToken(Admin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.AdminName.ToString()),
                new Claim(ClaimTypes.Name,user.Password.ToString()),
                //new Claim(ClaimTypes.Role,user.AdminType.ToString())

            };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        [HttpPost("authenticate")]
        public async Task<IActionResult>GetAdminById([FromQuery] Admin a)
        {
            try
            {
                List<Admin> _adminlist = aservice.GetAdmin().ToList();
                foreach (Admin l in _adminlist)
                {
                    if (l.AdminName.Equals(a.AdminName) && l.Password.Equals(a.Password))
                    {
                        var token = GenerateToken(a);
                        return Ok(token);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Bad Request");

        }
        [HttpPut]
        [Route("UpdateAdmin")]
        public IActionResult UpdateAdmin(Admin? UpdAdmin)
        {
            Admin? UpdAdmins;
            try
            {
                UpdAdmin = aservice.UpdateAdmin(UpdAdmin);
                return Ok(UpdAdmin);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("AddAdmin")]
        public async Task<IActionResult>addAdmin([FromQuery] Admin a)
        {
            try
            {
                List<Admin> _adminlist = aservice.GetAdmin().ToList();
                var adm = await aservice.AddAdmin(a);
                return CreatedAtAction(nameof(GetAdminById), new { id = a.AdminId, controller = "Admin" }, a);
            }
            
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        
        [HttpDelete("Delete/{AdminId}")]
        public async Task<IActionResult> Delete([FromRoute] int AdminId)
        {
            try
            {
                var admid = aservice.RemoveAdmin(AdminId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
