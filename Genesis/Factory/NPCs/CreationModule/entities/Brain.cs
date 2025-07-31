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
using System.Runtime.CompilerServices;


namespace Genesis.Factory.NPCs.CreationModule.entities
{
    public class Brain
    {
        public string NPCId;

        public IdentitySystem NpcIdentity { get; set; }

        public PersonalitySystem NpcPersonality { get; set; }

        public AffectionSystem NpcAffections { get; set; }

        public Brain() { }

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