using IotLog.Interface;
using IotLog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IotLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly IDataRepository<Log> _dataRepository;

        private readonly IJwtAuth _jwtAuth;
        public LogController(IJwtAuth jwtAuth, IDataRepository<Log> dataRepository)
        {
            _jwtAuth = jwtAuth;
            _dataRepository = dataRepository;
        }

        // GET: api/<LogController>
        [HttpGet]
        public async Task<IEnumerable<Log>> Get()
        {
            return await _dataRepository.GetAll();
        }

        // GET api/<LogController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<Log> Get(long id)
        {
            return await _dataRepository.Get(id);
        }

        // POST api/<LogController>
        [Authorize]
        [HttpPost]
        public async Task Post([FromBody] List<Log> request)
        {
            await _dataRepository.Add(request);
        }

        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [AllowAnonymous]
        // POST api/<LogController>
        [HttpPost("authenticate")]
        public Authenicated Authentication([FromBody] UserCredentials userCredential)
        {
            var token= _jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            return new Authenicated { Token =token};
        }
    }
    public class Authenicated { 
    public string Token { get; set; }
    }
}
