/* using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

/*Um controlador é usado para definir e agrupar um conjunto de ações. 
Uma ação (ou método de ação) é um método em um controlador que manipula 
solicitações. Os controladores agrupam ações semelhantes de forma lógica. 
Essa agregação de ações permite que conjuntos de regras comuns, como roteamento, 
cache e autorização, sejam aplicados em conjunto.
 As solicitações são mapeadas para ações por meio de roteamento.*/
/*
namespace TodoApi.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase {
        private readonly TodoContext _context;

        public TodoController(TodoContext context){
            _context = context;

            if(_context.TodoItems.Count() ==0){
                //cria um novo TodoItem 
                _context.TodoItems.Add(new TodoItem {Name = "Item 1"});
                _context.SaveChanges();
            }
        }
        /*O CODIGO ACIMA Define uma classe de controlador de API sem métodos.
        Cria um novo item de Tarefas pendentes quando TodoItems está vazio. 
         Você não poderá excluir todos os itens de Tarefas pendentes 
        porque o construtor cria um novo se TodoItems estiver vazio.
        
        [HttpGet]
        public ActionResult<RetornoView<TodoItem>> GetAll(){
            var resultado = new RetornoView<TodoItem>(){dados = _context.TodoItems.ToList()}; 
            return resultado;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(long id){
            var item = _context.TodoItems.Find(id);
            if(item == null){
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(TodoItem item){
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new {id = item.Id}, item);
        }
        //o codigo anterior é um metodo do httpPost. O MVC obtem o valor do item 
        //pendente no corpo da solicitacao HTTP 

        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoItem item){
            var todo = _context.TodoItems.Find(id);
            if (todo == null){
                return NotFound();
            }
            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            var todo = _context.TodoItems.Find(id);
            if (todo == null){
                return NotFound();
            }
            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
    


}
*/
