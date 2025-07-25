﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Heart.PersonalityModule.entities
{
    public class SCHWARTZ
    {
        [JsonPropertyName("self_direction")]
        public int SelfDirection { get; set; }

        [JsonPropertyName("stimulation")]
        public int Stimulation { get; set; }

        [JsonPropertyName("hedonism")]
        public int Hedonism { get; set; }

        [JsonPropertyName("achievement")]
        public int Achievement { get; set; }

        [JsonPropertyName("power")]
        public int Power { get; set; }

        [JsonPropertyName("security")]
        public int Security { get; set; }

        [JsonPropertyName("conformity")]
        public int Conformity { get; set; }

        [JsonPropertyName("tradition")]
        public int Tradition { get; set; }

        [JsonPropertyName("benevolence")]
        public int Benevolence { get; set; }

        [JsonPropertyName("universalism")]
        public int Universalism { get; set; }

        public SCHWARTZ() { }

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
            SelfDirection = selfDirection;
            Stimulation = stimulation;
            Hedonism = hedonism;
            Achievement = achievement;
            Power = power;
            Security = security;
            Conformity = conformity;
            Tradition = tradition;
            Benevolence = benevolence;
            Universalism = universalism;
        }

        public void SetSelfDirection(int value)
        {
            SelfDirection = value;
        }

        public void SetStimulation(int value)
        {
            Stimulation = value;
        }

        public void SetHedonism(int value)
        {
            Hedonism = value;
        }

        public void SetAchievement(int value)
        {
            Achievement = value;
        }

        public void SetPower(int value)
        {
            Power = value;
        }

        public void SetSecurity(int value)
        {
            Security = value;
        }

        public void SetConformity(int value)
        {
            Conformity = value;
        }

        public void SetTradition(int value)
        {
            Tradition = value;
        }

        public void SetBenevolence(int value)
        {
            Benevolence = value;
        }

        public void SetUniversalism(int value)
        {
            Universalism = value;
        }
    }
}
