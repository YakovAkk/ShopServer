using Services.Services.Base;

namespace Services.Services
{
    public class SendToMailService : ISendToMail
    {
        public async Task<bool> SendToMailAsync(string Email, string letter)
        {
            return await (Task.Run(() => false));
        }
    }
}
