using System.ComponentModel.DataAnnotations;

namespace core7_angular14_azure.Models.dto
{
  public class UserRegister
    {        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Profilepic { get; set; }
        public string Roles { get; set; }
    }
    
}