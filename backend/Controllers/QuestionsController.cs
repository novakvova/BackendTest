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
        [HttpGet("{quizId}")]
        public IEnumerable<Models.Question> Get([FromRoute]int quizId)
        {
            return _context.Questions.Where(q=>q.QuizId==quizId);
        }
        //POST api/questions
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Question question)
        {
            var quiz = _context.Quizzes.SingleOrDefault(q => q.ID == question.QuizId);
            if (quiz == null)
                return NotFound();
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