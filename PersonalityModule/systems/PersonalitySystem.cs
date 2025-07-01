using A.T.L.A.S.KnowledgeModule.entities;
using A.T.L.A.S.PersonalityModule.components;
using A.T.L.A.S.PersonalityModule.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.PersonalityModule.systems
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
            this.oceanPersonality = new OCEAN();
            this.schwartzPersonality = new SCHWARTZ();
            this.personalityStyle = new DialogStyle();
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
