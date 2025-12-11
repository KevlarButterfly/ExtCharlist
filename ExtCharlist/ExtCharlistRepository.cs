

namespace ExtCharlist
{
    public class ExtCharlistRepository
    {
        List<string> races = ["barbarian", "bard", "cleric", "druid", "fighter", "monk", "paladin", "ranger", "rogue", "sorcerer", "warlock", "wizard"];
        public async void GetDataAsync()
        {
            for (int i = 0; i < races.Count; i++) {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://www.dnd5eapi.co/api/2014/classes/" + races[i]);
                request.Headers.Add("Accept", "application/json");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }



    }
}
