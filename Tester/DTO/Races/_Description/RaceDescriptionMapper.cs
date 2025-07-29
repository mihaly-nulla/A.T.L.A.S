using Genesis.Factory.Universe.CreationModule.entities.race;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.Races._Description
{
    public class RaceDescriptionMapper : IMapper<RaceDescription, RaceDescriptionDTO>
    {
        public RaceDescription FromDTO(RaceDescriptionDTO destination)
        {
            return new RaceDescription
            {
                RacialGeneralOverview = destination.RacialGeneralOverview,
                RacialCulturalValues = destination.RacialCulturalValues,
                RacialSocialBehavior = destination.RacialSocialBehavior,
                RacialAbilities = destination.RacialAbilities
            };
        }

        public RaceDescriptionDTO ToDTO(RaceDescription source)
        {
            return new RaceDescriptionDTO
            {
                RacialGeneralOverview = source.RacialGeneralOverview,
                RacialCulturalValues = source.RacialCulturalValues,
                RacialSocialBehavior = source.RacialSocialBehavior,
                RacialAbilities = source.RacialAbilities
            };
        }
    }
}
