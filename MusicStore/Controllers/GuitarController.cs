using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using MusicStore.Models;
using MusicStore.Repositories;

namespace MusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        private readonly IGuitarRepository _guitarRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public GuitarController(IGuitarRepository guitarRepository, IUserProfileRepository userProfileRepository)
        {
            _guitarRepository = guitarRepository;
            _userProfileRepository = userProfileRepository;
        }

        // GET: api/<GuitarController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_guitarRepository.GetAll());
        }

        // GET api/<GuitarController>/5
        [HttpGet("{id}")]
        public IActionResult GetGuitarById(int id)
        {
            var guitar = _guitarRepository.GetById(id);

            if (guitar == null)
            {
                return NotFound();
            }
            
            return Ok(guitar);
        }

        // POST api/<GuitarController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<GuitarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<GuitarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
