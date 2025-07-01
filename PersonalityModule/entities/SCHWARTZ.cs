using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.PersonalityModule.entities
{
    public class SCHWARTZ
    {
        [JsonPropertyName("self_direction")]
        public int SelfDirection { get; private set; }

        [JsonPropertyName("stimulation")]
        public int Stimulation { get; private set; }

        [JsonPropertyName("hedonism")]
        public int Hedonism { get; private set; }

        [JsonPropertyName("achievement")]
        public int Achievement { get; private set; }

        [JsonPropertyName("power")]
        public int Power { get; private set; }

        [JsonPropertyName("security")]
        public int Security { get; private set; }

        [JsonPropertyName("conformity")]
        public int Conformity { get; private set; }

        [JsonPropertyName("tradition")]
        public int Tradition { get; private set; }

        [JsonPropertyName("benevolence")]
        public int Benevolence { get; private set; }

        [JsonPropertyName("universalism")]
        public int Universalism { get; private set; }

        public SCHWARTZ()
        {
            this.SelfDirection = 0;
            this.Stimulation = 0;
            this.Hedonism = 0;
            this.Achievement = 0;
            this.Power = 0;
            this.Security = 0;
            this.Conformity = 0;
            this.Tradition = 0;
            this.Benevolence = 0;
            this.Universalism = 0;
        }

        public SCHWARTZ(
                        int selfDirection,
                        int stimulation,
                        int hedonism,
                        int achievement,
                        int power,
                        int security,
                        int conformity,
                        int tradition,
                        int benevolence,
                        int universalism
                     )
        {
            this.SelfDirection = selfDirection;
            this.Stimulation = stimulation;
            this.Hedonism = hedonism;
            this.Achievement = achievement;
            this.Power = power;
            this.Security = security;
            this.Conformity = conformity;
            this.Tradition = tradition;
            this.Benevolence = benevolence;
            this.Universalism = universalism;
        }

        public void SetSelfDirection(int value)
        {
            this.SelfDirection = value;
        }

        public void SetStimulation(int value)
        {
            this.Stimulation = value;
        }

        public void SetHedonism(int value)
        {
            this.Hedonism = value;
        }

        public void SetAchievement(int value)
        {
            this.Achievement = value;
        }

        public void SetPower(int value)
        {
            this.Power = value;
        }

        public void SetSecurity(int value)
        {
            this.Security = value;
        }

        public void SetConformity(int value)
        {
            this.Conformity = value;
        }

        public void SetTradition(int value)
        {
            this.Tradition = value;
        }

        public void SetBenevolence(int value)
        {
            this.Benevolence = value;
        }

        public void SetUniversalism(int value)
        {
            this.Universalism = value;
        }
    }
}
