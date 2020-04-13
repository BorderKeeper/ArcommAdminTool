using System.Collections.Generic;
using System.Windows.Forms;

namespace ArcommAdminTool.TroopDistribution.Entities
{
    public class TroopDistributionResult
    {
        public Platoon Blufor { get; set; }

        public Platoon Opfor { get; set; }

        public SpecialPlatoon SpecialRoles { get; set; }

        public SpecialPlatoon ExtraPlayers { get; set; }

        public SpecialPlatoon Zeus { get; set; }

        public TreeNode[] ToTree()
        {
            var nodes = new List<TreeNode>();

            nodes.Add(Blufor.ToTree());

            if (Opfor != null)
            {
                nodes.Add(Opfor.ToTree());
            }

            if (SpecialRoles != null)
            {
                nodes.Add(SpecialRoles.ToTree());
            }

            if (ExtraPlayers != null)
            {
                nodes.Add(ExtraPlayers.ToTree());
            }

            if (Zeus != null)
            {
                nodes.Add(Zeus.ToTree());
            }

            return nodes.ToArray();
        }
    }
}