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
        public uint Score { get; set; }
        [JsonProperty("time")]
        public uint Time { get; set; }

        public ScoreItem(string name, uint score, uint time)
        {
            Name = name;
            Score = score;
            Time = time;
        }
    }
}
