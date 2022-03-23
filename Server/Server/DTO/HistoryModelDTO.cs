using DataDomain.Data.NoSql.Models;

namespace Server.DTO
{
    public class HistoryModelDTO
    {
        public string userEmail { get; set; }
        public List<BasketModelDTO> Orders { get; set; }
    }
}
