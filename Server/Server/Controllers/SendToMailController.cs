using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;
using Services.Model;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SendToMailController : ControllerBase
    {
        private readonly ISendToMail _mailService;
        public SendToMailController(ISendToMail sendService)
        {
            _mailService = sendService;
        }
        
        [HttpPost]
        public async Task<IActionResult> SendToMail([FromBody] MessageToMailDTO mail)
        {
            var mailRequest = new MailRequest()
            {
                ToEmail = mail.email,
                Subject = mail.subject,
                Body = mail.letter
            };
            try
            {
                await _mailService.SendToMailAsync(mailRequest);

                var message = new
                {
                    result = "Email was sent successfully"
                };

                return Ok(message);
            }
            catch (Exception)
            {
                var message = new
                {
                    result = "Messaage can't be sent to customer"
                };

                return BadRequest(message);
            }
        }
 
    }
}
