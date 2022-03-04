using System.Collections.Generic;
using KeepMovinAPI.Models;
using KeepMovinAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using KeepMovinAPI.Domain;
using KeepMovinAPI.Domain.Dtos;

namespace KeepMovinAPI.DAOs
{
    public interface IEventDao : IDao<Event>
    {
        public IEnumerable<Event> GetByInput(string input);
        
        public IEnumerable<Event> GetFiltered([FromQuery] Filter filter);
         
        

    }
}