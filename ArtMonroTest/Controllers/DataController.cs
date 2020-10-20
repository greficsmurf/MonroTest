using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtMonroTest.Database.Models;
using ArtMonroTest.DataBase;
using ArtMonroTest.Services.impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtMonroTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly dbContext _dbContext;
        public DataController(IDataService dataService, dbContext dbcontext) {
            _dataService = dataService;
            _dbContext = dbcontext;
        }
        // GET: api/Data
        [HttpGet("getAvailable")]
        public async Task<List<TestData>> GetAllAvailable()
        {
            return await _dataService.GetAllAvailableAsync();
        }

        // GET: api/Data/5
        [HttpGet("getAll")]
        public async Task<List<TestData>> GetAll()
        {
            return await _dataService.GetAllAsync();
        }

        // POST: api/Data
        [HttpPost("CheckSize")]
        public async Task<List<TestData>> CheckSize([FromBody] TestDataFilter filter)
        {
            return await _dataService.CheckSize(filter);
        }

    }
}
