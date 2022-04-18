using DataDomain.Attributes;
using DataDomain.Data.NoSql.Models.Base;
using DataDomain.Data.Sql.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DataDomain.Data.NoSql.Models
{
    [NameCollection("Basket")]
    public class BasketModel : IModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public LegoModel Lego { get; set; }
        public UserModel User { get; set; }
        public uint Amount { get; set; }
        public DateTime DateDeal { get; set; }

        public BasketModel()
        {
            DateDeal = DateTime.Now;
        }

        public BasketModel(LegoModel lego, uint amount ,UserModel user )
        {
            Lego = lego;
            Amount = amount;
            User = user;
            DateDeal = DateTime.Now;
        }
    }
}
