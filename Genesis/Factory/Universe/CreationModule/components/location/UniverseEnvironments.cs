using Genesis.Factory.Universe.CreationModule.components;
using Genesis.Factory.Universe.CreationModule.entities.race;
using Genesis.Factory.Universe.CreationModule.entities.region;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Factory.Universe.CreationModule.components.location
{
    public class UniverseEnvironments : UniverseResourceInterface<WorldEnvironment, UniverseEnvironments>
    {
        public Dictionary<string, WorldEnvironment> UniverseResourcesDatabase { get; set; }

        public UniverseEnvironments()
        {
            UniverseResourcesDatabase = new Dictionary<string, WorldEnvironment>();
        }

        public UniverseEnvironments(Dictionary<string, WorldEnvironment> worldEnvironments)
        {
            UniverseResourcesDatabase = worldEnvironments ?? new Dictionary<string, WorldEnvironment>();
        }

        /// <summary>
        /// Obtém uma definição de environment pelo seu ID (funciona em uma instância já carregada).
        /// </summary>
        public WorldEnvironment GetResourceById(string environmentId)
        {
            if (UniverseResourcesDatabase.ContainsKey(environmentId))
            {
                return UniverseResourcesDatabase[environmentId];
            }
            return null;
        }

        public bool CheckIfEmpty()
        {
            if (UniverseResourcesDatabase == null || UniverseResourcesDatabase.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
