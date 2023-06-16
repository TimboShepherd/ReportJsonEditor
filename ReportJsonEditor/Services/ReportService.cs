using Newtonsoft.Json;
using ReportJsonEditor.Models;

namespace ReportJsonEditor.Services
{
    public class JsonService
    {
        private readonly string jsonFilePath;

        public JsonService(string jsonFilePath)
        {
            this.jsonFilePath = jsonFilePath;
        }

        public Report ReadReportData()
        {
            string json = File.ReadAllText(jsonFilePath);
            Report report = JsonConvert.DeserializeObject<Report>(json);
            return report;
        }

        public void WriteReportData(Report report)
        {
            string json = JsonConvert.SerializeObject(report, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
    }
}