using System;
using System.IO;
using System.Xml.Serialization;
namespace ArcommAdminTool.TroopDistribution.TrainingData
{
    public class TrainingDataProvider
    {
        private const string TrainingDataFileName = "TrainingData.xml";

        public TrainingSet GetTrainingData()
        {
            var trainingData = LoadXmlFile();

            var serializer = new XmlSerializer(typeof(TrainingSet));

            try
            {
                using (var reader = new StringReader(trainingData))
                {
                    return (TrainingSet) serializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"File could not be parsed. Innex message: {ex}", ex);
            }
        }

        private string LoadXmlFile()
        {
            var rootFolder = AppDomain.CurrentDomain.BaseDirectory;

            var filesInFolder = Directory.GetFiles(rootFolder);

            foreach (var filePath in filesInFolder)
            {
                if (filePath.EndsWith(TrainingDataFileName, StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        return File.ReadAllText(filePath);
                    }
                    catch (Exception ex)
                    {
                        throw new IOException($"File could not be loaded. Inner exception message: {ex}", ex);
                    }
                }
            }

            throw new IOException($"{TrainingDataFileName} was not found in root directory. Please place file here: {rootFolder}");
        }
    }
}
