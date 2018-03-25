using System.Windows.Forms;

namespace ArcommAdminTool.TroopDistribution.Entities
{
    public class Fireteam : ITreeMember
    {
        public Fireteam(SquadSign sign, int id, int occupancy)
        {
            Id = id;
            SquadSign = sign;
            Occupancy = occupancy;
        }

        public int Id { get; set; }

        public SquadSign SquadSign { get; set; }

        public int Occupancy { get; set; }

        public string Name => $"{SquadSign} {Id} [{Occupancy}/{TroopDistributionCalculator.FullFireteam}]";

        public string Key => SquadSign + Id.ToString();

        public TreeNode ToTree()
        {
            return new TreeNode { Text = Name };
        }
    }
}