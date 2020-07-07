using System;

namespace HumanRazor.Models
{
    public class ActivityDataModel
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string date { get; set; }
        public int duration { get; set; }
        public int distance { get; set; }
        public int steps { get; set; }
        public int calories { get; set; }
        public string source { get; set; }
        public int vigorous { get; set; }
        public int moderate { get; set; }
        public int light { get; set; }
        public int sedentary { get; set; }
        public SourcedataModel sourceData { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string humanId { get; set; }
    }

}
