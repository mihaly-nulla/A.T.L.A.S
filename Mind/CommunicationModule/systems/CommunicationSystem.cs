﻿using A.T.L.A.S.Factory.NPCs.CreationModule.entities;
using A.T.L.A.S.Factory.NPCs.CreationModule.systems;
using A.T.L.A.S.Factory.Universe.CreationModule.entities.race;
using A.T.L.A.S.Factory.Universe.CreationModule.entities.region;
using A.T.L.A.S.Factory.World.CreationModule.systems;
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

        private CharacterFactory NPCFactory;

        private RaceFactory NPCRaceFactory;

        private EnvironmentFactory NPCEnvironmentFactory;


        public CommunicationSystem()
        {
            _httpClient = new HttpClient();

            this.NPCFactory = new CharacterFactory();
            this.NPCRaceFactory = new RaceFactory();
            this.NPCEnvironmentFactory = new EnvironmentFactory();
        }

        public CommunicationSystem(
                                        CharacterFactory characterFactory,
                                        RaceFactory raceFactory,
                                        EnvironmentFactory environmentFactory)
        {
            _httpClient = new HttpClient();

            this.NPCFactory = characterFactory;
            this.NPCEnvironmentFactory = environmentFactory;    
            this.NPCRaceFactory = raceFactory;
        }

        public CommunicationSystem(CharacterFactory characterFactory)
        {
            _httpClient = new HttpClient();

            this.NPCFactory = characterFactory;

            this.NPCRaceFactory = new RaceFactory();
            this.NPCEnvironmentFactory = new EnvironmentFactory();
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


        private Dictionary<string, string> GetRelevantNpcDataFromPrompt(Brain correspondingCharacter, List<Brain> allKnownNpcs, string playerInput)
        {
            var relevantData = new Dictionary<string, string>();

            foreach (var character in allKnownNpcs)
            {
                if (character.GetNPCID() == correspondingCharacter.GetNPCID())
                {
                    continue;
                }

                bool npcMentioned = false;

                if (!string.IsNullOrWhiteSpace(character.GetNPCName()) && playerInput.Contains(character.GetNPCName().ToLower()))
                {
                    npcMentioned = true;
                } else
                {
                    string[] nameParts = character.GetNPCName().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in nameParts)
                    {
                        Debug.WriteLine($"Checking part '{part}' against player input '{playerInput}'");
                        if (!string.IsNullOrWhiteSpace(part) && playerInput.Contains(part.ToLower()))
                        {
                            npcMentioned = true;
                            break;
                        }
                    }
                }

                if (npcMentioned)
                {

                    var relationship = correspondingCharacter.NpcAffections.GetRelationship(character.GetNPCID());
                    var socialStanding = correspondingCharacter.NpcAffections.SocialPerception;

                    bool isRelevant = relationship != null ||
                                      socialStanding.KnownByNPCs.Contains(character.GetNPCID()) ||
                                      socialStanding.UnfavorableNPCs.Contains(character.GetNPCID());

                    if (isRelevant)
                    {
                        var summaryBuilder = new StringBuilder();

                        summaryBuilder.AppendLine($"- Profile for the character {character.GetNPCName()}:");
                        summaryBuilder.AppendLine($"  - Personality: {character.NpcPersonality.personalityStyle.VocabularyReference} style ({character.NpcPersonality.personalityStyle.Tone} tone).");
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


        private string GetRelevantRaceDataFromPrompt(Brain correspondingCharacter, string inputPrompt)
        {
            //Debug.WriteLine("NOME DO NPC: " + correspondingCharacter.GetNPCName());
            string raceDataSummary = string.Empty;

            if (!string.IsNullOrWhiteSpace(correspondingCharacter.NpcIdentity.RaceID))
            {
                Race npcRace = this.NPCRaceFactory.GetRaceById(correspondingCharacter.NpcIdentity.RaceID);

                if(npcRace != null)
                {
                    StringBuilder raceSummaryBuilder = new StringBuilder(); 
                    
                    raceSummaryBuilder.AppendLine($"- Your race is {npcRace.RaceName} (race_id: {npcRace.RaceID}).");
                    raceSummaryBuilder.AppendLine($"  - Race General Overview: {npcRace.RaceInformation.RacialGeneralOverview}");

                    bool needsCultural = inputPrompt.Contains("cultura") || inputPrompt.Contains("sociedade") || inputPrompt.Contains("valores");
                    bool needsSocial = inputPrompt.Contains("comportamento social") || inputPrompt.Contains("interagem") || inputPrompt.Contains("como vocês vivem");
                    bool needsAppearence = inputPrompt.Contains("aparência") || inputPrompt.Contains("físico") || inputPrompt.Contains("como vocês são");
                    bool needsLore = inputPrompt.Contains("história") || inputPrompt.Contains("origem") || inputPrompt.Contains("lore") || inputPrompt.Contains("passado") || inputPrompt.Contains("quem é você");

                    if(needsCultural)
                        raceSummaryBuilder.AppendLine($"  - Race Cultural Values: {npcRace.RaceInformation.RacialCulturalValues}");
                    if(needsSocial)
                        raceSummaryBuilder.AppendLine($"  - Race Social Behavior: {npcRace.RaceInformation.RacialSocialBehavior}");
                    if(needsAppearence)
                        raceSummaryBuilder.AppendLine($"  - Race Appearance Description: {npcRace.RaceAppearenceDescription}");
                    if(needsLore)
                        raceSummaryBuilder.AppendLine($"  - Race Lore: {npcRace.RaceLore}");

                    raceDataSummary = raceSummaryBuilder.ToString();
                }

            }

            return raceDataSummary;
        }

        private string GetRelevantEnvironmentDataFromPrompt(Brain correspondingCharacter, string inputPrompt)
        {
            string environmentDataSummary = string.Empty;

            if (!string.IsNullOrWhiteSpace(correspondingCharacter.NpcIdentity.EnvironmentID))
            {
                WorldEnvironment npcEnvironment = this.NPCEnvironmentFactory.GetEnvironmentById(correspondingCharacter.NpcIdentity.EnvironmentID);

                if (npcEnvironment != null)
                {
                    StringBuilder environmentSummaryBuilder = new StringBuilder();

                    environmentSummaryBuilder.AppendLine($"- Your place of origin is {npcEnvironment.EnvironmentName}, of type {npcEnvironment.EnvironmentType}  (environment_id: {npcEnvironment.EnvironmentID}).");
                    environmentSummaryBuilder.AppendLine($"  - Environment General Description: {npcEnvironment.EnvironmentDescription}");
                    if (npcEnvironment.EnvironmentCharacteristics != null && npcEnvironment.EnvironmentCharacteristics.Any())
                        environmentSummaryBuilder.AppendLine($"  - Environment Key Characteristics: {string.Join(", ", npcEnvironment.EnvironmentCharacteristics)}.");


                    bool needsSocial = (inputPrompt.Contains("comunidade") || inputPrompt.Contains("vizinhos") || inputPrompt.Contains("social") || 
                                            inputPrompt.Contains("habitantes") || inputPrompt.Contains("pessoas") || inputPrompt.Contains("interagem") || inputPrompt.Contains("política") || 
                                            inputPrompt.Contains("governo") || inputPrompt.Contains("associação")) && inputPrompt.Contains(npcEnvironment.EnvironmentName.ToLowerInvariant());

                    bool needsHistorical = (inputPrompt.Contains("quando") || inputPrompt.Contains("história") || inputPrompt.Contains("passado")) && inputPrompt.Contains(npcEnvironment.EnvironmentName.ToLowerInvariant());
                    bool needsLocations = (inputPrompt.Contains("lugares") || inputPrompt.Contains("lugar") || inputPrompt.Contains("local") || inputPrompt.Contains("locais") || 
                                            inputPrompt.Contains("próximo") || inputPrompt.Contains("onde") || inputPrompt.Contains("curiosidades")) && inputPrompt.Contains(npcEnvironment.EnvironmentName.ToLowerInvariant());


                    if (needsHistorical)
                        environmentSummaryBuilder.AppendLine($"  - Environment Historical Context: {npcEnvironment.EnvironmentHistoricalContext}");
                    if (needsLocations && npcEnvironment.EnvironmentMajorLocations != null && npcEnvironment.EnvironmentMajorLocations.Any())
                    {
                        environmentSummaryBuilder.AppendLine("  - Major Locations:");
                        int i = 0;
                        foreach (var locEntry in npcEnvironment.EnvironmentMajorLocations.Values)
                        {
                            environmentSummaryBuilder.AppendLine($"    - Location {i} Name: {locEntry.LocationName} of type: {locEntry.LocationType}");
                            environmentSummaryBuilder.AppendLine($"    - Location {i} Description: {locEntry.LocationDescription}");
                            i++;
                        }
                    }

                    environmentDataSummary = environmentSummaryBuilder.ToString();
                }

            }

            return environmentDataSummary;
        }


        public async Task<string> SendPromptToGEMINI(
                                                        string npcId, string inputPrompt, string apiKey
                                                    )
        {
            string path = this.NPCFactory.GetCharactersPath();
            string inputPromptLower = inputPrompt.ToLowerInvariant();

            Debug.WriteLine($"\nCommunicationSystem: Preparando prompt para NPC '{npcId}' com input do jogador: '{inputPrompt}'");
            string npcProfileJson = RetrieveNPCJSON(npcId, path);

            Brain brain = this.NPCFactory.GetNPCBrain(npcId);
            var npcDatabase = this.NPCFactory.GetAllNPCBrains();

            if(npcDatabase == null || !npcDatabase.Any())
            {
                Debug.WriteLine("Nenhum NPC encontrado no banco de dados.");
                return "Erro: Nenhum NPC encontrado no banco de dados.";
            }

            var relevantRelationshipsData = GetRelevantNpcDataFromPrompt(brain, npcDatabase, inputPromptLower);

            var relevantRaceData = GetRelevantRaceDataFromPrompt(brain, inputPromptLower);

            var relevantEnvironmentData = GetRelevantEnvironmentDataFromPrompt(brain, inputPromptLower);

            string fullPrompt = PromptBuilder.BuildAiPrompt(
                                                                npcProfileJson, inputPrompt, 
                                                                relevantRelationshipsData, 
                                                                relevantRaceData,
                                                                relevantEnvironmentData
                                                            );

            Debug.WriteLine("--- FULL PROMPT SENT TO AI (Simulated) ---");
            Debug.WriteLine(fullPrompt);
            Debug.WriteLine("------------------------------------------");
            //return $"AI Response (simulated for {npcId}): Based on the detailed profile provided and your input, I would say something witty and insightful about {inputPrompt}.";
            
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

            return $"AI Response (simulated for {npcId}): Based on the detailed profile provided and your input, I would say something witty and insightful about {inputPrompt}.";
        }
    }
}
