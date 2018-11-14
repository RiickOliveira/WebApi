using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Repositorio;


namespace TodoApi.Controllers{
    
    [Route("api/[controller]")]
    [ApiController]

    public class ReceitaDespesaController : ControllerBase{

        private readonly IRecDesRepositorio _recDesRepositorio;
        public ReceitaDespesaController(IRecDesRepositorio recDesRepo)
        {   
            _recDesRepositorio = recDesRepo;
        }

        [HttpGet]
        public ActionResult<RetornoView<ReceitaDespesa>> GetAll(){
            var resultado = new RetornoView<ReceitaDespesa>(){dados = _recDesRepositorio.GetAll()}; 
        return resultado;
        }

        [HttpGet("{Id}")]
        public ActionResult<ReceitaDespesa> GetById(int Id){
            var itens = _recDesRepositorio.Find(Id);
            if(itens == null){
                return NotFound();
            }
            return itens;
        }

        [HttpPost]
        public ActionResult<RetornoView<ReceitaDespesa>> Create([FromBody] ReceitaDespesa recDes){
            if (recDes == null){
                return BadRequest();
            }
            _recDesRepositorio.Add(recDes);
            var result = new RetornoView<ReceitaDespesa>(){dado=recDes,sucesso = true};
            return result;
            //return CreatedAtRoute("GetUsuario", new {id=usuario.UsuarioId}, usuario);
        }

         [HttpPut("{Id}")]
        public ActionResult<RetornoView<ReceitaDespesa>> Update(int Id, ReceitaDespesa recDes){
            var todo = _recDesRepositorio.Find(Id);
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

            _recDesRepositorio.Update(todo);
            var resultado = new RetornoView<ReceitaDespesa>(){sucesso = true};
            return resultado;
        }

       [HttpDelete("{id}")]
        public ActionResult<RetornoView<ReceitaDespesa>> Delete(int id){
            var usuario = _recDesRepositorio.Find(id);
            if(usuario==null){
                return NotFound();
            }
            _recDesRepositorio.Remove(id);
            var result = new RetornoView<ReceitaDespesa>(){sucesso = true};
            return result;
        }
    }
}