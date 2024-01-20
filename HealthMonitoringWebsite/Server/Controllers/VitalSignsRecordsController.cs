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
    public class VitalSignsRecordsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext_context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public VitalSignsRecordsController(ApplicationDbContextcontext)
        public VitalSignsRecordsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context
            _unitOfWork = unitOfWork;
        }


        // GET: api/VitalSignsRecords
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<VitalSignsRecord>>>GetVitalSignsRecords()
        public async Task<IActionResult> GetVitalSignsRecords()
        {
            //Refactored
            //return await _context.VitalSignsRecords.ToListAsync();
            var vitalsignsrecords = await _unitOfWork.VitalSignsRecords.GetAll();
            return Ok(vitalsignsrecords);
        }

        // GET: api/VitalSignsRecords/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<VitalSignsRecord>>GetVitalSignsRecord(int id)
        public async Task<IActionResult> GetVitalSignsRecord(int id)
        {
            //Refactored
            //var vitalsignsrecord = await _context.VitalSignsRecords.FindAsync(id);
            var vitalsignsrecord = await _unitOfWork.VitalSignsRecords.Get(q => q.Id == id);

            if (vitalsignsrecord == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(vitalsignsrecord);
        }

        // PUT: api/VitalSignsRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVitalSignsRecord(int id, VitalSignsRecord vitalsignsrecord)
        {
            if (id != vitalsignsrecord.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(vitalsignsrecord).State = EntityState.Modified;
            _unitOfWork.VitalSignsRecords.Update(vitalsignsrecord);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!VitalSignsRecordExists(id))
                if (!await VitalSignsRecordExists(id))
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

        // POST: api/VitalSignsRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VitalSignsRecord>> PostVitalSignsRecord(VitalSignsRecord vitalsignsrecord)
        {
            //Refactored
            //if (_context.VitalSignsRecords == null)
            if (_unitOfWork.VitalSignsRecords == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VitalSignsRecords'  is null.");
            }
            //_context.VitalSignsRecords.Add(vitalsignsrecord);
            //await _context.SaveChangesAsync();
            await _unitOfWork.VitalSignsRecords.Insert(vitalsignsrecord);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVitalSignsRecord", new { id = vitalsignsrecord.Id }, vitalsignsrecord);
        }

        // DELETE: api/VitalSignsRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitalSignsRecord(int id)
        {
            //Refactored
            //if (_context.VitalSignsRecords == null)
            if (_unitOfWork.VitalSignsRecords == null)
            {
                return NotFound();
            }

            //Refactored
            //var vitalsignsrecord = await _context.VitalSignsRecords.FindAsync(id);
            var vitalsignsrecord = await _unitOfWork.VitalSignsRecords.Get(q => q.Id == id);
            if (vitalsignsrecord == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.VitalSignsRecords.Remove(vitalsignsrecord);
            //await _context.SaveChangesAsync();
            await _unitOfWork.VitalSignsRecords.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool VitalSignsRecordExists(int id)
        private async Task<bool> VitalSignsRecordExists(int id)
        {
            //Refactored
            //return _context.VitalSignsRecords.Any(e => e.Id == id);
            var vitalsignsrecord = await _unitOfWork.VitalSignsRecords.Get(q => q.Id == id);
            return vitalsignsrecord != null;
        }
    }
}