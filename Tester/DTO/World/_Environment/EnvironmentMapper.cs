using Genesis.Factory.Universe.CreationModule.entities.region;
using Newtonsoft.DTO.World._Location;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Newtonsoft.DTO.World._Environment
{
    public class EnvironmentMapper : IMapper<WorldEnvironment, WorldEnvironmentDTO>
    {
        public WorldEnvironment FromDTO(WorldEnvironmentDTO destination)
        {
            var locationMapper = new LocationMapper();

            return new WorldEnvironment
            {
                EnvironmentID = destination.EnvironmentID,
                EnvironmentName = destination.EnvironmentName,
                EnvironmentType = destination.EnvironmentType,
                EnvironmentDescription = destination.EnvironmentDescription,
                EnvironmentCharacteristics = destination.EnvironmentCharacteristics,
                EnvironmentHistoricalContext = destination.EnvironmentHistoricalContext,
                EnvironmentMajorLocations = destination.EnvironmentMajorLocations.ToDictionary
                (
                    pair => pair.Key,
                    pair => locationMapper.FromDTO(pair.Value)
                )
            };
        }
        public WorldEnvironmentDTO ToDTO(WorldEnvironment source)
        {
            return new WorldEnvironmentDTO
            {
                EnvironmentID = source.EnvironmentID,
                EnvironmentName = source.EnvironmentName,
                EnvironmentType = source.EnvironmentType,
                EnvironmentDescription = source.EnvironmentDescription,
                EnvironmentCharacteristics = source.EnvironmentCharacteristics,
                EnvironmentHistoricalContext = source.EnvironmentHistoricalContext,
                EnvironmentMajorLocations = source.EnvironmentMajorLocations.ToDictionary
                (
                    pair => pair.Key,
                    pair => new LocationMapper().ToDTO(pair.Value)
                )
            };
        }
    }
}
