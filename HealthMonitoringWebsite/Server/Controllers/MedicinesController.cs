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
    public class MedicinesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext_context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public MedicinesController(ApplicationDbContextcontext)
        public MedicinesController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context
            _unitOfWork = unitOfWork;
        }


        // GET: api/Medicines
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Medicine>>>GetMedicines()
        public async Task<IActionResult> GetMedicines()
        {
            //Refactored
            //return await _context.Medicines.ToListAsync();
            var medicines = await _unitOfWork.Medicines.GetAll();
            return Ok(medicines);
        }

        // GET: api/Medicines/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Medicine>>GetMedicine(int id)
        public async Task<IActionResult> GetMedicine(int id)
        {
            //Refactored
            //var medicine = await _context.Medicines.FindAsync(id);
            var medicine = await _unitOfWork.Medicines.Get(q => q.Id == id);

            if (medicine == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(medicine);
        }

        // PUT: api/Medicines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicine(int id, Medicine medicine)
        {
            if (id != medicine.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(medicine).State = EntityState.Modified;
            _unitOfWork.Medicines.Update(medicine);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!MedicineExists(id))
                if (!await MedicineExists(id))
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

        // POST: api/Medicines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {
            //Refactored
            //if (_context.Medicines == null)
            if (_unitOfWork.Medicines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Medicines'  is null.");
            }
            //_context.Medicines.Add(medicine);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Medicines.Insert(medicine);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMedicine", new { id = medicine.Id }, medicine);
        }

        // DELETE: api/Medicines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            //Refactored
            //if (_context.Medicines == null)
            if (_unitOfWork.Medicines == null)
            {
                return NotFound();
            }

            //Refactored
            //var medicine = await _context.Medicines.FindAsync(id);
            var medicine = await _unitOfWork.Medicines.Get(q => q.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Medicines.Remove(medicine);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Medicines.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool MedicineExists(int id)
        private async Task<bool> MedicineExists(int id)
        {
            //Refactored
            //return _context.Medicines.Any(e => e.Id == id);
            var medicine = await _unitOfWork.Medicines.Get(q => q.Id == id);
            return medicine != null;
        }
    }
}