using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcommAdminTool.AbsenceAnnouncements.Entities;
using ArcommAdminTool.AbsenceAnnouncements.Services;

namespace ArcommAdminTool.AbsenceAnnouncements
{
    public partial class AbsenceAnnouncementUserControl : UserControl
    {
        private readonly AbsenceService _absenceService;
        private readonly SteamUserService _steamUserService;

        private readonly Absences _absences;
        private readonly Task<SteamPlayers> _steamPlayers;

        public AbsenceAnnouncementUserControl()
        {
            InitializeComponent();
            _absenceService = new AbsenceService();
            _steamUserService = new SteamUserService();

            _absences = _absenceService.GetAbsences();
            //_steamPlayers = _steamUserService.GetPlayerData(_absences);

            SetupAbsenceList();
        }

        private void SetupAbsenceList()
        {
            AbsenceListView.View = View.Details;
            AbsenceListView.GridLines = true;
            AbsenceListView.FullRowSelect = true;
            AbsenceListView.Scrollable = true;

            AbsenceListView.Columns.Add("Playername", 200);
            AbsenceListView.Columns.Add("Absent at", 180);

            _absences.Data = _absences.Data.OrderByDescending(absence => absence.Operation.Starts_at.Date);

            foreach (Absence upcomingAbsence in _absences.Data)
            {
                string[] arr = new string[2];
                arr[0] = upcomingAbsence.User.Name;
                arr[1] = upcomingAbsence.Operation.Starts_at.Date.ToLongDateString();

                if (upcomingAbsence.IsFuture)
                {
                    var item = new ListViewItem(arr);
                    item.Font = new Font(item.Font, FontStyle.Bold);

                    AbsenceListView.Items.Add(item);
                }
                else
                {
                    AbsenceListView.Items.Add(new ListViewItem(arr));
                }                
            }
        }
    }
}
