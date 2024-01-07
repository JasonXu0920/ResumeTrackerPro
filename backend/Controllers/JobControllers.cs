using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Core.Context;
using backend.Core.Dtos.Job;
using backend.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Route("[controller]")]
    public class JobControllers : Controller
    {
        private ApplicationDbContext _context{get; }
        private IMapper _mapper {get; }
        public JobControllers(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CRUD
        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);
            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();

            return Ok("Job Created Successful!");
        }

        // Reead 
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> GetJobs()
        {
            var jobs = await _context.Jobs.Include(job => job.Company).ToListAsync();
            var convertedJobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);

            return Ok(convertedJobs);
        }
    }
}