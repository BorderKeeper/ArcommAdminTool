using System.Windows.Forms;

namespace ArcommAdminTool.TroopDistribution.Entities
{
    public interface ITreeMember
    {
        int Occupancy { get; }

        TreeNode ToTree();

        string Name { get; }
    }
}