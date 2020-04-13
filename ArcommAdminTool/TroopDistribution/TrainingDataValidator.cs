using System;
using System.Collections.Generic;
using System.Linq;
using ArcommAdminTool.Common.Exceptions;
using ArcommAdminTool.TroopDistribution.TrainingData;

namespace ArcommAdminTool.TroopDistribution
{
    public interface ITrainingDataValidator
    {
        void Validate();
    }

    public class TrainingDataValidator
    {
        private readonly ITrainingDataProvider _dataProvider;

        private readonly IList<string> _errorMessages;

        public TrainingDataValidator()
        {
            _dataProvider = new TrainingDataProvider();
            _errorMessages = new List<string>();
        }

        public void Validate()
        {
            var dataSet = _dataProvider.GetTrainingData();

            foreach (var platoon in dataSet.Items)
            {
                ValidatePlatoon(platoon);
            }

            if (_errorMessages.Any())
            {
                ExceptionHandler.ShowValidationErrorBox(string.Join("\n", _errorMessages));
            }
        }

        private void ValidatePlatoon(TrainingSetPlatoon platoon)
        {
            var expectedPlayerCount = ParseString(platoon.totalPlayers, "total player");

            int realPlayerCount = ParseString(platoon.players, "platoon lead");

            foreach (var squad in platoon.Squad)
            {
                realPlayerCount += GetSquadPlayerCount(squad);
            }

            if (expectedPlayerCount != realPlayerCount)
            {
                _errorMessages.Add($"Platoon of size {expectedPlayerCount} and ideal ft size of {platoon.minimumSize} is actually {realPlayerCount} sized.");
            }
        }

        private int GetSquadPlayerCount(TrainingSetPlatoonSquad squad)
        {
            var squadSize = ParseString(squad.players, "squad lead");

            foreach (var fireTeam in squad.Fireteam)
            {
                squadSize += ParseString(fireTeam.players, "fireteam");
            }

            return squadSize;
        }

        private int ParseString(string rawNumber, string name)
        {
            if (!int.TryParse(rawNumber, out var number))
            {
                _errorMessages.Add($"Training data set contains {rawNumber} as {name} size, but number was expected.");
            }

            return number;
        }
    }
}