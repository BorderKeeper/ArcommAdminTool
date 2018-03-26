using System.IO;
using System.Net;
using ArcommAdminTool.AbsenceAnnouncements.Entities;
using Newtonsoft.Json;

namespace ArcommAdminTool.AbsenceAnnouncements.Services
{
    public class AbsenceService
    {
        private static readonly string AbsenceQueryUri = @"https://arcomm.co.uk/api/absence";
        private static readonly string RequestMethod = "GET";
        private static readonly string UserAgent = "ArcommAdminTool";

        public Absences GetAbsences()
        {
            var request = (HttpWebRequest) WebRequest.Create(AbsenceQueryUri);

            request.Method = RequestMethod;
            request.UserAgent = UserAgent;

            var response = (HttpWebResponse) request.GetResponse();

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    content = streamReader.ReadToEnd();
                }
            }

            var absences = JsonConvert.DeserializeObject<Absences>(content);

            return absences;
        }
    }
}