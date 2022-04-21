using DataDomain.Data.NoSql.Models;

namespace Server.DTO
{
    public class BasketModelDTO
    {
        public int amount { get; set; }
        public LegoModel lego { get; set; }
        public string userEmail { get; set; }
        public DateTime DateDeal { get; set; }
        public BasketModelDTO()
        {

        }
    }
}
