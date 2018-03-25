using System.Drawing.Text;
using System.Windows.Forms;

namespace ArcommAdminTool.TroopDistribution.Entities
{
    public class SpecialPlatoon : ITreeMember
    {
        private const string Plural = "Players";
        private const string Singular = "Player";

        private readonly string _name;
        private readonly int _occupancy;
        private readonly string _identifier;

        public SpecialPlatoon(string name, int occupancy)
        {
            _name = name;
            _occupancy = occupancy;

            if (occupancy > 1) _identifier = Plural;
            else _identifier = Singular;
        }

        public int Occupancy => _occupancy;

        public TreeNode ToTree()
        {
            return new TreeNode(Name);
        }

        public string Name => $"{_name} [{_occupancy} {_identifier}]";
    }
}