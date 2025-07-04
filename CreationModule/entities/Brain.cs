﻿using A.T.L.A.S.KnowledgeModule.entities;
using A.T.L.A.S.KnowledgeModule.systems;
using A.T.L.A.S.MemoryModule.systems;
using A.T.L.A.S.PersonalityModule.systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.T.L.A.S.CreationModule.entities
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
            this.NPCId = npcId;
            this.NPCName = npcName;
            //this.npcPersonality = personality;
            this.npcKnowledge = new KnowledgeSystem();
            foreach (var knowledge in initialKnowledge)
            {
                this.npcKnowledge.AddKnowledge(knowledge);
            }

            this.npcPersonality = new PersonalitySystem();
            //NpcMemory = new MemorySystem(); // Cria um MemorySystem sem ID do NPC
        }

        public Brain(string npcId, string npcName,
                        List<Knowledge> initialKnowledge, PersonalitySystem npcPersonality)
        {
            this.NPCId = npcId;
            this.NPCName = npcName;
            this.npcKnowledge = new KnowledgeSystem();
            foreach (var knowledge in initialKnowledge)
            {
                this.npcKnowledge.AddKnowledge(knowledge);
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