using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Factory.Universe.CreationModule.entities.race
{
    public class RaceDescription
    {
        public string RacialGeneralOverview { get; set; }

        public string RacialCulturalValues { get; set; }

        public string RacialSocialBehavior { get; set; }

        public string RacialAbilities { get; set; }

        public RaceDescription()
        {
            RacialGeneralOverview = string.Empty;
            RacialCulturalValues = string.Empty;
            RacialSocialBehavior = string.Empty;
            RacialAbilities = string.Empty;
        }

        public RaceDescription(string racialGeneralOverview,
                               string racialCulturalValues,
                               string racialSocialBehavior,
                               string racialAbilities)
        {
            RacialGeneralOverview = racialGeneralOverview;
            RacialCulturalValues = racialCulturalValues;
            RacialSocialBehavior = racialSocialBehavior;
            RacialAbilities = racialAbilities;
        }
    }
}
