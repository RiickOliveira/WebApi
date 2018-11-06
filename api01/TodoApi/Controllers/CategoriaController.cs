using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;


namespace TodoApi.Controllers{
    
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriaController : ControllerBase {
        private readonly TodoContext _context;

        public CategoriaController(TodoContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<RetornoView<Categoria>> GetAll(){
            var resultado = new RetornoView<Categoria>(){dados = _context.Categorias.ToList()}; 
        return resultado;
        }   

        [HttpGet("{Id}")]
        public ActionResult<Categoria> GetById(long Id){
            var itens = _context.Categorias.Find(Id);
            if(itens == null){
                return NotFound();
            }
            return itens;
        }
         
        [HttpPost]
        public IActionResult Create(Categoria categorias){
            _context.Categorias.Add(categorias);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new {id = categorias.Id}, categorias);
        }    

         [HttpPut("{Id}")]
        public IActionResult Update(long Id, Categoria categoria){
            var todo = _context.Categorias.Find(Id);
            if (todo == null){
                return NotFound();
            }
            
            todo.Descricao = categoria.Descricao;

            _context.Categorias.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id){
            var todo = _context.Categorias.Find(Id);
            if (todo == null){
                return NotFound();
            }
            _context.Categorias.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        } 
    }
}