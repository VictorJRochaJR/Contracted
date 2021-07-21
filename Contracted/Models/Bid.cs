using System;
using Contracted.Models;
using GroupMe.Models;

namespace Contracted.Models
{
public class Bid
{
 public int Id {get;set;}
 public DateTime CreatedAt {get;set;}
 public DateTime UpdatedAt {get;set;}
 public string AccountId {get;set;}
 public int JobId {get;set;}
 public int BidAmount {get;set;}

 public Job Job {get;set;}
 public Profile Profile {get;set;}
}
}