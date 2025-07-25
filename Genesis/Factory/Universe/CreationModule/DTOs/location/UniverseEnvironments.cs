using Genesis.Factory.Universe.CreationModule.components;
using Genesis.Factory.Universe.CreationModule.DTOs.race;
using Genesis.Factory.Universe.CreationModule.entities.race;
using Genesis.Factory.Universe.CreationModule.entities.region;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace Genesis.Factory.Universe.CreationModule.DTOs.location
{
    public class UniverseEnvironments : UniversePersistence<UniverseEnvironments>, UniverseResourceInterface<WorldEnvironment, UniverseEnvironments>
    {
        [JsonProperty("world_environments")]
        public Dictionary<string, WorldEnvironment> UniverseResourcesDatabase { get; set; }

        public UniverseEnvironments()
        {
            this.UniverseResourcesDatabase = new Dictionary<string, WorldEnvironment>();
        }

        public UniverseEnvironments(Dictionary<string, WorldEnvironment> worldEnvironments)
        {
            this.UniverseResourcesDatabase = worldEnvironments ?? new Dictionary<string, WorldEnvironment>();
        }

        /// <summary>
        /// Obtém uma definição de environment pelo seu ID (funciona em uma instância já carregada).
        /// </summary>
        public WorldEnvironment GetResourceById(string environmentId)
        {
            if (this.UniverseResourcesDatabase.ContainsKey(environmentId))
            {
                return this.UniverseResourcesDatabase[environmentId];
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
