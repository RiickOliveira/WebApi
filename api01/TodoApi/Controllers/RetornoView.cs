using System.Collections.Generic;

namespace TodoApi.Controllers
{
    public class RetornoView<T>  where T: class
    {
        public  T dado {get; set;}
        public  IEnumerable<T> dados {get; set;}
        public bool sucesso {get; set;} 
    }


}