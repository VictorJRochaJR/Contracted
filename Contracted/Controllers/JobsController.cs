using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _js;
        public JobsController(JobsService js)
        {
            _js = js;
        }
        [HttpGet("{id")]
        public ActionResult<Job> GetOne(int id)
        {
            try
            {
                Job  job = _js.GetJob(id);
                return Ok(job);

            }
            catch (System.Exception e)
            {
                
               return BadRequest(e.Message);
            }
        }



        [HttpGet]
        public ActionResult<List<Job>> Get()
        {
            try
            {
                List<Job> jobs = _js.GetJobs();
                return Ok(jobs);
            }
            catch (System.Exception e)
            {
                
              return BadRequest(e.Message);
            }
        }

            [Authorize]
            [HttpPost]
            public async Task<ActionResult<Job>> Create([FromBody] Job jobData)
            {
                try
                {
                    Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                    jobData.CreatorId = userInfo.Id;
                    var j = _js.CreateJob(jobData);
                    return Ok(j);
                }
                catch (System.Exception e)
                {
                    
                    return BadRequest(e.Message);
                }
            }

          
        }

    }
