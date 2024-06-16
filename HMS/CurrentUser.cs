using HMS.Models;
using MongoDB.Bson;

namespace HMS
{
    // Class for storing data about the current user
    // We store their ID in the database, their role, and the token they received from the API
    public class CurrentUser
    {
        public static Person MyUser { get; set; }
        public record class Person(Guid ID,string role, string token);
    }
}
