using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Repositorio;


namespace TodoApi.Controllers{
    
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriaController : Controller {
       private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categRepo)
        {   
            _categoriaRepositorio = categRepo;
        }

        [HttpGet]
        public ActionResult<RetornoView<Categoria>> GetAll(){
            var resultado = new RetornoView<Categoria>(){dados = _categoriaRepositorio.GetAll()}; 
        return resultado;
        }   

        [HttpGet("{Id}")]
        public ActionResult<Categoria> GetById(int Id){
            var itens = _categoriaRepositorio.Find(Id);
            if(itens == null){
                return NotFound();
            }
            return itens;
        }
         
        [HttpPost]
        public ActionResult<RetornoView<Categoria>> Create([FromBody] Categoria categoria){
            if (categoria == null){
                return BadRequest();
            }
            _categoriaRepositorio.Add(categoria);
            var result = new RetornoView<Categoria>(){dado=categoria,sucesso = true};
            return result;
            //return CreatedAtRoute("GetUsuario", new {id=usuario.UsuarioId}, usuario);
        }

         [HttpPut("{Id}")]
         public ActionResult<RetornoView<Categoria>> Update(int Id, Categoria categoria){
            var todo = _categoriaRepositorio.Find(Id);
            if (todo == null){
                return NotFound();
            }
            
            todo.Descricao = categoria.Descricao;

           _categoriaRepositorio.Update(todo);
           var resultado = new RetornoView<Categoria>(){sucesso = true};
            return resultado;
           
          
        }

        [HttpDelete("{id}")]
        public ActionResult<RetornoView<Categoria>> Delete(int id){
            var usuario = _categoriaRepositorio.Find(id);
            if(usuario==null){
                return NotFound();
            }
            _categoriaRepositorio.Remove(id);
            var result = new RetornoView<Categoria>(){sucesso = true};
            return result;
        }
    }
}