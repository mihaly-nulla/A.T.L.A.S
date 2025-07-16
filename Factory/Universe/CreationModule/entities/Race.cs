using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.World.CreationModule.entities
{
    public class Race
    {
        [JsonPropertyName("race_id")]
        public string RaceID { get; set; }

        [JsonPropertyName("race_name")]
        public string RaceName { get; set; }

        [JsonPropertyName("race_description")]
        public RaceDescription RaceInformation { get; set; }

        [JsonPropertyName("race_appearence_description")]
        public string RaceAppearenceDescription { get; set; }

        [JsonPropertyName("race_lore")]
        public string RaceLore { get; set; }

        public Race() 
        {
            this.RaceID = string.Empty;
            this.RaceName = string.Empty;
            this.RaceInformation = new RaceDescription();
            this.RaceAppearenceDescription = string.Empty;
            this.RaceLore = string.Empty;
        }

        public Race(string raceID,
                    string raceName,
                    string raceAppearenceDescription,
                    string raceLore)
        {
            this.RaceID = raceID;
            this.RaceName = raceName;
            this.RaceAppearenceDescription = raceAppearenceDescription;
            this.RaceLore = raceLore;
        }

        public Race(string raceID,
                    string raceName,
                    RaceDescription raceInformation,
                    string raceAppearenceDescription,
                    string raceLore)
        {
            this.RaceID = raceID;
            this.RaceName = raceName;
            this.RaceInformation = raceInformation;
            this.RaceAppearenceDescription = raceAppearenceDescription;
            this.RaceLore = raceLore;
        }

        public void SetRaceInformation(RaceDescription raceInformation)
        {
            this.RaceInformation = raceInformation;
        }
    }
}
