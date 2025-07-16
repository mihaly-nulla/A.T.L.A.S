using A.T.L.A.S.Factory.NPCs.CreationModule.entities;
using A.T.L.A.S.Factory.NPCs.CreationModule.systems;
using A.T.L.A.S.Mind.CommunicationModule.components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace A.T.L.A.S.Mind.CommunicationModule.systems
{
    public class CommunicationSystem
    {
        private readonly HttpClient _httpClient;

        private const string GEMINI_MODEL_URL = "https://generativelanguage.googleapis.com/v1beta/models/";

        private const string GEMINI_MODEL_ID = "gemini-2.5-flash";


        public CommunicationSystem()
        {
            _httpClient = new HttpClient();
        }
        private string RetrieveNPCJSON(string npcId, string path)
        {
            string fileName = $"{npcId}.json";
            string filePath = Path.Combine(path, fileName);

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


        public async Task<string> SendPromptToGEMINI(CharacterManagerSystem creator, string npcId, string playerInput, string apiKey)
        {
            string path = creator.GetCharactersPath();
            Debug.WriteLine($"\nCommunicationSystem: Preparando prompt para NPC '{npcId}' com input do jogador: '{playerInput}'");
            string npcProfileJson = RetrieveNPCJSON(npcId, path);

            var relevantNpcData = GetRelevantNpcDataFromPrompt(creator, npcId, playerInput);

            string fullPrompt = PromptBuilder.BuildAiPrompt(npcProfileJson, playerInput, relevantNpcData);

            Debug.WriteLine("--- FULL PROMPT SENT TO AI (Simulated) ---");
            Debug.WriteLine(fullPrompt);
            Debug.WriteLine("------------------------------------------");
            return $"AI Response (simulated for {npcId}): Based on the detailed profile provided and your input, I would say something witty and insightful about {playerInput}.";
            /*
            var requestPayload = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[] {
                            new { text = fullPrompt }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.7f,
                    topK = 40,
                    topP = 0.95f
                },
                safetySettings = new[]
                {
                    new { category = "HARM_CATEGORY_HARASSMENT", threshold = "BLOCK_NONE" },
                    new { category = "HARM_CATEGORY_HATE_SPEECH", threshold = "BLOCK_NONE" },
                    new { category = "HARM_CATEGORY_SEXUALLY_EXPLICIT", threshold = "BLOCK_NONE" },
                    new { category = "HARM_CATEGORY_DANGEROUS_CONTENT", threshold = "BLOCK_NONE" }
                }
            };

            var jsonPayload = JsonSerializer.Serialize(requestPayload, new JsonSerializerOptions { WriteIndented = true });
            string fullRequestUri = $"{GEMINI_MODEL_URL}{GEMINI_MODEL_ID}:generateContent?key={apiKey}";
            Debug.WriteLine($"JSON PAYLOAD:\n\n {jsonPayload}");
            Debug.WriteLine($"FULL URL:\n\n {fullRequestUri}");

            try
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, fullRequestUri);
                httpRequest.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                Debug.WriteLine("ANTES DE ENVIAR!\n\n");
                var httpResponse = await _httpClient.SendAsync(httpRequest);
                httpResponse.EnsureSuccessStatusCode();

                Debug.WriteLine($"HTTP RESPONSE: {httpResponse}");

                string responseBody = await httpResponse.Content.ReadAsStringAsync();

                Debug.WriteLine($"RESPONSE BODY: {responseBody}");

                var geminiResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);

                if (geminiResponse.TryGetProperty(
                                                    "candidates", out JsonElement candidatesElement) &&
                                                    candidatesElement.EnumerateArray().Any()
                                                  )
                {
                    var firstCandidate = candidatesElement.EnumerateArray().First();
                    if (firstCandidate.TryGetProperty("content", out JsonElement contentElement) &&
                        contentElement.TryGetProperty("parts", out JsonElement partsElement) &&
                        partsElement.EnumerateArray().Any())
                    {
                        var firstPart = partsElement.EnumerateArray().First();
                        if (firstPart.TryGetProperty("text", out JsonElement textElement))
                        {
                            string aiResponseText = textElement.GetString();
                            Debug.WriteLine("\n--- Resposta Bruta da API do Gemini ---");
                            Debug.WriteLine(responseBody);
                            Debug.WriteLine("------------------------------------");
                            return aiResponseText;
                        }

                    }
                }
                Debug.WriteLine("\n--- Resposta Bruta da API do Gemini ---");
                Debug.WriteLine(responseBody);
                Debug.WriteLine("------------------------------------");
                return "Erro: Resposta da IA não contém o formato esperado (texto).";
            }
            catch (Exception e)
            {
                Debug.WriteLine("ERRO AO ENVIAR");
            }

            return $"AI Response (simulated for {npcId}): Based on the detailed profile provided and your input, I would say something witty and insightful about {playerInput}.";*/
        }

        private Dictionary<string, string> GetRelevantNpcDataFromPrompt(CharacterManagerSystem creator, string npcID, string playerInput)
        {
            var relevantData = new Dictionary<string, string>();
            var allKnownNpcs = creator.GetAllNPCBrains();

            Brain currentNPC = creator.LoadNPC(npcID);
            foreach (var character in allKnownNpcs)
            {
                if (character.GetNPCID() == npcID)
                {
                    continue; // Skip the current NPC
                }

                if (playerInput.IndexOf(character.GetNPCName(), StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var relationship = currentNPC.npcAffections.GetRelationship(character.GetNPCID());
                    var socialStanding = currentNPC.npcAffections.SocialPerception;

                    bool isRelevant = relationship != null ||
                                      socialStanding.KnownByNPCs.Contains(character.GetNPCID()) ||
                                      socialStanding.UnfavorableNPCs.Contains(character.GetNPCID());

                    if (isRelevant)
                    {
                        var summaryBuilder = new StringBuilder();

                        summaryBuilder.AppendLine($"- Profile for the character {character.GetNPCName()}:");
                        summaryBuilder.AppendLine($"  - Personality: {character.npcPersonality.personalityStyle.VocabularyReference} style ({character.npcPersonality.personalityStyle.Tone} tone).");
                        summaryBuilder.AppendLine($"  - Reputation: {socialStanding.ReputationType}.");

                        if (relationship != null)
                        {
                            summaryBuilder.AppendLine($"  - Relationship: {relationship.FriendshipLevel} (Affection: {relationship.AffectionScore}, Trust: {relationship.TrustScore}).");
                            summaryBuilder.AppendLine($"  - Perceived Traits: {string.Join(", ", relationship.Traits)}.");
                        }

                        relevantData[character.GetNPCID()] = summaryBuilder.ToString();
                    }
                }
            }

            return relevantData;
        }
    }
}
