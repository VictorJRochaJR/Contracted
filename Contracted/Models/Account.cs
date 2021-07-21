using System;
using GroupMe.Models;

namespace Contracted.Models
{
    public class Account : Profile
    {
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public string Email {get;set;} 
    }
}
               
             
      
