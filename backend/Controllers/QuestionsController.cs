using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        private readonly QuizeContext _context;
        public QuestionsController(QuizeContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IEnumerable<Models.Question> Get()
        {
            return _context.Questions;
        }
        //POST api/questions
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Question question)
        {
            _context.Questions.
                Add(question);
            await _context.SaveChangesAsync();
            return Ok(question);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Models.Question question)
        {
            if (id != question.ID)
                return BadRequest();
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(question);
        }
    }
}