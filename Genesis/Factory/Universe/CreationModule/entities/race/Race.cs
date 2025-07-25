using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace Genesis.Factory.Universe.CreationModule.entities.race
{
    public class Race
    {
        [JsonProperty("race_id")]
        public string RaceID { get; set; }

        [JsonProperty("race_name")]
        public string RaceName { get; set; }

        [JsonProperty("race_description")]
        public RaceDescription RaceInformation { get; set; }

        [JsonProperty("race_appearence_description")]
        public string RaceAppearenceDescription { get; set; }

        [JsonProperty("race_lore")]
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
