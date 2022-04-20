using DataDomain.Data.NoSql.Models;
using MongoDB.Driver;
using Repositories.RepositoriesMongo.Base;


namespace Repositories.RepositoriesMongo
{
    public class HistoryRepository : MongoDbBase<UserHistoryModel>
    {
        protected override IMongoCollection<UserHistoryModel> Collection { get; set; }

        public override async Task<UserHistoryModel> AddAsync(UserHistoryModel item)
        {
            if (item == null)
            {
                var history = new UserHistoryModel();

                history.messageThatWrong = "Item was null";

                return history;
            }

            var AllLego = await GetAllAsync();

            if(AllLego == null)
            {
                var history = new UserHistoryModel();

                history.messageThatWrong = "Lego is empty";

                return history;
            }

            var historyOfUser = (AllLego).FirstOrDefault(i => i.User.Email == item.User.Email);


            if (historyOfUser == null)
            {
                await Collection.InsertOneAsync(item);
                return item;
            }

            var story = await UpdateAsync(item);

            if(story == null)
            {
                var history = new UserHistoryModel();

                history.messageThatWrong = "Lego wasn't update";

                return history;
            }

            return story;
        }

        public override async Task<UserHistoryModel> UpdateAsync(UserHistoryModel item)
        {
            if (item == null)
            {
                var history = new UserHistoryModel();

                history.messageThatWrong = "Item was null";

                return history;
            }

            var AllLego = await GetAllAsync();

            if (AllLego == null)
            {
                var history = new UserHistoryModel();

                history.messageThatWrong = "Lego is empty";

                return history;
            }

            var Orders = (AllLego).FirstOrDefault(i => i.User.Email == item.User.Email).Orders.ToList();
            
            if(Orders == null)
            {
                var history = new UserHistoryModel();

                history.messageThatWrong = "Database hasn't contain the element";

                return history;
            }

            Orders.AddRange(item.Orders);

            var result = await Collection.UpdateOneAsync(i => i.User.Email == item.User.Email, Builders<UserHistoryModel>.
                Update.Set(c => c.Orders, Orders));

            if(result == null)
            {
                var history = new UserHistoryModel();

                history.messageThatWrong = "Database can't update the element";

                return history;
            }
            return item;
        }
    }
}
