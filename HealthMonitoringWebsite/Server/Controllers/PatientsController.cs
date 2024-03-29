﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthMonitoringWebsite.Server.Data;
using HealthMonitoringWebsite.Shared.Domain;
using HealthMonitoringWebsite.Server.IRepository;
using HealthMonitoringWebsite.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace HealthMonitoringWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext_context;
        private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<ApplicationUser> _userManager;

		//Refactored
		//public PatientsController(ApplicationDbContextcontext)
		public PatientsController(IUnitOfWork unitOfWork)
            //, UserManager<ApplicationUser> userManager)
        {
            //Refactored
            //_context = context
            _unitOfWork = unitOfWork;
			//_userManager = userManager;
		}


        // GET: api/Patients
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Patient>>>GetPatients()
        public async Task<IActionResult> GetPatients()
        {
            //Refactored
            //return await _context.Patients.ToListAsync();
            var patients = await _unitOfWork.Patients.GetAll();
            return Ok(patients);
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Patient>>GetPatient(int id)
        public async Task<IActionResult> GetPatient(int id)
        {
            //Refactored
            //var patient = await _context.Patients.FindAsync(id);
            var patient = await _unitOfWork.Patients.Get(q => q.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(patient);
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(patient).State = EntityState.Modified;
            _unitOfWork.Patients.Update(patient);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!PatientExists(id))
                if (!await PatientExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            //Refactored
            //if (_context.Patients == null)
            if (_unitOfWork.Patients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Patients'  is null.");
            }
            //_context.Patients.Add(patient);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Patients.Insert(patient);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            //Refactored
            //if (_context.Patients == null)
            if (_unitOfWork.Patients == null)
            {
                return NotFound();
            }

            //Refactored
            //var patient = await _context.Patients.FindAsync(id);
            var patient = await _unitOfWork.Patients.Get(q => q.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Patients.Remove(patient);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Patients.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool PatientExists(int id)
        private async Task<bool> PatientExists(int id)
        {
            //Refactored
            //return _context.Patients.Any(e => e.Id == id);
            var patient = await _unitOfWork.Patients.Get(q => q.Id == id);
            return patient != null;
        }

		//[HttpGet("get-user-email")]
		//public async Task<ActionResult<string>> GetUserEmail()
		//{
		//	var userName = User.Identity.Name;
		//	var user = await _userManager.FindByNameAsync(userName);
		//	return user?.Email;
		//}

		[HttpGet("email")]
		public ActionResult<string> GetCurrentUserEmail()
		{
			// Assuming the email claim type is "email" or use ClaimTypes.Email
			var email = User?.Claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email)?.Value;

			if (string.IsNullOrEmpty(email))
			{
				return NotFound("Email not found.");
			}

			return Ok(email);
		}
	}
}