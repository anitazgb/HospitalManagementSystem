using HMS.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Server.Repositories
{
    // Abstract class for defining standard CRUD operations with the database for each collection
    public abstract class RepositoryBase<T> where T : IModel
    {
        // Definition of the collection to work with, must be overridden in each repository class
        protected abstract IMongoCollection<T> Collection { get; }

        // Retrieve all records
        public async Task<List<T>> Get()
            => await Collection.Find(new BsonDocument()).ToListAsync();

        // Retrieve a single record by ID
        public async Task<T> GetById(Guid id)
            => await Collection.Find(x => x.ID == id).FirstOrDefaultAsync();

        // Add a record
        public async Task Insert(T item)
            => await Collection.InsertOneAsync(item);

        // Delete a record
        public async Task Delete(Guid id)
            => await Collection.DeleteOneAsync(x => x.ID == id);
    }
}
