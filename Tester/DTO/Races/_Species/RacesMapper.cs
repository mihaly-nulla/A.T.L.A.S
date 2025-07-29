using Genesis.Factory.Universe.CreationModule.entities.race;
using Newtonsoft.DTO.Races._Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.Races._Species
{
    public class RacesMapper : IMapper<Race, RaceDTO>
    {
        public Race FromDTO(RaceDTO destination)
        {
            return new Race
            {
                RaceID = destination.RaceID,
                RaceName = destination.RaceName,
                RaceAppearenceDescription = destination.RaceAppearenceDescription,
                RaceLore = destination.RaceLore,
                RaceInformation = new RaceDescriptionMapper().FromDTO(destination.RaceDescription)
            };
        }

        public RaceDTO ToDTO(Race source)
        {
            return new RaceDTO
            {
                RaceID = source.RaceID,
                RaceName = source.RaceName,
                RaceAppearenceDescription = source.RaceAppearenceDescription,
                RaceLore = source.RaceLore,
                RaceDescription = new RaceDescriptionMapper().ToDTO(source.RaceInformation)
            };
        }
    }
}
