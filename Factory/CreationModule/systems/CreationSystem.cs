using A.T.L.A.S.Factory.CreationModule.DTOs;
using A.T.L.A.S.Factory.CreationModule.entities;
using A.T.L.A.S.Heart.AffectionModule.systems;
using A.T.L.A.S.Heart.PersonalityModule.systems;
using A.T.L.A.S.Mind.KnowledgeModule.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

        public Brain CreateNPC(string npcId, string npcName, List<Knowledge> initialKnowledge, 
                                PersonalitySystem npcPersonality, AffectionSystem npcAffection)
        {
            var newNpc = new Brain(npcId, npcName, initialKnowledge, npcPersonality, npcAffection);
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
                NPCKnowledgeSummaries = knowledgeContentForPrompt,
                NPCPersonality = npcBrain.npcPersonality,
                NPCAffection = npcBrain.npcAffection
            };
        }

        public string RetrieveNpcJsonString(string npcId)
        {
            string fileName = $"{npcId}.json";
            string filePath = Path.Combine(this.CharactersFolderPath, fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Arquivo JSON para o NPC '{npcId}' não encontrado em: {filePath}");
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                Debug.WriteLine($"String JSON do NPC '{npcId}' recuperada com sucesso do arquivo.");
                return jsonString;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro inesperado ao recuperar a string JSON do NPC '{npcId}': {ex.Message}");
                throw;
            }
        }


        public string GetCharactersPath()
        {
            return CharactersFolderPath;
        }

        /// <summary>
        /// Carrega um NPC do arquivo JSON e o reconstrói como um objeto Brain.
        /// Adiciona o Brain reconstruído à lista de NPCs ativos.
        /// </summary>
        /// <param name="npcId">O ID do NPC a ser carregado.</param>
        /// <returns>A instância do Brain do NPC carregado.</returns>
        public Brain LoadNPC(string npcId)
        {
            // 1. Recuperar a string JSON do arquivo
            string jsonString = RetrieveNpcJsonString(npcId);

            Debug.WriteLine($"String JSON do NPC '{jsonString}' recuperada com sucesso.");

            // 2. Desserializar a string JSON para o DTO NPCPromptData
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Não afeta desserialização, mas bom manter para consistência
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
                // Adicione conversores de data se suas classes de domínio usarem DateTime e precisarem de formato específico
                // Converters = { new Helpers.IsoDateTimeConverter() }
            };

            // Certifique-se de que todas as sub-propriedades do NPCPromptData (PersonalityData, AffectionSystem)
            // também tenham construtores vazios e JsonPropertyName configurados, senão a desserialização falhará.
            NPCPromptData npcPromptData = JsonSerializer.Deserialize<NPCPromptData>(jsonString, options);

            //Debug.WriteLine($"NPCPromptData desserializado com sucesso: {npcPromptData.NPCId}, {npcPromptData.NPCName}, {npcPromptData.NPCPersonality.oceanPersonality.Openness}");

            if(npcPromptData.NPCPersonality == null)
            {
                Debug.WriteLine($"Atenção: NPC '{npcId}' não possui PersonalityData definida. Usando padrão.");
            }
            else if(npcPromptData.NPCPersonality.oceanPersonality == null)
            {
                Debug.WriteLine($"Atenção: NPC '{npcId}' não possui oceanPersonality definida. Usando padrão.");
            }
            else
            {
                Debug.WriteLine($"NPC '{npcId}' possui PersonalityData definida: {npcPromptData.NPCPersonality.oceanPersonality.Openness}, {npcPromptData.NPCPersonality.oceanPersonality.Conscientiousness}, {npcPromptData.NPCPersonality.oceanPersonality.Extraversion}, {npcPromptData.NPCPersonality.oceanPersonality.Agreeableness}, {npcPromptData.NPCPersonality.oceanPersonality.Neuroticism}");
            }

            // 3. Reconstruir o objeto Brain a partir dos dados do NPCPromptData
            Brain reconstructedBrain = ReconstructBrainFromPromptData(npcPromptData);

            // 4. Adicionar o Brain reconstruído à lista de NPCs ativos
            // Opcional: Se o NPC já existir na lista, você pode querer atualizá-lo em vez de adicionar.
            if (_allNpcBrains.Any(b => b.GetNPCID() == reconstructedBrain.GetNPCID()))
            {
                Debug.WriteLine($"NPC '{reconstructedBrain.GetNPCID()}' já existe na memória. Substituindo.");
                _allNpcBrains.RemoveAll(b => b.GetNPCID() == reconstructedBrain.GetNPCID());
            }
            _allNpcBrains.Add(reconstructedBrain);
            Debug.WriteLine($"NPC '{npcId}' carregado e reconstruído com sucesso.");

            return reconstructedBrain;
        }


        /// <summary>
        /// Reconstrói um objeto Brain a partir de um NPCPromptData.
        /// </summary>
        /// <param name="promptData">O DTO NPCPromptData contendo os dados do NPC.</param>
        /// <returns>Uma nova instância da classe Brain.</returns>
        private Brain ReconstructBrainFromPromptData(NPCPromptData promptData)
        {
            // **Reconstruindo PersonalityData:**
            // NPCPromptData.NpcPersonality é do tipo PersonalityModule.entities.PersonalityData,
            // então pode ser usado diretamente.
            PersonalitySystem reconstructedPersonality = promptData.NPCPersonality ?? new PersonalitySystem();
            AffectionSystem reconstructedAffections = promptData.NPCAffection ?? new AffectionSystem();


            //AffectionSystem reconstructedAffectionSystem = promptData.NpcAffections ?? new AffectionSystem();




            // Cria uma nova instância de Brain com os módulos reconstruídos
            return new Brain(
                promptData.NPCId,
                promptData.NPCName,
                new List<Knowledge>(),
                reconstructedPersonality,
                reconstructedAffections
            );
        }

    }
}