using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReaiotBackend.Data;
using ReaiotBackend.Dtos;
using ReaiotBackend.Models;
using ReaiotBackend.Services;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ReaiotDbContext _context;
        private static IConfiguration _configuration;
        public ServicesController(ReaiotDbContext context, IConfiguration configuration)
        {
           _context = context;
           _configuration = configuration;
        }
                
        [HttpPost("ResetPassword")]
        public  IActionResult ChangePasswordDto([FromBody]ChangePasswordDto changePasswordDto)
        {
            if (ModelState.IsValid)
            {
                var code = EmailServices.SendEmailForPasswordRecoveryCode(changePasswordDto.Email);
                return  Ok(code);
            }
            return BadRequest();
        }  
        
        [HttpPost("SendTwilioMessage")]
        public IActionResult SendTwilioMessage(TwilioMessage twilioMessage)
        {
            // Get credentials for Twilio
            var twilioCredentials = _configuration.GetSection("TwilioCredentials");
            var  twilioDto = twilioCredentials.Get<TwilioDto>();

            TwilioClient.Init(twilioDto.AccountSSD, twilioDto.AuthToken);


            //dictionary of people to send the messages to 
            var people = new Dictionary<string, string>()
            {
                { "+254742267032","Humphry" }
            };

            foreach (var person in  people)
            {
                MessageResource.Create(
                    from: new PhoneNumber("+12056565415"),
                    to: new PhoneNumber(person.Key),
                    body: $"Hello Humphry, welcome to Twilio, {twilioMessage.Message}");
            }

            return Ok();
        }

        #region IBeesTest
        public class IBeesMessage
        {
            public int  Id { get; set; }
            public  string  Humidity { get; set; }
            public  string  Temperature { get; set; }
            public  string  Owner { get; set; }
        }

        [HttpPost("SendIBeesMessage")]
        public IActionResult SendIBeesMessage(IBeesMessage  beesMessage)
        {
            // Get credentials for Twilio
            var twilioCredentials = _configuration.GetSection("TwilioCredentials");
            var twilioDto = twilioCredentials.Get<TwilioDto>();

            TwilioClient.Init(twilioDto.AccountSSD, twilioDto.AuthToken);


            //dictionary of people to send the messages to 
            var people = new Dictionary<string, string>()
            {
                { "+254742267032","Humphry" }
            };

            foreach (var person in people)
            {
                MessageResource.Create(
                    from: new PhoneNumber("+12056565415"),
                    to: new PhoneNumber(person.Key),
                    body: $"Hello {beesMessage.Owner}, this is Ibees\n." +
                          $"This is your data : \n" +
                          $"Temperature : {beesMessage.Temperature}\n" +
                          $"Humidity    : {beesMessage.Humidity}.\n" +
                          $"Contact infor@ibees.org.");
            }

            return Ok();
        }
        #endregion
    }
}

