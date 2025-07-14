using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Heart.PersonalityModule.entities
{
    public class OCEAN
    {
        [JsonPropertyName("openness")]
        public int Openness { get; set; }

        [JsonPropertyName("conscientiousness")]
        public int Conscientiousness { get; set; }
   
        [JsonPropertyName("extraversion")]
        public int Extraversion { get; set; }

        [JsonPropertyName("agreeableness")]
        public int Agreeableness { get; set; }

        [JsonPropertyName("neuroticism")]
        public int Neuroticism { get; set; }

        public OCEAN() { }

        public OCEAN(
                        int openness,
                        int conscientiouness,
                        int extraversion,
                        int agreeableness,
                        int neuroticism
                     )
        {
            Openness = openness;
            Conscientiousness = conscientiouness;
            Extraversion = extraversion;
            Agreeableness = agreeableness;
            Neuroticism = neuroticism;
        }

        public void SetOpennes(int value)
        {
            Openness = value;
        }

        public void SetConscientiousness(int value)
        {
            Conscientiousness = value;
        }

        public void SetExtraversion(int value)
        {
            Extraversion = value;
        }

        public void SetAgreeableness(int value)
        {
            Agreeableness = value;
        }

        public void SetNeuroticism(int value)
        {
            Neuroticism = value;
        }

    }
}
