using ExtCharlist.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExtCharlist.Services
{
    public class UsersService
    {
        private readonly IMongoCollection<Character> _characterCollection;
        public UsersService(IOptions<ExtCharlistDatabaseSettigs> extCharlistDatabaseSettings)
        {
            var mongoClient = new MongoClient(extCharlistDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(extCharlistDatabaseSettings.Value.DatabaseName);
            _characterCollection = mongoDatabase.GetCollection<Character>(extCharlistDatabaseSettings.Value.UsersCollectionName);

        }
        public async Task<List<Character>> GetAsync() =>
        await _characterCollection.Find(_ => true).ToListAsync();

        public async Task<Character?> GetAsync(string id) =>
            await _characterCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<List<Character?>> GetByUserIdAsync(string? userId)
            => await _characterCollection.Find(x => x.UserId == userId).ToListAsync();
        public async Task CreateAsync(Character newCharacter) =>
            await _characterCollection.InsertOneAsync(newCharacter);

        public async Task UpdateAsync(string id, Character updatedCharacter) =>
            await _characterCollection.ReplaceOneAsync(x => x.Id == id, updatedCharacter);

        public async Task RemoveAsync(string id) =>
            await _characterCollection.DeleteOneAsync(x => x.Id == id);
    }
}
}
