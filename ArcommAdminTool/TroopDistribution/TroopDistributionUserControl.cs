using System;
using System.Windows.Forms;
using ArcommAdminTool.Common.Exceptions;
using ArcommAdminTool.Common.Extensions;
using ArcommAdminTool.TroopDistribution.Entities;

namespace ArcommAdminTool.TroopDistribution
{
    public partial class TroopDistributionUserControl : UserControl
    {
        private const string ValidationAlert = "One of the fields entered above was invalid";

        private readonly TroopDistributionCalculator _calculator;

        public bool IsPvp => PvpCheckbox.Checked;

        public decimal BluforRatio => decimal.Parse(BluforRatioText.Text.IsEmpty() ? "0" : BluforRatioText.Text.RemoveNonDecimalChars());

        public decimal OpforRatio => decimal.Parse(OpforRatioText.Text.IsEmpty() ? "0" : OpforRatioText.Text.RemoveNonDecimalChars());

        public decimal Ratio => OpforRatio / (BluforRatio + OpforRatio);

        public int NumberOfPlayers => int.Parse(NumberOfPlayersTextbox.Text.IsEmpty() ? "0" : NumberOfPlayersTextbox.Text);

        public int SpecialRolePlayers => int.Parse(SpecialRolePlayersText.Text.IsEmpty() ? "0" : SpecialRolePlayersText.Text);

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

        private void PvpCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            PvpFieldsVisibility(PvpCheckbox.Checked);
        }

        private void PvpFieldsVisibility(bool visible)
        {
            PvpDelimiter.Visible = visible;
            BluforRatioText.Visible = visible;
            OpforRatioText.Visible = visible;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            TroopDistributionTree.Nodes.Clear();

            var success = GetCommand(out TroopDistributionCommand command);

            if (!success)
            {
                ExceptionHandler.ShowValidationErrorBox(ValidationAlert);
                return;
            }

            TroopDistributionResult result = _calculator.Calculate(command);

            TroopDistributionTree.Nodes.AddRange(result.ToTree());
            TroopDistributionTree.ExpandAll();
        }

        private bool GetCommand(out TroopDistributionCommand command)
        {
            try
            {
                command = new TroopDistributionCommand
                {
                    IsPvp = IsPvp,
                    NumberOfPlayers = NumberOfPlayers,
                    Ratio = IsPvp ? Ratio : new decimal?(),
                    SpecialRolePlayers = SpecialRolePlayers,
                    MinimumFireteamSize = IdealFireteamSize,
                    NumberOfZeuses = IsPvp ? 0 : 1
                };

                return true;
            }
            catch (Exception)
            {
                command = new TroopDistributionCommand();
                return false;
            }
        }
    }
}
