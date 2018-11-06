using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;


namespace TodoApi.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase {
        private readonly TodoContext _context;

        public PessoaController(TodoContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<RetornoView<Pessoa>> GetAll(){
            var resultado = new RetornoView<Pessoa>(){dados = _context.Pessoas.ToList()}; 
        return resultado;
        }
        
        [HttpGet("{Id}")]
        public ActionResult<Pessoa> GetById(long Id){
            var itens = _context.Pessoas.Find(Id);
            if(itens == null){
                return NotFound();
            }
            return itens;
        }

        [HttpPost]
        public IActionResult Create(Pessoa pessoas){
            _context.Pessoas.Add(pessoas);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new {id = pessoas.Id}, pessoas);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(long Id, Pessoa pessoa){
            var todo = _context.Pessoas.Find(Id);
            if (todo == null){
                return NotFound();
            }
            todo.Nome = pessoa.Nome;
            todo.Cidade = pessoa.Cidade;

            _context.Pessoas.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id){
            var todo = _context.Pessoas.Find(Id);
            if (todo == null){
                return NotFound();
            }
            _context.Pessoas.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}