using Genesis.Factory.NPCs.CreationModule.entities;
using Genesis.Heart.AffectionModule.systems;
using Genesis.Heart.IdentityModule.systems;
using Genesis.Heart.PersonalityModule.systems;
using Genesis.Mind.KnowledgeModule.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace Genesis.Factory.NPCs.CreationModule.systems
{
    public class CharacterFactory
    {

        private List<Brain> _allNpcBrains = new List<Brain>();

        public CharacterFactory()
        {

        }

        public Brain CreateNPC(string npcId,
                               IdentitySystem npcIdentity,
                               PersonalitySystem npcPersonality, 
                               AffectionSystem npcAffection)
        {
            var newNpc = new Brain(npcId, npcIdentity, npcPersonality, npcAffection);
            _allNpcBrains.Add(newNpc);
            Debug.WriteLine($"NPC {npcId} criado e adicionado ao CreationSystem.");
            return newNpc;
        }

        /// <summary>
        /// Retorna um NPCBrain pelo seu ID.
        /// </summary>
        public Brain GetNPCBrain(string npcId)
        {
            return _allNpcBrains.FirstOrDefault(npc => npc.GetNPCID() == npcId);
        }

        public List<Brain> GetAllNPCBrains()
        {
            return _allNpcBrains;
        }

        /*private CharacterRepresentation AssembleNpcData(Brain npcBrain)
        {
            // Coleciona o conteúdo dos documentos de cada Knowledge
            var knowledgeContentForPrompt = new List<string>();

            return new CharacterRepresentation
            {
                NPCId = npcBrain.GetNPCID(),
                NPCIdentity = npcBrain.NpcIdentity,
                NPCKnowledgeSummaries = knowledgeContentForPrompt,
                NPCPersonality = npcBrain.NpcPersonality,
                NPCAffection = npcBrain.NpcAffections
            };
        }*/


        public void AddNPC(Brain npc)
        {

            if (_allNpcBrains.Any(b => b.GetNPCID() == npc.GetNPCID())) //Se ja existe, atualiza o Brain
            {
                _allNpcBrains.RemoveAll(b => b.GetNPCID() == npc.GetNPCID());
            }
            _allNpcBrains.Add(npc);
        }
    }
}