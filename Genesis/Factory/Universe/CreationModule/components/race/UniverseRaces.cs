using Genesis.Factory.Universe.CreationModule.components;
using Genesis.Factory.Universe.CreationModule.entities.race;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Factory.Universe.CreationModule.components.race
{
    public class UniverseRaces : UniverseResourceInterface<Race, UniverseRaces>
    {
        public Dictionary<string, Race> UniverseResourcesDatabase { get; set; }

        public UniverseRaces()
        {
            UniverseResourcesDatabase = new Dictionary<string, Race>();
        }

        public UniverseRaces(Dictionary<string, Race> worldRaces)
        {
            UniverseResourcesDatabase = worldRaces ?? new Dictionary<string, Race>();
        }

        /// <summary>
        /// Obtém uma definição de raça pelo seu ID (funciona em uma instância já carregada).
        /// </summary>
        public Race GetResourceById(string raceId)
        {
            if (UniverseResourcesDatabase.ContainsKey(raceId))
            {
                return UniverseResourcesDatabase[raceId];
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
