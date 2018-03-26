using System.IO;
using System.Net;
using System.Threading.Tasks;
using ArcommAdminTool.AbsenceAnnouncements.Entities;
using Newtonsoft.Json;

namespace ArcommAdminTool.AbsenceAnnouncements.Services
{
    public class SteamUserService
    {
        private static readonly string ServiceUri = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=key&steamids={0}";
        private static readonly string RequestMethod = "GET";
        private static readonly string UserAgent = "ArcommAdminTool";

        public async Task<SteamPlayers> GetPlayerData(Task<Absences> absence)
        {
            var url = string.Format(ServiceUri, string.Join(",", absence));

            var request = (HttpWebRequest) WebRequest.Create(url);

            request.Method = RequestMethod;
            request.UserAgent = UserAgent;

            var response = await request.GetResponseAsync();

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    content = streamReader.ReadToEnd();
                }
            }

            var steamUsers = JsonConvert.DeserializeObject<SteamPlayers>(content);

            return steamUsers;
        }
    }
}