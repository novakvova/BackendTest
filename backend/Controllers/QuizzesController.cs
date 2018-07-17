using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Quizzes")]
    public class QuizzesController : Controller
    {
        private readonly QuizeContext _context;
        public QuizzesController(QuizeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Models.Quiz> Get()
        {
            return _context.Quizzes;
        }
        //POST api/questions
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Quiz quiz)
        {
            _context.Quizzes.
                Add(quiz);
            await _context.SaveChangesAsync();
            return Ok(quiz);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Models.Quiz quiz)
        {
            if (id != quiz.ID)
                return BadRequest();
            _context.Entry(quiz).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(quiz);
        }
    }
}