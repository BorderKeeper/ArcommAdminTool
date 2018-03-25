namespace ArcommAdminTool.TroopDistribution.Entities
{
    public class TroopDistributionCommand
    {
        public int NumberOfPlayers { get; set; }

        public bool IsPvp { get; set; }

        public int SpecialRolePlayers { get; set; }

        public decimal? Ratio { get; set; }

        public int MinimumFireteamSize { get; set; }

        public int PlayersForCalculation => NumberOfPlayers - SpecialRolePlayers;
    }
}