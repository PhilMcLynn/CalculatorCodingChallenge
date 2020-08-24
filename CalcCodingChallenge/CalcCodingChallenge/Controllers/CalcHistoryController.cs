using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CalcCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalcCodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcHistoryController : ControllerBase
    {
        private readonly CalcHistoryContext _context;

        public CalcHistoryController(CalcHistoryContext context)
        {
            _context = context;
        }

        // GET: api/CalcHistories
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CalcHistory>>> GetCalcHistories()
        {
            return await _context.CalcHistories.ToListAsync();
        }

        // GET: api/CalcHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalcHistory>> GetCalcHistory(int id)
        {
            var calcHistory = await _context.CalcHistories.FindAsync(id);

            if (calcHistory == null)
            {
                return NotFound();
            }

            return calcHistory;
        }

        // POST api/<CalcHistoryController>
        [HttpPost]
        public async Task<ActionResult<CalcHistory>> CalculateFromText( CalcHistory calcHistory)
        {
            calcHistory.SourceIPAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            calcHistory.CalcTime = DateTime.Now;
            DataTable dt = new DataTable();
            try
            {
                var y = dt.Compute(calcHistory.CalcText, "");
                calcHistory.CalcTextAnswer = y.ToString();
            }
            catch
            {
                calcHistory.CalcTextAnswer = "Failed to evaluate the calculation!";
            }
            _context.CalcHistories.Add(calcHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalcHistory", new { id = calcHistory.CalcHistoryId}, calcHistory);

        }
    }
}
