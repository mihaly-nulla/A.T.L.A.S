using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.DTO.World._Environment;
using Newtonsoft.Json;

namespace Newtonsoft.DTO.World
{
    public class UniverseEnvironmentsDTO
    {
        [JsonProperty("world_environments")]
        public Dictionary<string, WorldEnvironmentDTO> UniverseResourcesDatabase { get; set; }
    }
}
