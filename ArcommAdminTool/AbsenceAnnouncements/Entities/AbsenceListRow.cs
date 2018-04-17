using System.Drawing;
using System.Windows.Forms;

namespace ArcommAdminTool.AbsenceAnnouncements.Entities
{
    public class AbsenceListRow : ListViewItem
    {
        public AbsenceListRow(string name, string missionStart, bool bold)
            : base(PopulateArray(name, missionStart))
        {
            if (bold)
            {
                Font = new Font(Font, FontStyle.Bold);
            }
        }

        private static string[] PopulateArray(string name, string missionStart)
        {
            string[] arr = new string[2];

            arr[0] = name;
            arr[1] = missionStart;

            return arr;
        }
    }
}