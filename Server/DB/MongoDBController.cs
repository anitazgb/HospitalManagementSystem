using MongoDB.Driver;
using Server.Repositories;
using HMS.Models;

namespace Server.DB
{
    // Class for defining database interactions
    public class MongoDBController
    {
        // Singleton implementation for DBController to ensure there is only one access point to the database
        private static MongoDBController _instance;
        private MongoClient _client;
        private IMongoDatabase _db;
        private UserRepository _usersRepository;

        public UserCollection CurrentUser { get; set; }

        // Repository properties for each data collection
        public UserRepository User => _usersRepository ?? (_usersRepository = new UserRepository());

        // According to the MongoDB documentation, the best practice is to implement a Singleton for database access
        public static MongoDBController Instance => _instance ?? (_instance = new MongoDBController());

        // Define the database client
        public MongoClient Client => _client ?? (_client = new MongoClient("mongodb://localhost:27017"));

        // Define the database to work with
        public IMongoDatabase Db => Client.GetDatabase("HospitalManagementSystem");
    }
}
