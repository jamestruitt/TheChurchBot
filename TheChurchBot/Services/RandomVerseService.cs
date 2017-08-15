using System.Net.Http;

namespace TheChurchBot.Services
{
    public static class RandomVerseService
    {
        public static string GetRandomVerse()
        {
            var client = new HttpClient();

            const string url = "http://www.ourmanna.com/verses/api/get/?format=text&order=random";

            var response = client.GetStringAsync(url).Result;

            return response;
        }
    }
}
