using DataDomain.Attributes;
using DataDomain.Data.NoSql.Models.Base;
using DataDomain.Data.Sql.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DataDomain.Data.NoSql.Models
{
    [NameCollection("History")]
    public class UserHistoryModel : IModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public UserModel User { get; set; }
        public List<BasketModel> Orders { get; set; }
        public string? messageThatWrong { get; set; }

        public UserHistoryModel()
        {

        }

    }
}
