using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
   public class TodoRepository : ITodoRepository
   {
      private readonly RepositoryContext _repositoryContext;

      public TodoRepository(RepositoryContext repositoryContext)
      {
         this._repositoryContext = repositoryContext;
      }

      public async Task<Todo> CreateTodo(Todo todo)
      {
         _repositoryContext.Todos.Add(todo);
         await _repositoryContext.SaveChangesAsync();
         return todo;
      }

      public async Task DeleteTodo(Guid id)
      {
         var todoToDelete = await _repositoryContext.Todos.FindAsync(id);
         _repositoryContext.Todos.Remove(todoToDelete);
         await _repositoryContext.SaveChangesAsync();
      }

      public async Task<Todo> GetTodo(Guid id)
      {
         var todo = await _repositoryContext.Todos.FindAsync(id);
         return todo;
      }

      public async Task<IEnumerable<Todo>> GetTodos()
      {
         return await _repositoryContext.Todos.ToListAsync();
      }

      public async Task<Todo> UpdateTodo(Todo todo)
      {
         _repositoryContext.Entry<Todo>(todo).State = EntityState.Modified;
         await _repositoryContext.SaveChangesAsync();

         return todo;
      }
   }
}
