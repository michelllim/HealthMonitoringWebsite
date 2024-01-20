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
    public class PrescriptionItemsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext_context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public PrescriptionItemsController(ApplicationDbContextcontext)
        public PrescriptionItemsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context
            _unitOfWork = unitOfWork;
        }


        // GET: api/PrescriptionItems
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<PrescriptionItem>>>GetPrescriptionItems()
        public async Task<IActionResult> GetPrescriptionItems()
        {
            //Refactored
            //return await _context.PrescriptionItems.ToListAsync();
            var prescriptionitems = await _unitOfWork.PrescriptionItems.GetAll();
            return Ok(prescriptionitems);
        }

        // GET: api/PrescriptionItems/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<PrescriptionItem>>GetPrescriptionItem(int id)
        public async Task<IActionResult> GetPrescriptionItem(int id)
        {
            //Refactored
            //var prescriptionitem = await _context.PrescriptionItems.FindAsync(id);
            var prescriptionitem = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);

            if (prescriptionitem == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(prescriptionitem);
        }

        // PUT: api/PrescriptionItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescriptionItem(int id, PrescriptionItem prescriptionitem)
        {
            if (id != prescriptionitem.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(prescriptionitem).State = EntityState.Modified;
            _unitOfWork.PrescriptionItems.Update(prescriptionitem);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!PrescriptionItemExists(id))
                if (!await PrescriptionItemExists(id))
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

        // POST: api/PrescriptionItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrescriptionItem>> PostPrescriptionItem(PrescriptionItem prescriptionitem)
        {
            //Refactored
            //if (_context.PrescriptionItems == null)
            if (_unitOfWork.PrescriptionItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PrescriptionItems'  is null.");
            }
            //_context.PrescriptionItems.Add(prescriptionitem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.PrescriptionItems.Insert(prescriptionitem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPrescriptionItem", new { id = prescriptionitem.Id }, prescriptionitem);
        }

        // DELETE: api/PrescriptionItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptionItem(int id)
        {
            //Refactored
            //if (_context.PrescriptionItems == null)
            if (_unitOfWork.PrescriptionItems == null)
            {
                return NotFound();
            }

            //Refactored
            //var prescriptionitem = await _context.PrescriptionItems.FindAsync(id);
            var prescriptionitem = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);
            if (prescriptionitem == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.PrescriptionItems.Remove(prescriptionitem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.PrescriptionItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool PrescriptionItemExists(int id)
        private async Task<bool> PrescriptionItemExists(int id)
        {
            //Refactored
            //return _context.PrescriptionItems.Any(e => e.Id == id);
            var prescriptionitem = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);
            return prescriptionitem != null;
        }
    }
}