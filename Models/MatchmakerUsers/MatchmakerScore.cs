namespace MatchmakerBotAPI.Core.Models.MatchmakerUsers
{
    public class MatchmakerScoreModel
    {
        public string channelId { get; set; }

        public int wins { get; set; }

        public int losses { get; set; }

        public int mmr { get; set; }
    }
}