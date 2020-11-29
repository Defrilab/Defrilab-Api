using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReaiotBackend.IRepositories;
using ReaiotBackend.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace ReaiotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TtntestController : ControllerBase
    {

        private readonly ITtntestRepository _ttntestRepository;
        public TtntestController(ITtntestRepository ttntestRepository )
        {
            _ttntestRepository = ttntestRepository;
        }

        [HttpPost("ttn_data")]
        public  ActionResult PostData(TttnTestData tttnTestData)
        {
            try
            {
                var credentials = new NetworkCredential("reaiotorg@gmail.com", "magic@3.");
                var mail = new MailMessage()
                {
                    From = new MailAddress("reaiotorg@gmail.com"),
                    Subject = "ttn_data test",
                    Body = $"The simulated ttn data is {tttnTestData}",

                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("humphryshikunzi9@gmail.com"));
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(mail);
                return Ok(tttnTestData);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
            //return Ok(_ttntestRepository.AddData(tttnTestData));
        }
    }
}
