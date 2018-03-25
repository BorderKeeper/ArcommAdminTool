using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ArcommAdminTool.TroopDistribution.Entities
{
    public class Squad : ITreeMember
    {
        public Squad(SquadSign squadSign)
        {
            Sign = squadSign;
            Fireteams = new List<Fireteam>();
            SupportingRoles = 0;
        }

        public SquadSign Sign { get; set; }

        public List<Fireteam> Fireteams { get; set; }

        public int SupportingRoles { get; set; }

        public void AddFireTeam(int occupancy)
        {
            Fireteams.Add(new Fireteam(Sign, Fireteams.Count + 1, occupancy));

            if (Fireteams.Count > 1)
            {
                SupportingRoles = TroopDistributionCalculator.FullLeadership;
            }
        }

        public int Occupancy => Fireteams.Sum(fireTeam => fireTeam.Occupancy) + SupportingRoles;

        public TreeNode ToTree()
        {
            var node = new TreeNode { Text = Name };

            node.Nodes.AddRange(Fireteams.Select(fireTeam => fireTeam.ToTree()).ToArray());

            return node;
        }

        public string Name => $"{Sign} [{SupportingRoles}/{TroopDistributionCalculator.FullLeadership}]";
    }
}