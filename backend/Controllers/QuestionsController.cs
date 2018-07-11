using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public void Post([FromBody]Models.Question question)
        {
            _context.Questions.
                Add(question);
            _context.SaveChanges();

        }
    }
}