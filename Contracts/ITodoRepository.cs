using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface ITodoRepository
   {
      Task<Todo> CreateTodo(Todo todo);
      Task<IEnumerable<Todo>> GetTodos();
      Task<Todo> GetTodo(Guid id);
      Task DeleteTodo(Guid id);
      Task<Todo> UpdateTodo(Todo todo);
   }
}
