using A.T.L.A.S.Factory.Universe.CreationModule.components;
using A.T.L.A.S.Factory.Universe.CreationModule.DTOs.race;
using A.T.L.A.S.Factory.Universe.CreationModule.entities.race;
using A.T.L.A.S.Factory.Universe.CreationModule.entities.region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.Universe.CreationModule.DTOs.location
{
    public class UniverseEnvironments : UniversePersistence<UniverseEnvironments>, UniverseResourceInterface<WorldEnvironment, UniverseEnvironments>
    {
        [JsonPropertyName("world_environments")]
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
    }
}
