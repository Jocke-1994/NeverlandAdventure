namespace NeverlandAdventure.Events
{
    public class StructuredEvent
    {
        public string Name { get; set; }
        public string Trigger { get; set; }
        public double BaseChance { get; set; }
        public List<string> Choices { get; set; } = new();
        public string SuccessOutcome { get; set; }
        public string FailureOutcome { get; set; }
        public string StatusReport { get; set; }
        public List<string> FollowupNPCs { get; set; } = new();
    }
}