using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.PersonalityModule.entities
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
            this.Openness = 0;
            this.Conscientiousness = 0;
            this.Extraversion = 0;
            this.Agreeableness = 0;
            this.Neuroticism = 0;
        }

        public OCEAN(
                        int openness,
                        int conscientiouness,
                        int extraversion,
                        int agreeableness,
                        int neuroticism
                     )
        {
            this.Openness = openness;
            this.Conscientiousness = conscientiouness;
            this.Extraversion = extraversion;
            this.Agreeableness = agreeableness;
            this.Neuroticism = neuroticism;
        }

        public void SetOpennes(int value)
        {
            this.Openness = value;
        }

        public void SetConscientiousness(int value)
        {
            this.Conscientiousness = value;
        }

        public void SetExtraversion(int value)
        {
            this.Extraversion = value;
        }

        public void SetAgreeableness(int value)
        {
            this.Agreeableness = value;
        }

        public void SetNeuroticism(int value)
        {
            this.Neuroticism = value;
        }

    }
}
