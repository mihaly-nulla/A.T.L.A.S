using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Newtonsoft.DTO.Races._Description
{
    public class RaceDescriptionDTO
    {
        [JsonProperty("general_overview")]
        public string RacialGeneralOverview { get; set; }

        [JsonProperty("cultural_values")]
        public string RacialCulturalValues { get; set; }

        [JsonProperty("social_behavior")]
        public string RacialSocialBehavior { get; set; }

        [JsonProperty("typical_abilities_and_skills")]
        public string RacialAbilities { get; set; }
    }
}
