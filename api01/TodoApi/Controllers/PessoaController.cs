using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Repositorio;


namespace TodoApi.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        public PessoaController(IPessoaRepositorio pessoaRepo)
        {   
            _pessoaRepositorio = pessoaRepo;
        }

        [HttpGet]
        public ActionResult<RetornoView<Pessoa>> GetAll(){
            var resultado = new RetornoView<Pessoa>(){dados = _pessoaRepositorio.GetAll()}; 
            return resultado;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Pessoa> GetById(int id){
            var itens = _pessoaRepositorio.Find(id);
            if(itens == null){
                return NotFound();
            }
            return itens;
        }

        [HttpPost]
        public ActionResult<RetornoView<Pessoa>> Create([FromBody] Pessoa pessoa){
            if (pessoa == null){
                return BadRequest();
            }
            _pessoaRepositorio.Add(pessoa);
            var result = new RetornoView<Pessoa>(){dado=pessoa,sucesso = true};
            return result;
            //return CreatedAtRoute("GetUsuario", new {id=usuario.UsuarioId}, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult<RetornoView<Pessoa>> Update(int id, Pessoa pessoa){
            var todo = _pessoaRepositorio.Find(id);
            if (todo == null){
                return NotFound();
            }
            todo.Nome = pessoa.Nome;
            todo.Cidade = pessoa.Cidade;

           _pessoaRepositorio.Update(todo);
            var resultado = new RetornoView<Pessoa>(){sucesso = true};
            return resultado;
        }

        [HttpDelete("{id}")]
        public ActionResult<RetornoView<Pessoa>> Delete(int id){
            var usuario = _pessoaRepositorio.Find(id);
            if(usuario==null){
                return NotFound();
            }
            _pessoaRepositorio.Remove(id);
            var result = new RetornoView<Pessoa>(){sucesso = true};
            return result;
        }
    }
}