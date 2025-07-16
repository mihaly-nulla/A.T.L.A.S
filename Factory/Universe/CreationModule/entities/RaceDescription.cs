using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.World.CreationModule.entities
{
    public class RaceDescription
    {
        [JsonPropertyName("general_overview")]
        public string RacialGeneralOverview { get; set; }

        [JsonPropertyName("cultural_values")]
        public string RacialCulturalValues { get; set; }

        [JsonPropertyName("social_behavior")]
        public string RacialSocialBehavior { get; set; }

        [JsonPropertyName("typical_abilities_and_skills")]
        public string RacialAbilities { get; set; }

        public RaceDescription()
        {
            this.RacialGeneralOverview = string.Empty;
            this.RacialCulturalValues = string.Empty;
            this.RacialSocialBehavior = string.Empty;
            this.RacialAbilities = string.Empty;
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
