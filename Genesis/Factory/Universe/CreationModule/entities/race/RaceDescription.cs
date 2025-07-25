using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json; 
namespace Genesis.Factory.Universe.CreationModule.entities.race
{
    public class RaceDescription
    {
        [JsonProperty("general_overview")]
        public string RacialGeneralOverview { get; set; }

        [JsonProperty("cultural_values")]
        public string RacialCulturalValues { get; set; }

        [JsonProperty("social_behavior")]
        public string RacialSocialBehavior { get; set; }

        [JsonProperty("typical_abilities_and_skills")]
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
