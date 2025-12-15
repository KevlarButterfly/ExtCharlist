using ExtCharlist.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExtCharlist.Services
{
    public class CharacterRaceService
    {
        private readonly IMongoCollection<CharacterRace> _characterRaceCollection;
        public CharacterRaceService(IOptions<ExtCharlistDatabaseSettigs> extCharlistDatabaseSettings)
        {
            var mongoClient = new MongoClient(extCharlistDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(extCharlistDatabaseSettings.Value.DatabaseName);
            _characterRaceCollection = mongoDatabase.GetCollection<CharacterRace>(extCharlistDatabaseSettings.Value.CharacterRaceCollectionName);

        }
        public async Task<List<CharacterRace>> GetAsync() =>
        await _characterRaceCollection.Find(_ => true).ToListAsync();

        public async Task<CharacterRace?> GetAsync(string id) =>
            await _characterRaceCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(CharacterRace newCharacterRace) =>
            await _characterRaceCollection.InsertOneAsync(newCharacterRace);

        public async Task UpdateAsync(string id, CharacterRace updatedCharacterRace) =>
            await _characterRaceCollection.ReplaceOneAsync(x => x.Id == id, updatedCharacterRace);

        public async Task RemoveAsync(string id) =>
            await _characterRaceCollection.DeleteOneAsync(x => x.Id == id);
    }
}
