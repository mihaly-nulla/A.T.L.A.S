using A.T.L.A.S.CreationModule.DTOs;
using A.T.L.A.S.CreationModule.entities;
using A.T.L.A.S.KnowledgeModule.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.CreationModule.systems
{
    public class CreationSystem
    {
        private List<Brain> _allNpcBrains = new List<Brain>();

        public CreationSystem()
        {
            // _globalKnowledgeBase = new GlobalKnowledgeBaseManager(); // Se aplicável
        }

        /// <summary>
        /// Cria e adiciona um novo NPC ao sistema.
        /// </summary>
        public Brain CreateNPC(string npcId, string npcName, List<Knowledge> initialKnowledge)
        {
            var newNpc = new Brain(npcId, npcName, initialKnowledge);
            _allNpcBrains.Add(newNpc);
            Console.WriteLine($"NPC {npcId} criado e adicionado ao CreationSystem.");
            return newNpc;
        }

        /// <summary>
        /// Retorna um NPCBrain pelo seu ID.
        /// </summary>
        public Brain GetNPCBrain(string npcId)
        {
            return _allNpcBrains.FirstOrDefault(npc => npc.GetNPCID() == npcId);
        }



        /// <summary>
        /// Gera o JSON de prompt para um NPC específico.
        /// </summary>
        public string GeneratePromptJsonForNpc(string npcId)
        {
            var npcBrain = GetNPCBrain(npcId);
            if (npcBrain == null)
            {
                throw new ArgumentException($"NPC com ID '{npcId}' não encontrado.");
            }

            // Reutiliza a lógica de montagem do JSON, passando o npcBrain
            var promptData = AssembleNpcPromptData(npcBrain);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            return JsonSerializer.Serialize(promptData, options);
        }

        private NPCPromptData AssembleNpcPromptData(Brain npcBrain)
        {
            // Coleciona o conteúdo dos documentos de cada Knowledge
            var knowledgeContentForPrompt = new List<string>();

            foreach (var knowledgeEntry in npcBrain.npcKnowledge.GetAllKnowledge())
            {
                // Para cada conceito (Knowledge), colete o conteúdo relevante dos documentos
                var relevantContent = new List<string>();

                foreach (var doc in knowledgeEntry.Documents)
                {
                    // Aqui você decide qual parte do documento é o "conteúdo" do conhecimento
                    // Pode ser o Description, ou uma combinação de Title e Description.
                    // Evite FilePath ou ID a menos que seja estritamente necessário.
                    if (!string.IsNullOrWhiteSpace(doc.Description))
                    {
                        relevantContent.Add(doc.Abstract);
                    }
                }

                if (relevantContent.Any())
                {
                    // Concatena os conteúdos dos documentos para formar o "conhecimento" do conceito
                    string fullContent = $"{knowledgeEntry.ConceptId}: {string.Join(" ", relevantContent)}";

                    // Limita o tamanho do conteúdo para economizar tokens
                    if (fullContent.Length > 300)
                    {
                        fullContent = fullContent.Substring(0, 300) + "...";
                    }
                    knowledgeContentForPrompt.Add(fullContent);
                }
            }

            return new NPCPromptData
            {
                NPCId = npcBrain.GetNPCID(),
                NPCName = npcBrain.GetNPCName(),
                KnowledgeBaseContent = knowledgeContentForPrompt
            };
        }
    }
}