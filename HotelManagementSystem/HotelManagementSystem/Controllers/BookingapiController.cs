﻿using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingapiController : ControllerBase
    {
        public BookingService bservice;
        public BookingapiController(BookingService b)
        {
            bservice = b;
        }
        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee()
        {
            IEnumerable<Booking>? blist;
            try
            {
                blist = bservice.GetBooking();
               return Ok(blist);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetBookingId/{BookingId}")]
        public async Task<IActionResult> GetBookingById([FromRoute] int BookingId)
        {
            Booking b;
           try
            {
                b = bservice.GetBookingById(BookingId);
              return Ok(b);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("UpdateBooking")]
        public IActionResult UpdateBooking(Booking? UpdBooking)
        {
            Booking? UpdBookings;
            try
            {
                UpdBooking = bservice.UpdateBooking(UpdBooking);
                return Ok(UpdBooking);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AddBooking")]
        public async Task<IActionResult> addBooking([FromQuery] Booking b)
        {
            try
            {
                var bk = await bservice.AddBooking(b);
                return CreatedAtAction(nameof(GetBookingById), new { id = b.BookingId, controller = "Booking" }, b);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpDelete("Delete/{BookingId}")]
        public async Task<IActionResult> Delete([FromRoute] int BookingId)
        {
            try
            {
                var bkid = bservice.RemoveBooking(BookingId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
