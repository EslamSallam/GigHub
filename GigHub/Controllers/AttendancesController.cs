using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromUri] int GiId)
        {
            string UserId = "cd173de5-0724-4800-b784-ac326f1db37c";
            if (_context.Attendances.Any(g => g.GigId == GiId && g.AttendeeId == UserId))
            {
                return BadRequest("The attendance already exists");
            }
            var attendance_ = new Attendance 
            { 
                GigId = GiId,
                AttendeeId = UserId
            };
            _context.Attendances.Add(attendance_);
            _context.SaveChanges();

            return Ok("Success");
        }

    }
}
