using System;
using System.Collections.Generic;
using System.Text;
using Genesis.Factory.Universe.CreationModule.entities.region;

namespace Newtonsoft.DTO.World._Location
{
    public class LocationMapper : IMapper<Location, LocationDTO>
    {
        public Location FromDTO(LocationDTO destination)
        {
            return new Location
            {
                LocationID = destination.LocationID,
                LocationName = destination.LocationName,
                LocationType = destination.LocationType,
                LocationDescription = destination.LocationDescription,
                LocationKeyFeatures = destination.LocationKeyFeatures ?? new List<string>()
            };
        }

        public LocationDTO ToDTO(Location source)
        {
            return new LocationDTO
            {
                LocationID = source.LocationID,
                LocationName = source.LocationName,
                LocationType = source.LocationType,
                LocationDescription = source.LocationDescription,
                LocationKeyFeatures = source.LocationKeyFeatures ?? new List<string>()
            };
        }
    }
}
