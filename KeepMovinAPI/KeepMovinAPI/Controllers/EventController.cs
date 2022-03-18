using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using KeepMovinAPI.Authentication;
using KeepMovinAPI.Repository;
using KeepMovinAPI.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using KeepMovinAPI.Domain.Dtos;
using KeepMovinAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KeepMovinAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private IEventDao _daoEvent;
        private readonly IMapper _mapper;
        private IValidation _validation;

        public EventController(ILogger<EventController> logger, IEventDao daoEvent,
            IMapper mapper,IValidation validation)
        {
            _logger = logger;
            _daoEvent = daoEvent;
            _mapper = mapper;
            _validation = validation;
        }

        [HttpGet("{id}")]
        public Event Get(Guid id)
        {
            try
            {
                Event eventModel = _daoEvent.Get(id);
                return eventModel;
            }
            catch (Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return null;
            }
            
        }


        [HttpGet("input/{input}")]
        public IEnumerable<EventCardDto> GetByInput(string input)
        {
            try
            {
                var listOfEvents = _daoEvent.GetByInput(input);
                return _mapper.Map<IEnumerable<EventCardDto>>(listOfEvents);
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return null;
            }
            
        }
        
        [HttpGet("user-events/{userId}")]
        public IEnumerable<Event> GetUserEvents(Guid userId)
        {
            var listOfUserEvents = _daoEvent.GetUserEventsByUserId(userId);
            return listOfUserEvents;
        }
        
        [HttpGet("events-user/upcoming")]
        public UserUpcomingEventsDto GetUserUpcomingEvents([FromHeader(Name = "etag")] string userId,
                                                        [FromHeader(Name = "currentPage")] string currentPage)
        {
            var listOfUserEvents = _daoEvent.GetUpcomingEventsById(Guid.Parse(userId), int.Parse(currentPage));
            return listOfUserEvents;
        }
        
        [HttpGet("events-user/previous")]
        public UserPreviousEventsDto GetUserPreviousEvents([FromHeader(Name = "etag")] string userId,
                                                        [FromHeader(Name = "currentPage")] string currentPage)
        {
            var listOfUserEvents = _daoEvent.GetPreviousEventsById(Guid.Parse(userId), int.Parse(currentPage));
            return listOfUserEvents;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetFilteredEvents([FromQuery] Filter filter)
        {
            try
            {
                var listOfEvents = _daoEvent.GetFiltered(filter);
                if (!listOfEvents.EventsFound.Any())
                {
                    return NoContent();
                }

                    // var mappedListOfEvents = _mapper.Map<IEnumerable<EventDto>>(listOfEvents);
                return Ok(listOfEvents);

            }
            catch (Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return NoContent();
            }
            
        }
        
        [HttpGet("all")]
        public IEnumerable<Event> GetAll()
        {
            try
            {
                 var listOfEvents = _daoEvent.GetAll();
                 return listOfEvents;    
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return null;

            }
           
        }

        [HttpPost]
        public IActionResult Add(Event eventModel)
        {
            try
            {       
                string jwt = Request.Cookies["token"];
                _logger.LogError(jwt);
                if (_validation.Validate(eventModel.User.Organiser.Userid, jwt))
                {
                    _logger.LogError("Dupa");
                    _daoEvent.Add(eventModel);
                    return Ok();
                }

                return Unauthorized();
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return Unauthorized();
            }
        }



    }
}