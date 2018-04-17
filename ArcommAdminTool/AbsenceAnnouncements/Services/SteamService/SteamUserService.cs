using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ArcommAdminTool.AbsenceAnnouncements.Services.SteamService.Contract;
using Newtonsoft.Json;

namespace ArcommAdminTool.AbsenceAnnouncements.Services.SteamService
{
    public class SteamUserService
    {
        private static readonly string ServiceUri = @"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=9A8133ED669FF7E6C67AB6C0AFDBF5D0&steamids={0}";
        private static readonly string RequestMethod = "GET";
        private static readonly string UserAgent = "ArcommAdminTool";

        public async Task<Response> GetPlayersImageUrl(IEnumerable<string> steamIds)
        {
            var url = string.Format(ServiceUri, string.Join(",", steamIds));

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

            var steamUsers = JsonConvert.DeserializeObject<Response>(content);

            return steamUsers;
        }
    }
}