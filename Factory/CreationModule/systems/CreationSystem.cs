using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Diagnostics;
using A.T.L.A.S.Heart.PersonalityModule.systems;
using A.T.L.A.S.Mind.KnowledgeModule.entities;
using A.T.L.A.S.Factory.CreationModule.DTOs;
using A.T.L.A.S.Factory.CreationModule.entities;

namespace A.T.L.A.S.Factory.CreationModule.systems
{
    public class CreationSystem
    {
        private const string CHARACTER_SAVE_DIRECTORY_NAME = "characters";

        private string CharactersFolderPath;

        private List<Brain> _allNpcBrains = new List<Brain>();

        public CreationSystem()
        {
            string _projectDirectory;
            var currentDirectory = AppContext.BaseDirectory;
            var directoryInfo = new DirectoryInfo(currentDirectory);

            //TODO - Colocar para verificar se é raiz do A.T.L.A.S
            for (int i = 0; i < 3 && directoryInfo.Parent != null; i++)
            {
                directoryInfo = directoryInfo.Parent;
            }
            _projectDirectory = directoryInfo.FullName;

            // Define o caminho completo para a pasta de salvamento dos personagens.
            CharactersFolderPath = Path.Combine(_projectDirectory, CHARACTER_SAVE_DIRECTORY_NAME);

            // Garante que o diretório de salvamento exista.
            if (!Directory.Exists(CharactersFolderPath))
            {
                Directory.CreateDirectory(CharactersFolderPath);
                Debug.WriteLine($"Diretório de salvamento criado: {CharactersFolderPath}");
            } else
            {
                Debug.WriteLine($"Diretório de salvamento já existe: {CharactersFolderPath}");
            }
        }

        /// <summary>
        /// Cria e adiciona um novo NPC ao sistema.
        /// </summary>
        public Brain CreateNPC(string npcId, string npcName, List<Knowledge> initialKnowledge)
        {
            var newNpc = new Brain(npcId, npcName, initialKnowledge);
            _allNpcBrains.Add(newNpc);
            Debug.WriteLine($"NPC {npcId} criado e adicionado ao CreationSystem.");
            return newNpc;
        }

        public Brain CreateNPC(string npcId, string npcName, List<Knowledge> initialKnowledge, PersonalitySystem npcPersonality)
        {
            var newNpc = new Brain(npcId, npcName, initialKnowledge, npcPersonality);
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


        /// <summary>
        /// Gera o JSON de prompt para um NPC específico.
        /// </summary>
        public string GenerateJsonForNpc(string npcId)
        {
            var npcBrain = GetNPCBrain(npcId);
            if (npcBrain == null)
            {
                throw new ArgumentException($"NPC com ID '{npcId}' não encontrado.");
            }

            // Reutiliza a lógica de montagem do JSON, passando o npcBrain
            var promptData = AssembleNpcData(npcBrain);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            return JsonSerializer.Serialize(promptData, options);
        }

        public void GenerateAndSaveJson(string npcId)
        {
            var jsonString = GenerateJsonForNpc(npcId);

            // 2. Define o caminho completo do arquivo
            string fileName = $"{npcId}.json";
            string filePath = Path.Combine(CharactersFolderPath, fileName);

            // 3. Salva a string JSON no arquivo
            try
            {
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"Dados do NPC '{npcId}' salvos com sucesso em '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o arquivo JSON para o NPC '{npcId}': {ex.Message}");
            }
        }

        private NPCPromptData AssembleNpcData(Brain npcBrain)
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
                KnowledgeBaseContent = knowledgeContentForPrompt,
                NPCPersonality = npcBrain.npcPersonality
            };
        }

        public string GetCharactersPath()
        {
            return CharactersFolderPath;
        }

    }
}