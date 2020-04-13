using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ArcommAdminTool.TroopDistribution.Entities
{
    public class Platoon : ITreeMember
    {
        public Platoon(TeamSide side, int idealFireteamSize)
        {
            Side = side;
            Squads = new List<Squad>();
            SupportingRoles = 0;
            IdealFireteamSize = idealFireteamSize;
        }

        public TeamSide Side { get; set; }

        public List<Squad> Squads { get; set; }

        public int SupportingRoles { get; set; }

        public int IdealFireteamSize { get; set; }

        public Squad AddSquad(SquadSign sign)
        {
            Squad sq = new Squad(sign, IdealFireteamSize);

            Squads.Add(sq);

            if (Squads.Count > 1)
            {
                SupportingRoles = TroopDistributionCalculator.FullLeadership;
            }

            return sq;
        }

        public int Occupancy => Squads.Sum(squad => squad.Occupancy) + SupportingRoles;

        public TreeNode ToTree()
        {
            TreeNode node = new TreeNode { Text = Name };

            node.Nodes.AddRange(Squads.Select(squad => squad.ToTree()).ToArray());

            return node;    
        }

        public string Name => $"{Side} [{SupportingRoles}/{TroopDistributionCalculator.FullLeadership}]";
    }
}