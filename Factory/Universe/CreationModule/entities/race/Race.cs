using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.Universe.CreationModule.entities.race
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
            RaceID = string.Empty;
            RaceName = string.Empty;
            RaceInformation = new RaceDescription();
            RaceAppearenceDescription = string.Empty;
            RaceLore = string.Empty;
        }

        public Race(string raceID,
                    string raceName,
                    string raceAppearenceDescription,
                    string raceLore)
        {
            RaceID = raceID;
            RaceName = raceName;
            RaceAppearenceDescription = raceAppearenceDescription;
            RaceLore = raceLore;
        }

        public Race(string raceID,
                    string raceName,
                    RaceDescription raceInformation,
                    string raceAppearenceDescription,
                    string raceLore)
        {
            RaceID = raceID;
            RaceName = raceName;
            RaceInformation = raceInformation;
            RaceAppearenceDescription = raceAppearenceDescription;
            RaceLore = raceLore;
        }

        public void SetRaceInformation(RaceDescription raceInformation)
        {
            RaceInformation = raceInformation;
        }
    }
}
