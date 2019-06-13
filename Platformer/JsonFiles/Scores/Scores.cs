using System.Collections.Generic;

using Newtonsoft.Json;

namespace Platformer
{
    public class Scores
    {
        [JsonProperty("items")]
        public List<ScoreItem> Items { get; set; }
    }

    public class ScoreItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
        [JsonProperty("isLast")]
        public bool IsLast { get; set; }

        public ScoreItem(string name, int score, bool isLast)
        {
            Name = name;
            Score = score;
            IsLast = isLast;
        }
    }
}
