using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.DTO.Races._Species;
using Newtonsoft.Json;

namespace Newtonsoft.DTO.Races
{
    public class UniverseRacesDTO
    {
        [JsonProperty("world_races")]
        public Dictionary<string, RaceDTO> UniverseResourcesDatabase { get; set; }
    }
}
