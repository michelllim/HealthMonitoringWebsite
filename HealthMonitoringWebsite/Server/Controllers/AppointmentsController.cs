using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthMonitoringWebsite.Server.Data;
using HealthMonitoringWebsite.Shared.Domain;
using HealthMonitoringWebsite.Server.IRepository;

namespace HealthMonitoringWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext_context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public AppointmentsController(ApplicationDbContextcontext)
        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context
            _unitOfWork = unitOfWork;
        }


        // GET: api/Appointments
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Appointment>>>GetAppointments()
        public async Task<IActionResult> GetAppointments()
        {
            //Refactored
            //return await _context.Appointments.ToListAsync();
            var appointments = await _unitOfWork.Appointments.GetAll();
            return Ok(appointments);
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Appointment>>GetAppointment(int id)
        public async Task<IActionResult> GetAppointment(int id)
        {
            //Refactored
            //var appointment = await _context.Appointments.FindAsync(id);
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(appointment);
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(appointment).State = EntityState.Modified;
            _unitOfWork.Appointments.Update(appointment);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!AppointmentExists(id))
                if (!await AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            //Refactored
            //if (_context.Appointments == null)
            if (_unitOfWork.Appointments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Appointments'  is null.");
            }
            //_context.Appointments.Add(appointment);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Appointments.Insert(appointment);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            //Refactored
            //if (_context.Appointments == null)
            if (_unitOfWork.Appointments == null)
            {
                return NotFound();
            }

            //Refactored
            //var appointment = await _context.Appointments.FindAsync(id);
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Appointments.Remove(appointment);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Appointments.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool AppointmentExists(int id)
        private async Task<bool> AppointmentExists(int id)
        {
            //Refactored
            //return _context.Appointments.Any(e => e.Id == id);
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);
            return appointment != null;
        }
    }
}