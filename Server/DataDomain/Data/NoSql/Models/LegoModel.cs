using DataDomain.Attributes;
using DataDomain.Data.NoSql.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace DataDomain.Data.NoSql.Models
{
    [NameCollection("Lego")]
    public class LegoModel : IModel
    {
        

        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public uint Price { get; set; }
        public bool isFavorite { get; set; }
        public CategoryModel Category { get; set; }
        public string? messageThatWrong { get; set; }

        public LegoModel()
        {

        }

    }
}
