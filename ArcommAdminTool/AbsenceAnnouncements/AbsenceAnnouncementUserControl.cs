using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcommAdminTool.AbsenceAnnouncements.Entities;
using ArcommAdminTool.AbsenceAnnouncements.Services.AbsenceService;
using ArcommAdminTool.AbsenceAnnouncements.Services.AbsenceService.Contract;
using ArcommAdminTool.AbsenceAnnouncements.Services.SteamService;
using ArcommAdminTool.AbsenceAnnouncements.Services.SteamService.Contract;

namespace ArcommAdminTool.AbsenceAnnouncements
{
    public partial class AbsenceAnnouncementUserControl : UserControl
    {
        private const string PlayernameColumn = "Playername";
        private const int PlayernameColumnWidth = 200;
        private const string AbsentAtColumn = "Day Absent";
        private const int AbsentAtColumnWidth = 180;
        private const string LoadingString = "Loading Data...";
        private const string TimeoutString = "No response from the server.";

        private const int AbsenceTimeoutMiliseconds = 20000;

        private readonly ListViewColumnSorter _columnSorter;
        private readonly AbsenceService _absenceService;
        private readonly SteamUserService _steamUserService;

        private IList<SteamUser> _steamUsers;
        private IList<PlayerAbsenceListRow> _absenceList;

        public AbsenceAnnouncementUserControl()
        {
            InitializeComponent();

            _absenceService = new AbsenceService();
            _steamUserService = new SteamUserService();
            _steamUsers = new List<SteamUser>();

            _columnSorter = new ListViewColumnSorter();
            AbsenceListView.ListViewItemSorter = _columnSorter;
        }

        private void AbsenceAnnouncementUserControl_Load(object sender, EventArgs e)
        {
            FilterClear.Hide();
            InitializeAbsenceView();

            SetupAbsenceList();
            //LoadPlayersImages(absencesTask); //TODO: Use this for something
        }

        private void InitializeAbsenceView()
        {
            AbsenceListView.View = View.Details;
            AbsenceListView.GridLines = true;
            AbsenceListView.FullRowSelect = true;
            AbsenceListView.Scrollable = true;

            AbsenceListView.Columns.Add(PlayernameColumn, PlayernameColumnWidth);
            AbsenceListView.Columns.Add(AbsentAtColumn, AbsentAtColumnWidth);

            _absenceList = new List<PlayerAbsenceListRow>();
        }

        private async Task SetupAbsenceList()
        {
            var absencesTask = _absenceService.GetAbsences();

            AbsenceListView.Items.Clear();
            AbsenceListView.Items.Add(new AbsenceListRow(LoadingString, string.Empty, false));

            if (await Task.WhenAny(absencesTask, Task.Delay(AbsenceTimeoutMiliseconds)) == absencesTask)
            {            
                DisplayAbsences(absencesTask.Result.Data);
            }
            else
            {
                AbsenceListView.Items.Clear();
                AbsenceListView.Items.Add(new AbsenceListRow(TimeoutString, string.Empty, false));
            }
        }

        private void DisplayAbsences(IEnumerable<Absence> absences)
        {
            absences = absences.OrderByDescending(a => a.Operation.Starts_at.Date);
            AbsenceListView.Items.Clear();
            _absenceList.Clear();

            string[] arr = new string[2];
            foreach (Absence upcomingAbsence in absences)
            {
                arr[0] = upcomingAbsence.User.Name;
                arr[1] = upcomingAbsence.Operation.Starts_at.Date.ToLongDateString();

                var isUpcoming = upcomingAbsence.ThisWeek && upcomingAbsence.IsFuture;
                var item = new PlayerAbsenceListRow(upcomingAbsence.User.Name, upcomingAbsence.Operation.Starts_at.Date.ToLongDateString(), isUpcoming);

                AbsenceListView.Items.Add(item);
                _absenceList.Add(item);
            }
        }

        private async Task LoadPlayersImages(Task<Absences> absencesTask)
        {
            var absences = (await absencesTask).Data;
            var steamPlayers = await _steamUserService.GetPlayersImageUrl(absences.Select(absence => absence.User.Steam_id));

            foreach (Player steamPlayer in steamPlayers.Players)
            {
                _steamUsers.Add(new SteamUser
                {
                    Avatar = steamPlayer.Avatar,
                    PersonaName = steamPlayer.PersonaName,
                    ProfileUrl = steamPlayer.ProfileUrl,
                    SteamId = steamPlayer.SteamId
                });
            }
        }

        private void AbsenceListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _columnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_columnSorter.Order == SortOrder.Ascending)
                {
                    _columnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    _columnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _columnSorter.SortColumn = e.Column;
                _columnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            AbsenceListView.Sort();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            FilterClear.Hide();
            SetupAbsenceList();
        }

        private void AbsenceListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = AbsenceListView.FocusedItem;

                if (focusedItem.Bounds.Contains(e.Location) && focusedItem is PlayerAbsenceListRow)
                {                    
                    PlayerContextStrip.Show(Cursor.Position);                   
                }
            }
        }

        private void FilterClear_Click(object sender, EventArgs e)
        {
            FilterClear.Hide();

            AbsenceListView.Items.Clear();
            foreach (var item in _absenceList)
            {
                AbsenceListView.Items.Add(item);
            }
        }

        private void FilterByName_Click(object sender, EventArgs e)
        {
            FilterClear.Show();

            var focusedItem = AbsenceListView.FocusedItem;
            if (focusedItem is PlayerAbsenceListRow focusedPlayerRow)
            {
                var filteredItems = _absenceList.Where(playerRow => playerRow.PlayerName.Equals(focusedPlayerRow.PlayerName, StringComparison.InvariantCultureIgnoreCase));

                AbsenceListView.Items.Clear();
                foreach (var item in filteredItems)
                {
                    AbsenceListView.Items.Add(item);
                }
            }

        }
    }
}
