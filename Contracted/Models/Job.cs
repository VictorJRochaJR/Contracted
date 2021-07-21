using System;

namespace Contracted.Models
{
    public class Job
{
    public int Id {get;set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public string Name {get;set;}
   
    public bool Completed {get;set;}
    public string Description {get;set;}
    public int CurrentBid {get;set;} = 0;
    public string CreatorId {get;set;}
}
}