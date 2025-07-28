using Genesis.Mind.MemoryModule.systems;
using Genesis.Mind.KnowledgeModule.entities;
using Genesis.Mind.KnowledgeModule.systems;

using Genesis.Heart.AffectionModule.systems;
using Genesis.Heart.IdentityModule.systems;
using Genesis.Heart.PersonalityModule.systems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Genesis.Factory.NPCs.CreationModule.entities
{
    public class Brain
    {
        private string NPCId;

        public IdentitySystem NpcIdentity { get; private set; }

        public PersonalitySystem NpcPersonality { get; private set; }

        public AffectionSystem NpcAffections { get; private set; }

        public Brain(string npcId, List<Knowledge> initialKnowledge)
        {
            this.NPCId = npcId;

            NpcPersonality = new PersonalitySystem();
            //NpcMemory = new MemorySystem(); // Cria um MemorySystem sem ID do NPC
        }

        public Brain(string npcId,
                     IdentitySystem npcIdentity,
                     PersonalitySystem npcPersonality,
                     AffectionSystem npcAffection)
        {
            this.NPCId = npcId;
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