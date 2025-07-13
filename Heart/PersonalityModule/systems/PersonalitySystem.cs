using A.T.L.A.S.Heart.PersonalityModule.components;
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
        public OCEAN oceanPersonality { get; private set; }

        [JsonPropertyName("SCHWARTZ")]
        public SCHWARTZ schwartzPersonality { get; private set; }

        [JsonPropertyName("dialog_style")]
        public DialogStyle personalityStyle { get; private set; }

        public PersonalitySystem()
        {
            oceanPersonality = new OCEAN();
            schwartzPersonality = new SCHWARTZ();
            personalityStyle = new DialogStyle();
            //knowledgeBase = new List<Knowledge>();
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
