using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;
using Services.Services.Base;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SendToMailController : ControllerBase
    {
        private readonly ISendToMail _userService;
        [HttpPost]
        public async Task<IActionResult> SendToMail([FromBody] MessageToMailDTO messageToMailCustomer)
        {
            if (await _userService.SendToMailAsync(messageToMailCustomer.email, messageToMailCustomer.letter))
            {
                return Ok();
            }
            return BadRequest(new 
            { 
                message = "Messaage can't be sent to customer" }
            );
            
        }

        public SendToMailController(ISendToMail sendService)
        {
            _userService = sendService;
        }
    }
}
