using Genesis.Heart.PersonalityModule.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Heart.PersonalityModule.systems
{
    public class PersonalitySystem
    {
        public OCEAN oceanPersonality { get; set; }
        public SCHWARTZ schwartzPersonality { get; set; }
        public DialogueStyle personalityStyle { get; set; }

        public PersonalitySystem()
        {
            oceanPersonality = new OCEAN();
            schwartzPersonality = new SCHWARTZ();
            personalityStyle = new DialogueStyle();
        }

        public PersonalitySystem(
                                    OCEAN oceanPersonality, 
                                    SCHWARTZ schwartzPersonality,  
                                    DialogueStyle personalityStyle
                                )
        {
            this.oceanPersonality = oceanPersonality;
            this.schwartzPersonality = schwartzPersonality;
            this.personalityStyle = personalityStyle;
        }


    }
}
