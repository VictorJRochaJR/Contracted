using System.Collections.Generic;
using Contracted.Models;
using Contracted.Repositories;

namespace Contracted.Services
{
    public class JobsService
    {
 private readonly JobsRepository _jobsRepo;
 
 public JobsService(JobsRepository jobsRepo)
 {
     _jobsRepo = jobsRepo;  
 }
 internal List<Job> GetJobs()
 {
     return _jobsRepo.GetAll();
 }

 internal Job CreateJob(Job jobData)
 {
     var job = _jobsRepo.Create(jobData);
     return job;
 }
    

    // public void Remove(int id, string userId)
    // {
    //     // Job job = Get(id)

    //     if(job.CreatorId != userId)
    //     {
    //         throw new System.Exception("You are not allowed to delete this because its not yours");
        
    //     }

    //     _jobsRepo.Remove(id);

    // }

    internal Job GetJob(int id)
    {
        return _jobsRepo.GetById(id);
    }
    
    
}
}