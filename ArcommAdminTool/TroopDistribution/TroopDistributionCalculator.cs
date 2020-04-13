using System;
using System.Linq;
using ArcommAdminTool.TroopDistribution.Entities;
using ArcommAdminTool.TroopDistribution.TrainingData;

namespace ArcommAdminTool.TroopDistribution
{
    public class TroopDistributionCalculator
    {
        public static int FullLeadership = 2;

        public static int NumberOfZeuses = 1;

        private readonly TrainingDataProvider _dataProvider;

        public TroopDistributionCalculator()
        {
            _dataProvider = new TrainingDataProvider();
        }

        public TroopDistributionResult Calculate(TroopDistributionCommand command)
        {
            var trainingDataResult = _dataProvider.GetTrainingData();

            var bluforPlayers = (int) Math.Ceiling(command.IsPvp ? GetBluforPlayersForPvp(command) : GetBluforPlayersForCoop(command));
            var opforPlayers = command.PlayersForCalculation - bluforPlayers;           

            Platoon blufor = ConvertTrainingSet(trainingDataResult, bluforPlayers, command.MinimumFireteamSize, TeamSide.Blufor);
            Platoon opfor = null;
            if (opforPlayers != 0)
            {
                opfor = ConvertTrainingSet(trainingDataResult, opforPlayers, command.MinimumFireteamSize, TeamSide.Opfor);
            }

            var unusedPlayers = command.PlayersForCalculation - (bluforPlayers + opforPlayers);

            return new TroopDistributionResult
            {
                Blufor = blufor,
                Opfor = opfor,
                SpecialRoles = command.SpecialRolePlayers != 0 ? new SpecialPlatoon("Special roles", command.SpecialRolePlayers) : null,
                ExtraPlayers = unusedPlayers != 0 ? new SpecialPlatoon("Unused players", unusedPlayers) : null,
                Zeus = command.IsPvp ? null : new SpecialPlatoon("Zeus", NumberOfZeuses)
            };
        }

        private static int GetBluforPlayersForCoop(TroopDistributionCommand command)
        {
            return command.PlayersForCalculation - NumberOfZeuses;
        }

        private static decimal GetBluforPlayersForPvp(TroopDistributionCommand command)
        {
            return command.PlayersForCalculation * command.Ratio.Value;
        }

        private Platoon ConvertTrainingSet(TrainingSet set, int numberOfPlayers, int minimumFireteamSize, TeamSide side)
        {
            var chosenPlatoon = ChoosePlatoon(set, numberOfPlayers, minimumFireteamSize);

            Platoon platoon = new Platoon(side, minimumFireteamSize);

            platoon.SupporingRoles = int.Parse(chosenPlatoon.players);

            int squadCounter = 0;
            foreach (TrainingSetPlatoonSquad trainingSquad in chosenPlatoon.Squad)
            {
                var squad = platoon.AddSquad((SquadSign) squadCounter);
                squad.SupportingRoles = int.Parse(trainingSquad.players);

                foreach (TrainingSetPlatoonSquadFireteam trainingFireteam in trainingSquad.Fireteam)
                {
                    squad.AddFireTeam(int.Parse(trainingFireteam.players));
                }

                squadCounter++;
            }

            return platoon;
        }

        private TrainingSetPlatoon ChoosePlatoon(TrainingSet set, int numberOfPlayers, int minimumFireteamSize)
        {
            //Get all training platoons that match the player count, could differ in FT distribution
            var matchingPlayerCount = set.Items.Where(trainingPlatoon => int.Parse(trainingPlatoon.totalPlayers) == numberOfPlayers);

            //If number of players is too big, then return the biggest
            if (!matchingPlayerCount.Any())
            {
                var biggestSet = set.Items.Select(trainingPlatoon => int.Parse(trainingPlatoon.totalPlayers)).Max();
                matchingPlayerCount = set.Items.Where(trainingPlatoon => int.Parse(trainingPlatoon.totalPlayers) == biggestSet);
            }

            //Get the biggest fireteam size available, but not bigger than minimumFireteamSize
            //ie. If 6 is selected choose biggest in this order 6 5 4, because 6 is last. if 4 is selected select 4
            return matchingPlayerCount.Last(trainingPlatoon => int.Parse(trainingPlatoon.minimumSize) <= minimumFireteamSize);
        }
    }
}