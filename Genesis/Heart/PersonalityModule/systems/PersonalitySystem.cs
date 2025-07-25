using Genesis.Heart.PersonalityModule.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;  

namespace Genesis.Heart.PersonalityModule.systems
{
    public class PersonalitySystem
    {
        [JsonProperty("OCEAN")]
        public OCEAN oceanPersonality { get; set; }

        [JsonProperty("SCHWARTZ")]
        public SCHWARTZ schwartzPersonality { get; set; }

        [JsonProperty("dialog_style")]
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
