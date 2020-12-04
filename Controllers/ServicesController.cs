using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using ReaiotBackend.Constants;
using ReaiotBackend.Data;
using ReaiotBackend.Dtos;
using ReaiotBackend.Services;
using System;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ReaiotDbContext _context;
       public ServicesController(ReaiotDbContext context)
       {
           _context = context;
       }

        [HttpPost("SendMessage")]
       public IActionResult SendMessage(string recepient, string message)
       {

           MessageService.SendMessage(recepient, message);
           return Ok(message);
       }
                
        [HttpPost("ResetPassword")]
        public  IActionResult ChangePasswordDto([FromBody]ChangePasswordDto changePasswordDto)
        {
            if (ModelState.IsValid)
            {
                var code = EmailServices.SendEmailForPasswordRecoveryCode(changePasswordDto.Email);
                return  Ok(code);
            }
            return BadRequest($"Could not send password recovery code to user with email {changePasswordDto.Email}");
        }

        [HttpPost("Images")]
        public  IActionResult StoreBlob([FromBody]BlobItemDto blobItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request Parameters");
            }
            var blobStorageService = new BlobStorageService();
            var connectionString = blobStorageService.GetCredentials();
            var account = CloudStorageAccount.Parse(connectionString);
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(AppConstants.ContainerName);
            string uniqueName = Guid.NewGuid().ToString();
            var userKey = blobItemDto.ProjectName;
            var blockBlob = container.GetBlockBlobReference($"{userKey}{uniqueName}.jpg");
            blockBlob.UploadFromStreamAsync(blobItemDto.TakenImage);
            return Ok(blockBlob.Uri.OriginalString);
        }
    }
}
