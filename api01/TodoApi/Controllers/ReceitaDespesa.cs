using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;


namespace TodoApi.Controllers{
    
    [Route("api/[controller]")]
    [ApiController]

    public class ReceitaDespesaController : ControllerBase{

        private readonly TodoContext _context;

        public ReceitaDespesaController(TodoContext context){
            _context = context;            
        }

        [HttpGet]
        public ActionResult<RetornoView<ReceitaDespesa>> GetAll(){
            var resultado = new RetornoView<ReceitaDespesa>(){dados = _context.ReceitasDespesas.ToList()}; 
        return resultado;
        }

        [HttpGet("{Id}")]
        public ActionResult<ReceitaDespesa> GetById(long Id){
            var itens = _context.ReceitasDespesas.Find(Id);
            if(itens == null){
                return NotFound();
            }
            return itens;
        }

        [HttpPost]
        public IActionResult Create(ReceitaDespesa recDes){
            _context.ReceitasDespesas.Add(recDes);
            
            if(recDes.Receita == false){
                recDes.DataBaixa = null;
            }
            _context.SaveChanges();


            return CreatedAtRoute("GetTodo", new {id = recDes.Id}, recDes);
        }

         [HttpPut("{Id}")]
        public IActionResult Update(long Id, ReceitaDespesa recDes){
            var todo = _context.ReceitasDespesas.Find(Id);
            if (todo == null){
                return NotFound();
            }
            todo.PessoaId = recDes.PessoaId;
            todo.CategoriaId = recDes.CategoriaId;
            todo.DataVenc = recDes.DataVenc;
            todo.Valor = recDes.Valor;
            todo.Historico = recDes.Historico;
            todo.Receita = recDes.Receita;
            todo.Baixado = recDes.Baixado;
            todo.DataBaixa = recDes.DataBaixa;

            _context.ReceitasDespesas.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id){
            var todo = _context.ReceitasDespesas.Find(Id);
            if (todo == null){
                return NotFound();
            }
            _context.ReceitasDespesas.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}