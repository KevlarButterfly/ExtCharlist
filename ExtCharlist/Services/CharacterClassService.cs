using ExtCharlistLibrary.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExtCharlistAPI.Services
{
    public class CharacterClassService
    {
        private readonly IMongoCollection<CharacterClass> _characterClassCollection;
        public CharacterClassService(IOptions<ExtCharlistDatabaseSettigs> extCharlistDatabaseSettings)
        {
            var mongoClient = new MongoClient(extCharlistDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(extCharlistDatabaseSettings.Value.DatabaseName);
            _characterClassCollection = mongoDatabase.GetCollection<CharacterClass>(extCharlistDatabaseSettings.Value.CharacterClassCollectionName);

        }
        public async Task<List<CharacterClass>> GetAsync() =>
        await _characterClassCollection.Find(_ => true).ToListAsync();

        public async Task<CharacterClass?> GetAsync(string id) =>
            await _characterClassCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(CharacterClass newCharacterClass) =>
            await _characterClassCollection.InsertOneAsync(newCharacterClass);

        public async Task UpdateAsync(string id, CharacterClass updatedCharacterClass) =>
            await _characterClassCollection.ReplaceOneAsync(x => x.Id == id, updatedCharacterClass);

        public async Task RemoveAsync(string id) =>
            await _characterClassCollection.DeleteOneAsync(x => x.Id == id);
    }
}
