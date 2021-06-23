using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Controllers
{
   [Route("api/todos")]
   [ApiController]
   public class TodoController : ControllerBase
   {
      private readonly ITodoRepository _todoRepository;
      private readonly IMapper _mapper;

      public TodoController(ITodoRepository todoRepository, IMapper mapper)
      {
         this._todoRepository = todoRepository;
         this._mapper = mapper;
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<Todo>>> GetAllTodos()
      {
         var todos = await _todoRepository.GetTodos();
         var todosDto = _mapper.Map<IEnumerable<TodoDto>>(todos);
         return Ok(todosDto);
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<Todo>> GetTodoById(Guid id)
      {

         var todo = (await _todoRepository.GetTodo(id));
         if (todo == null)
         {
            return NotFound();
         }

         var todoDto = _mapper.Map<TodoDto>(todo);

         return Ok(todoDto);

      }

      [HttpPost]
      public async Task<IActionResult> CreateTodo([FromBody] TodoForCreationDto todoInput)
      {
         if (todoInput == null)
         {
            return BadRequest("Todo sent is null");
         }

         if (!ModelState.IsValid)
         {
            return UnprocessableEntity(ModelState);
         }

         var todo = _mapper.Map<Todo>(todoInput);

         var newTodo = await _todoRepository.CreateTodo(todo);

         return Created(nameof(CreateTodo), newTodo);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteTodo(Guid id)
      {
         var todoToDelete = await _todoRepository.GetTodo(id);
         if (todoToDelete == null)
         {
            return NotFound();
         }

         await _todoRepository.DeleteTodo(id);
         return NoContent();
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] TodoForUpdateDto todoDtoFromBody)
      {
         if (todoDtoFromBody == null)
         {
            return BadRequest();
         }

         if (!ModelState.IsValid)
         {
            return UnprocessableEntity(ModelState);
         }

         var todoToUpdate = await _todoRepository.GetTodo(id);

         if (todoToUpdate == null)
         {
            return NotFound();
         }

         _mapper.Map(todoDtoFromBody, todoToUpdate);

         var updatedTodo = await _todoRepository.UpdateTodo(todoToUpdate);

         return Ok(updatedTodo);
      }
   }
}
