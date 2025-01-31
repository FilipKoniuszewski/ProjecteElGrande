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
        private IEventRepository _repositoryEvent;
        private readonly IMapper _mapper;
        private IValidation _validation;


        public EventController(ILogger<EventController> logger, IEventRepository repositoryEvent,
            IMapper mapper, IValidation validation)
        {
            _logger = logger;
            _repositoryEvent = repositoryEvent;
            _mapper = mapper;
            _validation = validation;
        }



        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Event))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid id)
        {
            try
            {
                Event eventModel = _repositoryEvent.Get(id);
                return Ok(eventModel);
            }
            catch (Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }



        [HttpGet("input/{input}")]
        public IEnumerable<EventCardDto> GetByInput(string input)
        {
            try
            {
                var listOfEvents = _repositoryEvent.GetByInput(input);
                return _mapper.Map<IEnumerable<EventCardDto>>(listOfEvents);
            }
            catch (Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return null;
            }
        }
        


        [HttpGet("user-events")]  
        public IEnumerable<Event> GetUserEvents([FromHeader(Name = "userId")] string userId)
        {
            try
            {
                string jwt = Request.Cookies["token"];
                if (!_validation.Validate(Guid.Parse(userId), jwt))
                    return null;
                var listOfUserEvents = _repositoryEvent.GetUserEventsByUserId(Guid.Parse(userId));
                return listOfUserEvents;

            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return null;
            }
           
        }
        
        [HttpGet("events-user")]  
        public IEnumerable<User> GetEventsUser([FromHeader(Name = "eventsId")] string eventsId)
        {
            try
            {
                var listOfUserEvents = _repositoryEvent.GetUsersByEventId(Guid.Parse(eventsId));
                return listOfUserEvents;

            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return null;
            }
           
        }


        
        [HttpGet("events-user/upcoming")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserEventsDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUserUpcomingEvents([FromHeader(Name = "etag")] string userId,
                                                        [FromHeader(Name = "currentPage")] string currentPage)
        {
            try
            {
                string jwt = Request.Cookies["token"];
                if (!_validation.Validate(Guid.Parse(userId), jwt))
                    return Unauthorized();
                var listOfUserEvents = _repositoryEvent.GetUpcomingEventsById(Guid.Parse(userId), int.Parse(currentPage));
                return Ok(listOfUserEvents);
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        
        [HttpGet("events-user/previous")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserEventsDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUserPreviousEvents([FromHeader(Name = "etag")] string userId,
                                                        [FromHeader(Name = "currentPage")] string currentPage)
        {
            try
            {
                string jwt = Request.Cookies["token"];
                if (!_validation.Validate(Guid.Parse(userId), jwt))
                    return Unauthorized();
                var listOfUserEvents = _repositoryEvent.GetPreviousEventsById(Guid.Parse(userId), int.Parse(currentPage));
                return Ok(listOfUserEvents);


            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        
        [HttpGet("events-user/hosted")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserEventsDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUserHostedEvents([FromHeader(Name = "etag")] string userId,
            [FromHeader(Name = "currentPage")] string currentPage)
        {
            try
            {
                string jwt = Request.Cookies["token"];
                if (!_validation.Validate(Guid.Parse(userId), jwt))
                    return Unauthorized();
                var listOfUserEvents = _repositoryEvent.GetHostedEventsById(Guid.Parse(userId), int.Parse(currentPage));
                return Ok(listOfUserEvents);
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        
        [HttpGet("events-user/hosted-statistics")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Event>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUserHostedEvents([FromHeader(Name = "etag")] string userId)
        {
            try
            {
                string jwt = Request.Cookies["token"];
                if (!_validation.Validate(Guid.Parse(userId), jwt))
                    return Unauthorized();
                var listOfUserEvents = _repositoryEvent.GetHostedEventsStatisticsById(Guid.Parse(userId));
                return Ok(listOfUserEvents);
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        
        



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetFilteredEvents([FromQuery] Filter filter)
        {
            try
            {
                var listOfEvents = _repositoryEvent.GetFiltered(filter);
                if (!listOfEvents.EventsFound.Any())
                {
                    return NoContent();
                }
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
                var listOfEvents = _repositoryEvent.GetAll();
                return listOfEvents;
            }
            catch (Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return null;
            }
        }
        


        [HttpGet("join")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult JoinToEvent([FromQuery]Guid userId, [FromQuery] Guid eventId)
        {
            try
            {
                string jwt = Request.Cookies["token"];
                if (!_validation.Validate(userId, jwt))
                    return Unauthorized();
                _repositoryEvent.JoinToEvent(userId,eventId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        


        [HttpPost]
        public IActionResult Add(Event eventModel, [FromHeader] Guid userId)
        {
            try
            {
                _repositoryEvent.Add(eventModel, userId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return Unauthorized();
            }
        }
        
         
        [HttpGet("status-update")]
        public IActionResult StatusUpdate()
        {
            try
            {
                _repositoryEvent.UpdateStatus();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return Unauthorized();
            }
        }
        
        
        
        
        
        [HttpGet("events-visited-user/upcoming")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserEventsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVisitedUserUpcomingEvents([FromHeader(Name = "etag")] string userId,
            [FromHeader(Name = "currentPage")] string currentPage)
        {
            try
            {
                var listOfUserEvents = _repositoryEvent.GetUpcomingEventsById(Guid.Parse(userId), int.Parse(currentPage));
                return Ok(listOfUserEvents);
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        
        [HttpGet("events-visited-user/previous")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserEventsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVisitedUserPreviousEvents([FromHeader(Name = "etag")] string userId,
            [FromHeader(Name = "currentPage")] string currentPage)
        {
            try
            {
                var listOfUserEvents = _repositoryEvent.GetPreviousEventsById(Guid.Parse(userId), int.Parse(currentPage));
                return Ok(listOfUserEvents);


            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        
        [HttpGet("events-visited-user/hosted")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserEventsDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVisitedUserHostedEvents([FromHeader(Name = "etag")] string userId,
            [FromHeader(Name = "currentPage")] string currentPage)
        {
            try
            {
                var listOfUserEvents = _repositoryEvent.GetHostedEventsById(Guid.Parse(userId), int.Parse(currentPage));
                return Ok(listOfUserEvents);
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        
        [HttpGet("events-visited-user/hosted-statistics")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Event>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVisitedUserHostedEvents([FromHeader(Name = "etag")] string userId)
        {
            try
            {
                var listOfUserEvents = _repositoryEvent.GetHostedEventsStatisticsById(Guid.Parse(userId));
                return Ok(listOfUserEvents);
            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return BadRequest();
            }
        }
        
        
        [HttpGet("visited-user-events")]  
        public IEnumerable<Event> GetVisitedUserEvents([FromHeader(Name = "userId")] string userId)
        {
            try
            {
                var listOfUserEvents = _repositoryEvent.GetUserEventsByUserId(Guid.Parse(userId));
                return listOfUserEvents;

            }
            catch(Exception e)
            {
                _logger.LogWarning(Convert.ToString(e));
                return null;
            }
           
        }
    }
}