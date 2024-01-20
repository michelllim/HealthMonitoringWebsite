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
    public class DiagnosissController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext_context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public DiagnosissController(ApplicationDbContextcontext)
        public DiagnosissController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context
            _unitOfWork = unitOfWork;
        }


        // GET: api/Diagnosiss
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Diagnosis>>>GetDiagnosiss()
        public async Task<IActionResult> GetDiagnosiss()
        {
            //Refactored
            //return await _context.Diagnosiss.ToListAsync();
            var diagnosiss = await _unitOfWork.Diagnosiss.GetAll();
            return Ok(diagnosiss);
        }

        // GET: api/Diagnosiss/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Diagnosis>>GetDiagnosis(int id)
        public async Task<IActionResult> GetDiagnosis(int id)
        {
            //Refactored
            //var diagnosis = await _context.Diagnosiss.FindAsync(id);
            var diagnosis = await _unitOfWork.Diagnosiss.Get(q => q.Id == id);

            if (diagnosis == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(diagnosis);
        }

        // PUT: api/Diagnosiss/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnosis(int id, Diagnosis diagnosis)
        {
            if (id != diagnosis.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(diagnosis).State = EntityState.Modified;
            _unitOfWork.Diagnosiss.Update(diagnosis);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!DiagnosisExists(id))
                if (!await DiagnosisExists(id))
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

        // POST: api/Diagnosiss
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diagnosis>> PostDiagnosis(Diagnosis diagnosis)
        {
            //Refactored
            //if (_context.Diagnosiss == null)
            if (_unitOfWork.Diagnosiss == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Diagnosiss'  is null.");
            }
            //_context.Diagnosiss.Add(diagnosis);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Diagnosiss.Insert(diagnosis);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetDiagnosis", new { id = diagnosis.Id }, diagnosis);
        }

        // DELETE: api/Diagnosiss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosis(int id)
        {
            //Refactored
            //if (_context.Diagnosiss == null)
            if (_unitOfWork.Diagnosiss == null)
            {
                return NotFound();
            }

            //Refactored
            //var diagnosis = await _context.Diagnosiss.FindAsync(id);
            var diagnosis = await _unitOfWork.Diagnosiss.Get(q => q.Id == id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Diagnosiss.Remove(diagnosis);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Diagnosiss.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool DiagnosisExists(int id)
        private async Task<bool> DiagnosisExists(int id)
        {
            //Refactored
            //return _context.Diagnosiss.Any(e => e.Id == id);
            var diagnosis = await _unitOfWork.Diagnosiss.Get(q => q.Id == id);
            return diagnosis != null;
        }
    }
}