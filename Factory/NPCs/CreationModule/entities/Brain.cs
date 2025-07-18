using A.T.L.A.S.Heart.PersonalityModule.systems;

using A.T.L.A.S.Mind.MemoryModule.systems;
using A.T.L.A.S.Mind.KnowledgeModule.entities;
using A.T.L.A.S.Mind.KnowledgeModule.systems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A.T.L.A.S.Heart.AffectionModule.systems;
using A.T.L.A.S.Heart.IdentityModule.systems;

namespace A.T.L.A.S.Factory.NPCs.CreationModule.entities
{
    public class Brain
    {
        private string NPCId;

        public IdentitySystem NpcIdentity { get; private set; }

        public KnowledgeSystem NpcKnowledge { get; private set; }

        public PersonalitySystem NpcPersonality { get; private set; }

        public AffectionSystem NpcAffections { get; private set; }

        public Brain(string npcId, List<Knowledge> initialKnowledge)
        {
            this.NPCId = npcId;
            NpcKnowledge = new KnowledgeSystem();
            foreach (var knowledge in initialKnowledge)
            {
                NpcKnowledge.AddKnowledge(knowledge);
            }

            NpcPersonality = new PersonalitySystem();
            //NpcMemory = new MemorySystem(); // Cria um MemorySystem sem ID do NPC
        }

        public Brain(string npcId,
                     IdentitySystem npcIdentity,
                     List<Knowledge> initialKnowledge, 
                     PersonalitySystem npcPersonality,
                     AffectionSystem npcAffection)
        {
            this.NPCId = npcId;
            this.NpcKnowledge = new KnowledgeSystem();
            foreach (var knowledge in initialKnowledge)
            {
                this.NpcKnowledge.AddKnowledge(knowledge);
            }
            this.NpcPersonality = npcPersonality;
            this.NpcAffections = npcAffection;
            this.NpcIdentity = npcIdentity;
            //NpcMemory = new MemorySystem(); // Cria um MemorySystem sem ID do NPC
        }

        public string GetNPCName()
        {
            return this.NpcIdentity.NpcName;
        }

        public string GetNPCID()
        {
            return this.NPCId;
        }
        
    }
}