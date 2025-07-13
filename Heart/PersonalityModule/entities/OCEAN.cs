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
        public int Openness { get; private set; }

        [JsonPropertyName("conscientiousness")]
        public int Conscientiousness { get; private set; }
   
        [JsonPropertyName("extraversion")]
        public int Extraversion { get; private set; }

        [JsonPropertyName("agreeableness")]
        public int Agreeableness { get; private set; }

        [JsonPropertyName("neuroticism")]
        public int Neuroticism { get; private set; }

        public OCEAN() 
        {
            Openness = 0;
            Conscientiousness = 0;
            Extraversion = 0;
            Agreeableness = 0;
            Neuroticism = 0;
        }

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
