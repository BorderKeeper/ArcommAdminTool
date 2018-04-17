using System.Collections.Generic;

namespace ArcommAdminTool.AbsenceAnnouncements.Services.SteamService.Contract
{
    public class Response
    {
        public IEnumerable<Player> Players { get; set; }
    }

    public class Player
    {
        public string SteamId { get; set; }

        public string PersonaName { get; set; }

        public string ProfileUrl { get; set; }

        public string Avatar { get; set; }
    }
}