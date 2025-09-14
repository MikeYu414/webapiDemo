namespace Batchjob.App.Models
{
    public class JobSettingModel
    {
        public Dictionary<string, string> ClassLogGroups { get; set; } = new Dictionary<string, string>();
        public bool SwaggerEnabled { get; set; }
        public int TimerInterval { get; set; }
        public bool DebugMode { get; set; }
        public int MaxConcurrentJobs { get; set; }

    }
}
