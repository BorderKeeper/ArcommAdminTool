namespace ArcommAdminTool.AbsenceAnnouncements.Entities
{
    public class PlayerAbsenceListRow : AbsenceListRow
    {
        public string PlayerName { get; set; }

        public string MissionStart { get; set; }

        public PlayerAbsenceListRow(string name, string missionStart, bool bold) 
            : base(name, missionStart, bold)
        {
            PlayerName = name;
            MissionStart = missionStart;
        }
    }
}