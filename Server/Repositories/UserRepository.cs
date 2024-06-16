using HMS.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Server.DB;

namespace Server.Repositories
{
    // Operations with the order collection, in addition to the standard ones,
    // implemented retrieval of the user by username and password for authentication
    public class UserRepository : RepositoryBase<UserCollection>
    {
        // The collection of users
        protected override IMongoCollection<UserCollection> Collection => MongoDBController.Instance.Db.GetCollection<UserCollection>("users");

        // The method for getting a user by username and password
        public async Task<UserCollection> GetBy(string username, string password)
            => await Collection.Find(x => x.Username == username && x.Password == password).FirstOrDefaultAsync();
        
        // The method for getting a user by role
        public async Task<List<UserCollection>> GetBy(string role)
            => await Collection.Find(x => x.Role == role).ToListAsync();
        
        // The method for getting a user by username
        public async Task<string> GetName(string id)
            => (await Collection.Find(x => x.ID == new Guid(id)).FirstOrDefaultAsync()).Username;

        // The method for adding a user with a role
        public async Task Update(UserCollection item)
        {
            var filter = Builders<UserCollection>.Filter.Eq(x => x.ID, item.ID);
            var update = Builders<UserCollection>.Update
                .Set(x => x.Username, item.Username)
                .Set(x => x.Password, item.Password)
                .Set(x => x.Role, item.Role);
            await Collection.UpdateOneAsync(filter, update);
        }
    }
}
