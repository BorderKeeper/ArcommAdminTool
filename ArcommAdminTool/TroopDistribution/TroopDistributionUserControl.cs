using System.Windows.Forms;
using ArcommAdminTool.TroopDistribution.Entities;

namespace ArcommAdminTool.TroopDistribution
{
    public partial class TroopDistributionUserControl : UserControl
    {
        private readonly TroopDistributionCalculator _calculator;

        public bool IsPvp => PvpCheckbox.Checked;

        public decimal BluforRatio
        {
            get
            {
                var success = decimal.TryParse(BluforRatioText.Text, out decimal bluforRatio);

                if (success)
                {
                    return bluforRatio;
                }

                BluforRatioText.Text = "1";
                return BluforRatio;
            }
        }

        public decimal OpforRatio
        {
            get
            {
                var success = decimal.TryParse(OpforRatioText.Text, out decimal opforRatio);

                if (success)
                {
                    return opforRatio;
                }

                OpforRatioText.Text = "1";
                return OpforRatio;
            }
        }

        public decimal Ratio => OpforRatio / (BluforRatio + OpforRatio);

        public int NumberOfPlayers
        {
            get
            {
                int.TryParse(NumberOfPlayersTextbox.Text, out int numberOfPlayers);
                return numberOfPlayers;
            }
        }

        public int SpecialRolePlayers
        {
            get
            {
                int.TryParse(SpecialRolePlayersText.Text, out int specialRolePlayers);
                return specialRolePlayers;
            }
        }

        public int IdealFireteamSize
        {
            get
            {
                int.TryParse(IdealFireteamSizeUpDown.Text, out int idealFireteamSize);
                return idealFireteamSize;
            }
        }

        public TroopDistributionUserControl()
        {
            InitializeComponent();
            PvpFieldsVisibility(false);
            _calculator = new TroopDistributionCalculator();
        }

        private void PvpCheckbox_CheckedChanged(object sender, System.EventArgs e)
        {
            PvpFieldsVisibility(PvpCheckbox.Checked);
        }

        private void PvpFieldsVisibility(bool visible)
        {
            PvpDelimiter.Visible = visible;
            BluforRatioText.Visible = visible;
            OpforRatioText.Visible = visible;
        }

        private void CalculateButton_Click(object sender, System.EventArgs e)
        {
            TroopDistributionTree.Nodes.Clear();

            TroopDistributionResult result = _calculator.Calculate(new TroopDistributionCommand
            {
                IsPvp = IsPvp,
                NumberOfPlayers = NumberOfPlayers,
                Ratio = IsPvp ? Ratio : new decimal?(),
                SpecialRolePlayers = SpecialRolePlayers,
                MinimumFireteamSize = IdealFireteamSize
            });

            TroopDistributionTree.Nodes.AddRange(result.ToTree());
            TroopDistributionTree.ExpandAll();
        }
    }
}
