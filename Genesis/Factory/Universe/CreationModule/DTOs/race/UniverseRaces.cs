using Genesis.Factory.Universe.CreationModule.components;
using Genesis.Factory.Universe.CreationModule.entities.race;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace Genesis.Factory.Universe.CreationModule.DTOs.race
{
    public class UniverseRaces : UniversePersistence<UniverseRaces>, UniverseResourceInterface<Race, UniverseRaces>
    {
        [JsonProperty("world_races")]
        public Dictionary<string, Race> UniverseResourcesDatabase { get; set; }

        public UniverseRaces()
        {
            this.UniverseResourcesDatabase = new Dictionary<string, Race>();
        }

        public UniverseRaces(Dictionary<string, Race> worldRaces)
        {
            this.UniverseResourcesDatabase = worldRaces ?? new Dictionary<string, Race>();
        }

        /// <summary>
        /// Obtém uma definição de raça pelo seu ID (funciona em uma instância já carregada).
        /// </summary>
        public Race GetResourceById(string raceId)
        {
            if (this.UniverseResourcesDatabase.ContainsKey(raceId))
            {
                return this.UniverseResourcesDatabase[raceId];
            }
            return null;
        }

        public bool CheckIfEmpty()
        {
            if (this.UniverseResourcesDatabase == null || this.UniverseResourcesDatabase.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
