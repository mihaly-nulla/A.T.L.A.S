using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genesis.Factory.Universe.CreationModule.components.location;
using Newtonsoft.DTO.World._Environment;

namespace Newtonsoft.DTO.World
{
    public class UniverseMapper : IMapper<UniverseEnvironments, UniverseEnvironmentsDTO>
    {
        public UniverseEnvironments FromDTO(UniverseEnvironmentsDTO destination)
        {
            var environmentMapper = new EnvironmentMapper();

            return new UniverseEnvironments
            {
                UniverseResourcesDatabase = destination.UniverseResourcesDatabase.ToDictionary(
                    pair => pair.Key,
                    pair => environmentMapper.FromDTO(pair.Value)
                )
            };
        }

        public UniverseEnvironmentsDTO ToDTO(UniverseEnvironments source)
        {
            var environmentMapper = new EnvironmentMapper();

            return new UniverseEnvironmentsDTO
            {
                UniverseResourcesDatabase = source.UniverseResourcesDatabase.ToDictionary(
                    pair => pair.Key,
                    pair => environmentMapper.ToDTO(pair.Value)
                )
            };
        }
    }
}
