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
            return new Models.Question[]
            {
                new Models.Question { Text = "Собака" },
                new Models.Question { Text = "Дичка" }
            };
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