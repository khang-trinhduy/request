using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Request.API.Models;

namespace Request.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [Route("Send")]
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody]Email email)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(new Email());
            }
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(email.To));
            message.From.Add(new MailboxAddress(email.From));
            message.Subject = email.Subject;

            message.Body = new TextPart("plain")
            {
                Text = email.Contents,
            };
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(email.Server, 587, false);
                client.Authenticate(email.ConfirmEmail, email.ConfirmPass);//Nnhm2018
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok("email deliveried");
        }
    }
}