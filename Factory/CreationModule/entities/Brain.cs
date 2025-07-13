using A.T.L.A.S.Heart.PersonalityModule.systems;

using A.T.L.A.S.Mind.MemoryModule.systems;
using A.T.L.A.S.Mind.KnowledgeModule.entities;
using A.T.L.A.S.Mind.KnowledgeModule.systems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.CreationModule.entities
{
    public class Brain
    {
        private string NPCId;

        private string NPCName;
        public KnowledgeSystem npcKnowledge { get; private set; }

        public PersonalitySystem npcPersonality { get; private set; }
        //private MemorySystem npcMemory;
        //private PersonalitySystem npcPersonality;

        public Brain(string npcId, string npcName, List<Knowledge> initialKnowledge)
        {
            NPCId = npcId;
            NPCName = npcName;
            //this.npcPersonality = personality;
            npcKnowledge = new KnowledgeSystem();
            foreach (var knowledge in initialKnowledge)
            {
                npcKnowledge.AddKnowledge(knowledge);
            }

            npcPersonality = new PersonalitySystem();
            //NpcMemory = new MemorySystem(); // Cria um MemorySystem sem ID do NPC
        }

        public Brain(string npcId, string npcName,
                        List<Knowledge> initialKnowledge, PersonalitySystem npcPersonality)
        {
            NPCId = npcId;
            NPCName = npcName;
            npcKnowledge = new KnowledgeSystem();
            foreach (var knowledge in initialKnowledge)
            {
                npcKnowledge.AddKnowledge(knowledge);
            }
            this.npcPersonality = npcPersonality;
            //NpcMemory = new MemorySystem(); // Cria um MemorySystem sem ID do NPC
        }

        public string GetNPCName()
        {
            return NPCName;
        }

        public string GetNPCID()
        {
            return NPCId;
        }
        
    }
}