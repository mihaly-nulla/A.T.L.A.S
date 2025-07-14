using A.T.L.A.S.Heart.PersonalityModule.entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Heart.PersonalityModule.systems
{
    public class PersonalitySystem
    {
        [JsonPropertyName("OCEAN")]
        public OCEAN oceanPersonality { get; set; }

        [JsonPropertyName("SCHWARTZ")]
        public SCHWARTZ schwartzPersonality { get; set; }

        [JsonPropertyName("dialog_style")]
        public DialogStyle personalityStyle { get; set; }

        public PersonalitySystem()
        {
            oceanPersonality = new OCEAN();
            schwartzPersonality = new SCHWARTZ();
            personalityStyle = new DialogStyle();
        }

        public PersonalitySystem(
                                    OCEAN oceanPersonality, 
                                    SCHWARTZ schwartzPersonality,  
                                    DialogStyle personalityStyle
                                )
        {
            this.oceanPersonality = oceanPersonality;
            this.schwartzPersonality = schwartzPersonality;
            this.personalityStyle = personalityStyle;
        }


    }
}
