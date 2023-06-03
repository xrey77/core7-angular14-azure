using Microsoft.AspNetCore.Mvc;

namespace core7_angular14_azure.Models
{
    public class UploadfileModel {
        public int Id { get; set; }
        public IFormFile Profilepic { get; set; }

    }
    
}