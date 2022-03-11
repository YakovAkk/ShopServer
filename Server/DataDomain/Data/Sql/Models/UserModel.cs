

using System.Security.Claims;

namespace DataDomain.Data.Sql.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public DateTime DataRegistration { get; set; }

        public UserModel()
        {
            DataRegistration = DateTime.Now;
        }

    }
}
