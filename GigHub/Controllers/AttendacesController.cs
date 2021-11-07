using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class AttendacesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendacesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddAttendance([FromBody] int GigId_)
        {
            var attendance_ = new Attendance 
            { 
                GigId = GigId_,
                AttendeeId = User.Identity.GetUserId()
            };
            _context.Attendances.Add(attendance_);
            _context.SaveChanges();

            return Ok();
        }

    }
}
