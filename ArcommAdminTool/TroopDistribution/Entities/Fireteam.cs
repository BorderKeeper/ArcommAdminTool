using System.Windows.Forms;

namespace ArcommAdminTool.TroopDistribution.Entities
{
    public class Fireteam : ITreeMember
    {
        public Fireteam(SquadSign sign, int id, int occupancy, int idealFireteamSize)
        {
            Id = id;
            SquadSign = sign;
            Occupancy = occupancy;
            IdealFireteamSize = idealFireteamSize;
        }

        public int Id { get; set; }

        public SquadSign SquadSign { get; set; }

        public int Occupancy { get; set; }

        public int IdealFireteamSize { get; set; }

        public string Name => $"{SquadSign} {Id} [{Occupancy}/{IdealFireteamSize}]";

        public string Key => SquadSign + Id.ToString();

        public TreeNode ToTree()
        {
            return new TreeNode { Text = Name };
        }
    }
}