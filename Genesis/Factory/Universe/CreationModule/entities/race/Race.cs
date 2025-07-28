using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genesis.Factory.Universe.CreationModule.entities.race
{
    public class Race
    {
        public string RaceID { get; set; }

        public string RaceName { get; set; }

        public RaceDescription RaceInformation { get; set; }

        public string RaceAppearenceDescription { get; set; }

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
