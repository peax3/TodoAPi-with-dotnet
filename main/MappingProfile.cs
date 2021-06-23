using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Main
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         CreateMap<Todo, TodoDto>();
         CreateMap<TodoForCreationDto, Todo>();
         CreateMap<TodoForUpdateDto, Todo>();
      }
   }
}
