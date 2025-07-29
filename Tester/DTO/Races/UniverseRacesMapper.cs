using Genesis.Factory.Universe.CreationModule.components.race;
using Newtonsoft.DTO.Races._Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newtonsoft.DTO.Races
{
    public class UniverseRacesMapper : IMapper<UniverseRaces, UniverseRacesDTO>
    {
        public UniverseRaces FromDTO(UniverseRacesDTO destination)
        {
            return new UniverseRaces
            {
                UniverseResourcesDatabase = destination.UniverseResourcesDatabase.ToDictionary(
                    pair => pair.Key,
                    pair => new RacesMapper().FromDTO(pair.Value)
                )
            };
        }

        public UniverseRacesDTO ToDTO(UniverseRaces source)
        {
            return new UniverseRacesDTO
            {
                UniverseResourcesDatabase = source.UniverseResourcesDatabase.ToDictionary(
                    pair => pair.Key,
                    pair => new RacesMapper().ToDTO(pair.Value)
                )
            };  
        }
    }
}
